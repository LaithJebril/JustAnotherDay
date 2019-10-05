using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer PlayerSpriteRenderer;

    // Directions 
    int up = 0;
    int Down = 1;
    int Right = 2;
    int Left = 3;

    public float Speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Move Up
        {
            // Player Animation 
            //animator.SetInteger("",up);

            // Movement
            body.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * Speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // Move DOWN
        {
            // Player Animation 
            //animator.SetInteger("", Down);

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
    }
}
