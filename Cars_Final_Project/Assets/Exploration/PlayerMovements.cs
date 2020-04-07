using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 40f;

    public Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("HorizontalMap"); 
        movement.y = Input.GetAxisRaw("VerticalMap");

        animator.SetFloat("HorizontalMap", movement.x);
        animator.SetFloat("VerticalMap", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
