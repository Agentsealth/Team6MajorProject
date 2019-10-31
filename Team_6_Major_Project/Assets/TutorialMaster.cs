using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMaster : MonoBehaviour
{

    public GameObject MenuUI;
    public GameObject TutorialUI;

    public Text tutTitle;
    public Text tutPurpose;
    public Text tutConditions;
    public Image tutImage;
    public Sprite[] Images;

    public Text OpenClose;
    public GameObject Book;
    // Start is called before the first frame update
    public void ShowHide()
    {
        if (OpenClose.text == "→")
        {
            showTutorial();
        }
        else HideTutorial();
    }

    void showTutorial()
    {
        Book.GetComponent<Animator>().Play("TutorialPaperOut");
        MenuUI.SetActive(false);
        TutorialUI.SetActive(true);
        OpenClose.text = "←";
    }

    void HideTutorial()
    {
        Book.GetComponent<Animator>().Play("TutorialPaperIn");
        MenuUI.SetActive(true);
        TutorialUI.SetActive(false);
        OpenClose.text = "→";
    }

    public void FlipTutorialBack()
    {
        Book.GetComponent<Animator>().Play("TutorialPaperFlipFront");

    }

    public void NPCTut()
    {
        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");
        tutTitle.text = "Customers";
        tutPurpose.text = "-Gives you requests that appear on dockets.\n-Primary way to earn money.";
        tutConditions.text = "See Dockets\nSee Weapon Holder";
        tutImage.sprite = Images[0];
    }

    public void DocketTut()
    {
        Book.GetComponent<Animator>().Play("TutorialPaperFlip");

        tutTitle.text = "Dockets";
        tutPurpose.text = "Folk that want to order swords. \n Primary way to earn money";
        tutConditions.text = "Pay based on materials, condition, and labour cost";
        tutImage.sprite = Images[0];
    }
}
