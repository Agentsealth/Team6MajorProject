using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMaster : MonoBehaviour
{

    public GameObject MenuUI;
    public GameObject TutorialUI;
    public GameObject Checklist;
    public GameObject TutSheet;
    public GameObject EquipmentSheet;
    public GameObject PeopleSheet;

    public Text tutTitle;
    public Text tutPurpose;
    public Text tutConditions;
    public Image tutImage;
    public Sprite[] Images;

    public Text OpenClose;
    public GameObject Book;
    public GameObject tutRoot;
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



    public void ToggleSubmenu(GameObject otherMenu)
    {
        if (otherMenu.activeSelf)
        {

            TutorialUI.SetActive(true);
            otherMenu.SetActive(false);
            return;
            
        } else if (!otherMenu.activeSelf)
        {
            otherMenu.SetActive(true);
            TutorialUI.SetActive(false);

            return;
        }
    }
    public void ToggleTutSheet()
    {
        tutRoot.SetActive(true);
        TutSheet.SetActive(false);
        Book.GetComponent<Animator>().Play("TutorialFlipFront");

    }




    public void DocketTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;
        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Dockets";
        tutPurpose.text = "-Describes given order\n-Serves as a reminder";
        tutConditions.text = "-Customers\nSword Holder";
        tutImage.sprite = Images[0];
    }

    public void CoalTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Coal Hatch";
        tutPurpose.text = "-Add Coal to start\n-Powers Crucible and Grills";
        tutConditions.text = "-Shop\n-Crucible/Grills";
        tutImage.sprite = Images[1];
    }

    public void CrucibleTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Crucible";
        tutPurpose.text = "-Used to Melt Chunks to Ingots\n-Requires Coal";
        tutConditions.text = "-Coal Hatch\n-Grills";
        tutImage.sprite = Images[2];
    }

    public void GrillsTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Grills";
        tutPurpose.text = "-Used to heat Ingots and Sheets\n-Requires Coal";
        tutConditions.text = "-Coal Hatch\n-Crucible";
        tutImage.sprite = Images[3];
    }

    public void AnvilTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Anvil";
        tutPurpose.text = "-Used to make Sheets and Blades\n-Requires hot Ingot(s)/Sheet";
        tutConditions.text = "-Crucible\n-Grindstone";
        tutImage.sprite = Images[4];
    }

    public void GrindstoneTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Grindstone";
        tutPurpose.text = "-Used to make Guards and Handles\n-Requires (not hot) Sheets";
        tutConditions.text = "-Crucible\n-Anvil";
        tutImage.sprite = Images[5];
    }

    public void QuenchingTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Quenching Barrel";
        tutPurpose.text = "-Used to cool hot items\n-Requires hot Sheets/Ingots";
        tutConditions.text = "-Anvil\n-Grills";
        tutImage.sprite = Images[6];
    }

    public void AssemblyTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Assembly Table";
        tutPurpose.text = "-Used to assemble Swords\n-Requires Blade, Guard, & Handle";
        tutConditions.text = "-Grindstone\n-Anvil";
        tutImage.sprite = Images[7];
    }

    public void HolderTut()
    {
        TutSheet.SetActive(true);
        tutRoot = EquipmentSheet;

        Book.GetComponent<Animator>().Play("TutorialPaperFlipBack");

        tutTitle.text = "Sword Holder";
        tutPurpose.text = "-Used to sell Swords\n-Requires assembled Sword";
        tutConditions.text = "-Assembly Table\n-Customers";
        tutImage.sprite = Images[8];
    }
}
