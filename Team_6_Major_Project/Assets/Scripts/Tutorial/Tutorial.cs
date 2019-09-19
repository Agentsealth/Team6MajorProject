using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    //idk if will use 1 panel or multiple
    public GameObject tutPanel01, tutPanel02, tutPanel03; //make array later or something idk
    public GameObject[] tutPanels = new GameObject[1];
    [TextArea(3, 5)]
    public string[] texts = new string[1]; //array of strings for Tutorial panel
    public int textPos = 0; //current position in string array
    //public int panelPos = 0;
    public Text currentText = null; //String currently displayed in Text
    public Button nextButton = null; //button to move onto next step

    public GameObject dialogueTrigger;

    void Awake()
    {
        nextButton = GetComponent<Button>();
        //dialogueTrigger = GetComponent<TestDialogueTrigger>();
    }

    public void NextButton()
    {
        if (/*panelPos + 1 < tutPanels.Length &&*/ textPos + 1 < texts.Length)
        {
            ++textPos;
            //++panelPos;
        }
        else/* if (textPos >= texts.Length)*/
        {
            tutPanel01.SetActive(false);
            dialogueTrigger.SetActive(true);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            currentText.text = texts[textPos];
            NextButton();
        }

    }
}
