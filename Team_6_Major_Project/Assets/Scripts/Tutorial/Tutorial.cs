using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //idk if will use 1 panel or multiple
    public GameObject tutPanel01, tutPanel02, tutPanel03; //make array later or something idk
    //public GameObject[] tutPanels = new GameObject[1];
    [TextArea(3, 5)]
    public string[] texts = new string[1]; //array of strings for Tutorial panel
    public int textPos = 0; //current position in string array
    //public int panelPos = 0;
    public Text currentText = null; //String currently displayed in Text
    public Button nextButton = null; //button to move onto next step

    public GameObject dayProgresion;

    private PlayerController _controller;
    public TestDialogueTrigger _dialogueTrigger;

    public bool inchat;

    void Awake()
    {
        nextButton = GetComponent<Button>();
        _controller = GetComponent<PlayerController>();
       // _dialogueTrigger.inDialogue = false;
    }

    public void NextButton()
    {
        if (/*panelPos + 1 < tutPanels.Length &&*/ textPos + 1 < texts.Length)
        {
            ++textPos;
            //++panelPos;
            if (textPos == 2)
            {
                dayProgresion.SetActive(true);            
            }

            _dialogueTrigger = GameObject.FindObjectOfType<TestDialogueTrigger>();
            if (_dialogueTrigger.inDialogue == true)
            {
                inchat = _dialogueTrigger.inDialogue;
            }
            else
            {
                inchat = _dialogueTrigger.inDialogue;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inchat == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                currentText.text = texts[textPos];
                NextButton();
            }
        }
        else
        {
            return;
        }

    }
}
