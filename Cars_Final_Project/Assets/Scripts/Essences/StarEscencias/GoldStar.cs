using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldStar : MonoBehaviour {
    public float speed = 2F;

    public Rigidbody2D rigb;
    



    // Use this for initialization
    void Start () { 

        rigb.velocity = transform.right * -1 * speed;
    }

    

    // Update is called once per frame
    void Update () {
		
	}

    
}
