using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JugadorScen : MonoBehaviour {

    public int health = 90; //Vidas o Salud del Jugador.
    public int damage = 30;
    public GameObject impactEffect;

    ScoreEssences _scoreCounter;
    



    [SerializeField]
    public float speed;
    float width;

    string input;

    // Use this for initialization
    void Start()
    {

        _scoreCounter = GameObject.Find("GameController").GetComponent<ScoreEssences>();

        width = transform.localScale.y;
        speed = 5f;

    }



    public void Init(bool isRightJugador)
    {
        Vector2 pos = Vector2.zero;


        if (isRightJugador == false)
        {
            //Jugador
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "JugadorScen";
        }


        transform.name = input;

    }
    // Update is called once per frame
    void Update()
    {
        //Mover Jugador
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameController.bottomLeft.y + width / 6 && move < 0) //Fijo los limites del desplazamiento (Death Zone Inferior).
        {
            move = 0;
        }
        //Death Zone Superior
        if (transform.position.y > GameController.topRight.y - width / 6 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);

    }


    public void OnTriggerEnter2D (Collider2D other)
    {
       
        Debug.Log(other.gameObject.name);


        ScoreEssences.ScoreType scoreType;
        
        try
        {
            scoreType = (ScoreEssences.ScoreType)Enum.Parse(typeof
            (ScoreEssences.ScoreType), other.gameObject.tag);
        }
        catch (Exception)
        {
            return;
        }


        
        if (scoreType == ScoreEssences.ScoreType.Rock)
        {
            //Restar Vidas
            VidaEssenScript.vidaValue -= 1;
            
        }
        else
        {
            _scoreCounter.UpdateScore(scoreType);
        }

        

        Destroy(other.gameObject);


        //Game Over in the Game
        if (VidaEssenScript.vidaValue <= 0)
        {
            
            Debug.Log("Has perdido el Juego!");

            Time.timeScale = 0;
            enabled = false;
            
           
        }
          


    }


}
 



