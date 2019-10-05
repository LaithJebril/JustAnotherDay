using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Canves;
    public Person person;
    public TextMeshProUGUI NameTextDisplay;
    public TextMeshProUGUI TextDisplay;
    public float TypingSpeed;

    private string Name;
    private string[] Dialogue;
    private int Index;
    private bool Continue = false;
    private bool Active = false;

    private void Start()
    {
        Canves.SetActive(false);
        Name = person.Name;
        Dialogue = person.Sentences;
        NameTextDisplay.text = Name;
        TextDisplay.text = "";
    }
    //Activate on Closure
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (Active == false)
                {
                    Canves.SetActive(true);
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
        if (TextDisplay.text == Dialogue[Index])
        {
            Continue = true;
        }
    }

    //Main Typing Fuction
    IEnumerator Type()
    {
        foreach (char letter in Dialogue[Index].ToCharArray())
        {
            TextDisplay.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
        }

    }
    //Continue Button Function

    public void NextSentence()
    {
        if (Continue == true)
        {
            if (Index < Dialogue.Length - 1)
            {
                Index++;
                TextDisplay.text = "";
                StartCoroutine(Type());
                Continue = false;

            }
            else
            {
                Continue = false;

            }
        }
    }
}
