using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Worker : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    [TextArea(2, 5)]
    public string Massege;
    public Sprite[] WorkerSP;
    SpriteRenderer Worker_SPR;
    public float Speed;
    PlayerMovement Player;
    bool Nearby;


    [Header("Door")]
    public Transform MaxUpLifting;
    public GameObject Door;
    public float PowerGiven = 0;
    public float PowerNeeded = 100;
    public Vector3 StartDoorPostion;

    [Header("Player Power")]
    public float OpenForce = 2;
    public float CloseForce = 0.1f;


    void Start()
    {
        StartDoorPostion = Door.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Worker_SPR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        OpenStore();
    }
    private void FixedUpdate()
    {
        Door.transform.position = new Vector2(StartDoorPostion.x, StartDoorPostion.y + PowerGiven * 0.01f);
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
    void OpenStore()
    {
        PowerGiven = Mathf.Clamp(PowerGiven, 0, PowerNeeded);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Nearby)
            {
                PowerGiven += OpenForce;
            }
        }
        else
        {
            if (PowerGiven <= PowerNeeded-10)
            {
                PowerGiven -= CloseForce;
            }
        }
        if ((PowerGiven > PowerNeeded - 10))
        {
            this.SendMessage("EndTask");
        }
    }
    public void EndDialogue()
    {
        TextDisplay.text = Massege;
    }
}
