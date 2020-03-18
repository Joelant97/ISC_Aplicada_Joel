using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour
{
    public JugadorFly jugadorFly;

    

    public static Vector2 topRight;
    public static Vector2 bottomLeft;


    // Use this for initialization
    void Start()
    {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        JugadorFly jugador1 = Instantiate(jugadorFly) as JugadorFly;
        jugador1.Init(false);


    }

   
}
