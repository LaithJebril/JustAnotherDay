﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crush : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    [TextArea(2, 5)]
    public string Massege;

    bool StartTask;
    void Start()
    {
    }
    void Update()
    {
        if (StartTask)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.SendMessage("EndTask");
            }
        }
    }
    private void FixedUpdate()
    {
    }
    void OnTriggerStay2D(Collider2D other)
    {
    }
    void OnTriggerExit2D(Collider2D other)
    {
    }
    public void EndDialogue()
    {
        StartTask = true;
        TextDisplay.text = Massege;

    }
}
