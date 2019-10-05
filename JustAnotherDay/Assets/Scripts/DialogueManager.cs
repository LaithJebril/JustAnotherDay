using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] Dialogues;
    private int Index;
    public float TypingSpeed;
    public bool Continue;

    public bool Active = false;


    //Activate on Closure
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Active == false)
                {
                    Active = true;
                    StartCoroutine(Type());
                }
                if (Active)
                {
                    NextSentence();
                }
            }
        }
    }

    //Enabling Con Button
    void Update()
    {
        if (textDisplay.text == Dialogues[Index])
        {
            Continue = true;
        }
    }

    //Main Typing Fuction
    IEnumerator Type()
    {
        foreach (char letter in Dialogues[Index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }
    //Continue Button Function

    public void NextSentence()
    {
        if (Continue == true)
        {
            if (Index < Dialogues.Length - 1)
            {
                Index++;
                textDisplay.text = "";
                StartCoroutine(Type());
                Continue = false;

            }


            else
            {
                textDisplay.text = "";
                Continue = false;
                Active = false;
                Index = 0;

            }
        }
    }
}
