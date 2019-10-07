using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldMan : MonoBehaviour
{
    public NextScene nextScene;
    public TextMeshProUGUI TextDisplay;
    [TextArea(2,5)]
    public string Massege;
    public Transform EndPoint;
    public Rigidbody2D Body;
    Animator animator;
    public float Speed;
    PlayerMovement Player;
    public float XOffSet;
    bool StartTask;
    bool Nearby;
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        animator.SetBool("IsWalking", false);
    }
    void Update()
    { 
        if (StartTask && Nearby)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (transform.position.x < EndPoint.position.x)
                {
                    animator.SetBool("IsWalking", true);
                    Body.MovePosition(transform.position + transform.right * Time.fixedDeltaTime * Speed);
                    Vector3 OffSet = new Vector3(transform.position.x - XOffSet, transform.position.y, transform.position.z);
                    Player.Move_Right(OffSet);
                }
                else
                {
                    this.SendMessage("EndTask");
                    nextScene.CanGoNextScene = true;
                }
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Nearby = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Nearby = false;
        }
    }
    public void EndDialogue()
    {
        StartTask = true;
        TextDisplay.text = Massege;
    }
}
