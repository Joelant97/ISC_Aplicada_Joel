﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpelStar : MonoBehaviour {

    public float speed = 2F;

    public Rigidbody2D rigb;

    public int healthPurpeldSt = 30;


    // Use this for initialization
    void Start()
    {

        rigb.velocity = transform.right * -1 * speed;
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
