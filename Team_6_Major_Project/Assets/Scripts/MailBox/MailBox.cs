using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public bool inRange = false;
    public bool inLetter = false;
    public bool letterDoneforDay = false;
    public bool letterStart = false;
    public bool trigger = false;

    public MailSlot mailSlot;
    public Letter letter;
    public LetterManager letterManager;
    public Shop shop;

    public int currentTextNumber;
    public int gold;
    public int randomtype;
    public int randomblademat;
    public int randomguardmat;
    public int randomhandlemat;
    public int bladeIngot;
    public int costToMake;
    public int steelCost;
    public int ironCost;
    public int bronzeCost;
    public int coalCost;
    public int bladeIngotCost;
    public int guardIngotCost;
    public int handleIngotCost;
    public int cost;
    public int quality;

    public PlayerStats playerStats;

    public float dist;
    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        letterManager = FindObjectOfType<LetterManager>();
        playerStats = FindObjectOfType<PlayerStats>();

        shop = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Shop>();
        coalCost = shop.coalCost;
        ironCost = shop.ironCost;
        steelCost = shop.steelCost;
        bronzeCost = shop.bronzeCost;
  
    }
    //Functions which gets the cost based on an equation
    public void Tip()
    {
        cost = (int)(costToMake + (((quality / 100) - 0.5) * costToMake) + 10);
    }
    //Functions which gets the cost to make based on an equation
    public void Price()
    {
        SwordTypeCheck();
        BladeMatCheck();
        HandleMatCheck();
        GuardMatCheck();
        costToMake = (bladeIngot * bladeIngotCost) + (1 * handleIngotCost) + (1 * guardIngotCost) + (4 * coalCost);
    }
    //Functions which checks the sword type
    void SwordTypeCheck()
    {
        if (letter.bladeType[letter.specialIndex - 1] == (Sword.SwordType)1)
        {
            bladeIngot = 1;
        }
        else if (letter.bladeType[letter.specialIndex - 1] == (Sword.SwordType)2)
        {
            bladeIngot = 2;
        }
        else if (letter.bladeType[letter.specialIndex - 1] == (Sword.SwordType)3)
        {
            bladeIngot = 3;
        }
    }
    //Functions which checks the material for the blade
    void BladeMatCheck()
    {
        if (letter.bladeMaterial[letter.specialIndex - 1] == (Sword.MaterialBlade)1)
        {
            bladeIngotCost = ironCost;
        }
        else if (letter.bladeMaterial[letter.specialIndex - 1] == (Sword.MaterialBlade)2)
        {
            bladeIngotCost = steelCost;
        }
        else if (letter.bladeMaterial[letter.specialIndex - 1] == (Sword.MaterialBlade)3)
        {
            bladeIngotCost = bronzeCost;
        }
    }
    //Functions which checks the material for the guard
    void GuardMatCheck()
    {
        if (letter.guardMaterial[letter.specialIndex - 1] == (Sword.MaterialGuard)1)
        {
            guardIngotCost = ironCost;
        }
        else if (letter.guardMaterial[letter.specialIndex - 1] == (Sword.MaterialGuard)2)
        {
            guardIngotCost = steelCost;
        }
        else if (letter.guardMaterial[letter.specialIndex - 1] == (Sword.MaterialGuard)3)
        {
            guardIngotCost = bronzeCost;
        }
    }
    //Functions which checks the material for the handle
    void HandleMatCheck()
    {
        if (letter.handleMaterial[letter.specialIndex - 1] == (Sword.MaterialHandle)1)
        {
            handleIngotCost = ironCost;
        }
        else if (letter.handleMaterial[letter.specialIndex - 1] == (Sword.MaterialHandle)2)
        {
            handleIngotCost = steelCost;
        }
        else if (letter.handleMaterial[letter.specialIndex - 1] == (Sword.MaterialHandle)3)
        {
            handleIngotCost = bronzeCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        dist = Vector3.Distance(gameObject.transform.position, playerStats.gameObject.transform.position);
        if (dist <= 2)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if (inRange == true)
        {
            if (letterDoneforDay == false)
            {
                SetLetter();
                if (Input.GetKeyDown(KeyCode.F) && letterStart == false)
                {
                    if (trigger == false)
                    {
                        TriggerDialogue();
                        trigger = true;
                    }
                    else
                    {
                        letterManager.OpenLetter();
                    }
                    inLetter = letterManager.inChat;
                    letterStart = true;
                }
                else if (Input.GetKeyDown(KeyCode.F) && letterStart == true)
                {
                    inLetter = letterManager.inChat;
                    if (inLetter == false)
                    {
                        letterDoneforDay = true;
                        letterStart = false;
                        SetItemSlot();
                        letterManager.EndLetter();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.L) && letterStart == false)
                {
                    letterManager.OpenLetter();
                    letterStart = true;
                }
                else if (Input.GetKeyDown(KeyCode.L) && letterStart == true)
                {
                    letterManager.EndLetter();
                    letterStart = false;
                }
            }
        }
        else
        {
            letterManager.EndLetter();
            letterStart = false;
        }

    }
    //Functions which sets the item slot
    public void SetItemSlot()
    {
        mailSlot.docketBlade.text = letter.bladeType[letter.specialIndex - 1].ToString() + " " + letter.bladeMaterial[letter.specialIndex - 1].ToString() + " blade.";
        mailSlot.docketGuard.text = letter.guardMaterial[letter.specialIndex - 1].ToString() + " guard ";
        mailSlot.docketHandle.text = letter.handleMaterial[letter.specialIndex - 1].ToString() + " handle";

    }
    //Functions which sets the letter
    public void SetLetter()
    {
        if (letter.specialIndex == 1)
        {
            currentTextNumber = letterManager.special1TextFile;
        }
        else if (letter.specialIndex == 2)
        {
            currentTextNumber = letterManager.special2TextFile;
        }

        if (letter.letterFile[currentTextNumber] != null)
        {
            letter.sentences = (letter.letterFile[currentTextNumber].text.Split('\n'));
        }

        Price();
    }
    //Functions which checks the item
    public void CheckItem()
    {
        if (mailSlot.bladeType == letter.bladeType[letter.specialIndex - 1])
        {
            if (mailSlot.bladeMaterial == letter.bladeMaterial[letter.specialIndex - 1])
            {
                if (mailSlot.guardMaterial == letter.guardMaterial[letter.specialIndex - 1])
                {
                    if (mailSlot.handleMaterial == letter.handleMaterial[letter.specialIndex - 1])
                    {
                       
                        
                            if (letter.specialIndex == 1)
                            {
                                letterManager.special1TextFile += 1;
                                currentTextNumber = letterManager.special1TextFile;
                                letter.specialIndex += 1;
                            }
                            else if (letter.specialIndex == 2)
                            {
                                letterManager.special2TextFile += 1;
                                currentTextNumber = letterManager.special2TextFile;
                                letter.specialIndex -= 1;
                            }

                            quality = mailSlot.quality;
                            Tip();
                            playerStats.gold += cost;
                            Destroy(mailSlot.sword);
                            letterDoneforDay = false;
                            letterManager.FinishLetter();
                            letterManager.sentences.Clear();
                            trigger = false;
                    }
                    else
                    {
                        mailSlot.sword.transform.position = mailSlot.badlocation.position;
                    }
                }
                else
                {
                    mailSlot.sword.transform.position = mailSlot.badlocation.position;
                }
            }
            else
            {
                mailSlot.sword.transform.position = mailSlot.badlocation.position;
            }
        }
        else
        {
            mailSlot.sword.transform.position = mailSlot.badlocation.position;
        }
    }

    //Functions which triggers the dialogue
    public void TriggerDialogue()
    {
        letterManager.StartLetter(letter);
    }
}
