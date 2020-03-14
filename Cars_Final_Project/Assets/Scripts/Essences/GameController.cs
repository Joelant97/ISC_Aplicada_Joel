using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    
    public JugadorScen jugadorScen;

    public GameObject goldStar;
    public GameObject greenStar;
    public GameObject purpelStar;
    public GameObject redStar;
    public GameObject rock;

    public static Vector2 topRight;
    public static Vector2 bottomLeft;


    // Use this for initialization
    void Start()
    {
        float randomSecnd = Random.Range(1, 6);

        //2do. parametro es tiempo en el que inicia las instruccion la primera vez y el 3er. tiempo entre cada Invoke.  
        InvokeRepeating("inst", randomSecnd, randomSecnd); //Llama la funcion instanciadora repetidas veces.

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        JugadorScen jugador1 = Instantiate(jugadorScen) as JugadorScen;
        jugador1.Init(false);


    }

    void inst() 
    {
        Instantiate(redStar, new Vector3(4.26f, -1.49f, -0.084f), transform.rotation);
        Instantiate(goldStar, new Vector3(7.03f, -4.09f, -0.084f), transform.rotation);
        Instantiate(greenStar, new Vector3(2.418f, 1.596f, -0.084f), transform.rotation);
        Instantiate(purpelStar, new Vector3(7.38f, 3.71f, -0.084f), transform.rotation);
        Instantiate(rock, new Vector3(1.05f, 0f, -0.084f), transform.rotation);

    }

    
}
