﻿using System.Collections;
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
    public float max_x;
    public float max_y;

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
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -max_x, max_x), Mathf.Clamp(transform.position.y, -max_y, max_y));
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // Move Up
        {
            // Player Animation 
            animator.SetInteger("AnimationState", up);

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
            Move_Right(transform.position);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Move LEFT
        {
            Move_Left(transform.position);
        }
        else
        {
            animator.SetInteger("AnimationState", Idle);
        }
    }
    public void Move_Left(Vector3 StartPos)
    {
        // Player Animation 
        animator.SetInteger("AnimationState", Left);

        // Movement
        body.MovePosition(StartPos - transform.right * Time.fixedDeltaTime * Speed);
    }
    public void Move_Right(Vector3 StartPos)
    {
        // Player Animation 
        animator.SetInteger("AnimationState", Right);

        // Movement
        body.MovePosition(StartPos + transform.right * Time.fixedDeltaTime * Speed);
    }
}
