using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementFollowMouse : MonoBehaviour
{
    Rigidbody2D body;
    public Vector3 MouseClick;
    public float Speed;
    Animator animator;

    // Directions 
    int Idle = 0;
    int up = 1;
    int Down = 2;
    int Right = 3;
    int Left = 4;

    Vector3 MoveToPostion;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MoveToPostion = transform.position;//donot move when start game ;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void FixedUpdate()
    {
        MoveToPostion = new Vector3(MouseClick.x, transform.position.y, transform.position.z);
        if (MoveToPostion.x == transform.position.x)
        {
            body.MovePosition(Vector3.MoveTowards(transform.position, MouseClick, Speed)); // move on y 
            if (MouseClick.y < transform.position.y)
            {
                Debug.Log("Down");
                animator.SetInteger("AnimationState", Down);
            }
        }
        else
        {
            body.MovePosition(Vector3.MoveTowards(transform.position, MoveToPostion, Speed)); // move on x
        }
    }
}
