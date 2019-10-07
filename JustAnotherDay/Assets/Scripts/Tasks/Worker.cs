using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Worker : MonoBehaviour
{
    public NextScene nextScene;
    public TextMeshProUGUI TextDisplay;
    [TextArea(2, 5)]
    public string Massege;
    public float Speed;
    PlayerManager Player;
    bool Nearby;

    [Header("Door")]
    public Transform MaxUpLifting;
    public GameObject Door;
    public float PowerGiven = 0;
    public float PowerNeeded = 90;
    public Vector3 StartDoorPostion;

    [Header("Player Power")]
    public float OpenForce = 2;
    public float CloseForce = 0.1f;

    [Header("Sprites")]
    public Sprite[] WorkerSP;
    SpriteRenderer Worker_SPR;

    void Start()
    {
        StartDoorPostion = Door.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        Worker_SPR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        OpenStore();
        WorkerAnimation();
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
        PowerGiven = Mathf.Clamp(PowerGiven, 0, 100);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Nearby)
            {
                PowerGiven += OpenForce;
               // Player.AnimatioSetActive(false);
            }
        }
        else
        {
            if (PowerGiven <= PowerNeeded)
            {
                PowerGiven -= CloseForce;
               // Player.AnimatioSetActive(true);
            }
        }
        if (PowerGiven > PowerNeeded)
        {
            this.SendMessage("EndTask");
            nextScene.CanGoNextScene = true;
        }
    }
    void WorkerAnimation()
    {
        if (PowerGiven > 20)
        {
            Worker_SPR.sprite= WorkerSP[1];
           // Player.Animation(1);
        }
        else
        {
            Worker_SPR.sprite = WorkerSP[0];
           // Player.Animation(0);
        }
    }
    public void EndDialogue()
    {
        TextDisplay.text = Massege;
    }
}
