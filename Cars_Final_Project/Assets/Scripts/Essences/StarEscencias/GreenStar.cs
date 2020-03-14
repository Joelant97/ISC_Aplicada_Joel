using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStar : MonoBehaviour {
    public float speed = 2F;

    public Rigidbody2D rigb;

    public int healthGreenSt = 30;


    // Use this for initialization
    void Start()
    {

        rigb.velocity = transform.right * -1 * speed;
    }

 


    // Update is called once per frame
    void Update () {
		
	}
}
