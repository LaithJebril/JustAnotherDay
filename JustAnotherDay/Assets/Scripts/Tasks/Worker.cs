using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Worker : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    [TextArea(2, 5)]
    public string Massege;
    public Rigidbody2D Body;
    Animator animator;
    public float Speed;
    PlayerMovement Player;
    bool StartTask;
    bool Nearby;
    public float Progress;
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (StartTask && Nearby)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Progress++;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Progress++;
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
