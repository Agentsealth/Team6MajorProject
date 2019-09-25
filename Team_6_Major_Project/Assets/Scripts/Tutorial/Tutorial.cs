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
    private bool firstBit = false;

    void Awake()
    {
        nextButton = GetComponent<Button>();
        _controller = GetComponent<PlayerController>();
        isTutorialing = true;
       // _dialogueTrigger.inDialogue = false;
    }

    public void NextButton()
    {
        if (firstBit == false)
        {
            textPos = 0;
            inchat = false;
            firstBit = true;
            return;
        }
        if (textPos + 1 < texts.Length && firstBit == true)
        {
            textPos++;
            currentText.text = texts[textPos];

            //++panelPos;

            switch (textPos)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 13:
                case 14:
                case 15:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    tutPanel01.SetActive(false);
                    inchat = true;
                    break;
                case 25:
                    tutPanel01.SetActive(false);
                    inchat = true;
                    isTutorialing = false;
                    break;
            }

        } 

    }

    // Update is called once per frame
    void Update()
    {
        if (textPos == 1)
        {
            dayProgresion.SetActive(true);
        }
        if (isTutorialing == true)
        {


            if (inchat == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
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

    public void ProgressTutorial(int neededPos)
    {
        if (isTutorialing)
        {
            inchat = false;
            tutPanel01.SetActive(true);
            textPos = neededPos;
            currentText.text = texts[textPos];
        }
        

    }
}
