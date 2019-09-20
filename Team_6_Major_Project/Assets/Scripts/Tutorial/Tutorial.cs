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

    public bool isTutorialing;

    void Awake()
    {
        nextButton = GetComponent<Button>();
        _controller = GetComponent<PlayerController>();
        isTutorialing = true;
       // _dialogueTrigger.inDialogue = false;
    }

    public void NextButton()
    {
        if (textPos + 1 < texts.Length)
        {
            textPos++;
            //++panelPos;
            if (textPos == 1)
            {
                dayProgresion.SetActive(true);            
            }
            if(textPos == 2)
            {
                tutPanel01.SetActive(false);
                inchat = true;
            }  
            if(textPos == 4)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 6)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 8)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 9)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 10)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 11)
            {
                tutPanel01.SetActive(false);
                inchat = true;

            }
            if (textPos == 12)
            {
                inchat = true;
                tutPanel01.SetActive(false);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (inchat == false)
        {
            if (Input.GetKeyDown(KeyCode.F) )
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
    public void CanvasToggleOn()
    {

        tutPanel01.SetActive(true);
        inchat = false;
    }


    public void CanvasToggleOnV2()
    {

        tutPanel01.SetActive(true);
   
    }
    public void TutorialNextStep(int expectedTextPos)
    {
        if(expectedTextPos != textPos)
        {
            if(textPos == expectedTextPos - 1)
            {
                tutPanel01.SetActive(true);

                currentText.text = texts[expectedTextPos];
                textPos = expectedTextPos;
            }
        }
    }
}
