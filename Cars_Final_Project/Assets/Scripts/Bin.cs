using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    public float speed;
    float width;

    string input;
    public AudioSource tickSource;


    // Start is called before the first frame update
    void Start()
    {
        width = transform.localScale.y;
        speed = 5f;

        //Init Sound
        tickSource = GetComponent<AudioSource>();

    }

    public void Init(bool isRightJugador)
    {
        Vector2 pos = Vector2.zero;


        if (isRightJugador == false)
        {
            //Bin of the Player
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;

            input = "Bin";
        }


        transform.name = input;

    }

    // Update is called once per frame
    void Update()
    {
        //Move Player
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        //set limit of move x=Horizontal Limits and y=Vertical Limits (Death Zone left).
        if (transform.position.x < GameManager.bottomLeft.x + width / 4 && move < 0) 
        {
            move = 0;
        }
        //Death Zone Right
        if (transform.position.x > GameManager.topRight.x - width / 4 && move > 0)
        {
            move = 0;
        }

        //assign player translation (Horizontal Translation right)
        transform.Translate(move * Vector2.right);

        //Game Over in the Game
        if (VidaScript.vidaValue <= 0)
        {
            Debug.Log("Fin del Juego");

            Time.timeScale = 0;
            enabled = false;
        } 

    }

    public void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.gameObject.name);

        ScoreScript.scoreValue += 1;
        //Play Sound
        tickSource.Play();
        Destroy(other.gameObject);

    }

}
