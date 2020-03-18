using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorFly : MonoBehaviour
{
    




    [SerializeField]
    public float speed;
    float width;

    string input;
    public AudioSource tickSource;

    // Use this for initialization
    void Start()
    {

        

        width = transform.localScale.y;
        speed = 20f;

        //Init Sound
        tickSource = GetComponent<AudioSource>();

    }



    public void Init(bool isRightJugador)
    {
        Vector2 pos = Vector2.zero;


        if (isRightJugador == false)
        {
            //Jugador
            pos = new Vector2(GameController2.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "JugadorFly";
        }


        transform.name = input;

    }
    // Update is called once per frame
    void Update()
    {
        //Mover Jugador
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameController2.bottomLeft.y + width / 6 && move < 0) //Fijo los limites del desplazamiento (Death Zone Inferior).
        {
            move = 0;
        }
        //Death Zone Superior
        if (transform.position.y > GameController2.topRight.y - width / 6 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);

    }


    public void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log(other.gameObject.name);

        VidasFlyScript.vidaValue -= 1;
        tickSource.Play();


        //Game Over in the Game
        if (VidaEssenScript.vidaValue <= 0)
        {

            Debug.Log("Has perdido el Juego!");

            Time.timeScale = 0;
            enabled = false;


        }



    }
}
