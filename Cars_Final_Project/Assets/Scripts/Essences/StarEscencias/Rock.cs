using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    public float speed = 2F;

    public Rigidbody2D rigb;
    public GameObject impactEffect;

    public int healthRock = 30;


    // Use this for initialization
    void Start()
    {

        rigb.velocity = transform.right * -1 * speed;
    }

    //Funcion se ejecuta en la roca al chocar al Jugador
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        JugadorScen jugadorScen = hitInfo.GetComponent<JugadorScen>();
        if (jugadorScen != null)
        {
            GameObject impEff = (GameObject)GameObject.Instantiate(impactEffect, transform.position, transform.rotation);

           
            UnityEditor.EditorApplication.delayCall += () =>
            {
                Destroy(impEff);
            };
        }


    }


    // Update is called once per frame
    void Update()
    {

    }
}
