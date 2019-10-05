using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer PlayerSpriteRenderer;

    // Directions 
    int Idle = 0;
    int up = 1;
    int Down = 2;
    int Right = 3;
    int Left = 4;

    public float Speed = 5.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Move Up
        {
            // Player Animation 

            // Movement
            body.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Move DOWN
        {
            // Player Animation 
            animator.SetInteger("AnimationState", Down);

            // Movement
            body.MovePosition(transform.position - transform.up * Time.fixedDeltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Move RIGHT
        {
            // Player Animation 
            //animator.SetInteger("", Right);

            // Movement
            body.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Move LEFT
        {
            // Player Animation 
            //animator.SetInteger("", Left);

            // Movement
            body.MovePosition(transform.position - transform.right * Time.fixedDeltaTime * Speed);
        }
        else
        {
            animator.SetInteger("AnimationState", Idle);
        }
    }
}
