using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestDialogueTrigger : MonoBehaviour
{
    public bool inRange = false;
    public bool inDialogue = false;
    public bool dialogueDoneforDay = false;
    public bool dialogueStart = false;
    public bool banterChat = false;
    public bool tutorial;
    public bool delayCustomer = false;
    public bool delayAi = false;

    public ItemSlot[] slots;
    public ItemSlot SlotNumber;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public CustomerAI customerAI;
    public Shop shop;
    public GameObject floatingImage;
    public Transform imagePosition;
    public Sprite badEmo;
    public Sprite neutralEmo;
    public Sprite goodEmo;

    public int currentTextNumber;
    public int CustomerNumber;
    public int gold;
    public int randomtype;
    public int randomblademat;
    public int randomguardmat;
    public int randomhandlemat;
    public int randomgreeting;
    public int randombadtext;
    public int randomgoodtext;
    public int randomneturaltext;

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
    public int materialGen;
    public int image;

    public AudioSource coinGain;
    public PlayerStats playerStats;

    public float dist;
    public float delay = 2f;
    public float delayInteraction = 200f;
    public float delayAiInteraction = 100f;

    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the delayInteraction to 200
        delayInteraction = 200;
        //Sets the AIinteractiondelay to 100
        delayAiInteraction = 100;
        //Finds the dialogueManager
        dialogueManager = FindObjectOfType<DialogueManager>();
        //Finds the CustomerAI
        customerAI =this.gameObject.GetComponent<CustomerAI>();
        //Finds the playerStats
        playerStats = FindObjectOfType<PlayerStats>();
        //Finds the slots
        slots = FindObjectsOfType<ItemSlot>();
        //Finds the tutorial
        tut = FindObjectOfType<Tutorial>();
        //Find the shop
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Shop>();
        //Set the coal cost by finding the coalcost from the shop script
        coalCost = shop.coalCost;
        //Set the iron cost by finding the ironCost from the shop script
        ironCost = shop.ironCost;
        //Set the steel cost by finding the steelCost from the shop script
        steelCost = shop.steelCost;
        //Set the bronze cost by finding the bronzeCost from the shop script
        bronzeCost = shop.bronzeCost;
        //Checks if the tutorial is false
        if (tutorial == false)
        {
            //Sets the random type based on a random range between 1 and 4
            randomtype = Random.Range(1, 4);
            //Sets the random blade material based on a random range between 1 and materialGen
            randomblademat = Random.Range(1, materialGen);
            //Sets the random guard material based on a random range between 1 and materialGen
            randomguardmat = Random.Range(1, materialGen);
            //Sets the random handle material based on a random range between 1 and materialGen
            randomhandlemat = Random.Range(1, materialGen);
            //Sets a random greetubg based in a rabdin range between 1 and the length of the greeting sentence
            randomgreeting = Random.Range(1, dialogueManager.greetingSentences.Length);
            //Sets the blade type based on the random type
            dialogue.bladeType = (Sword.SwordType)randomtype;
            //Sets the blade material based on the random blade material
            dialogue.bladeMaterial = (Sword.MaterialBlade)randomblademat;
            //Sets the guard material based on the random guard material
            dialogue.guardMaterial = (Sword.MaterialGuard)randomguardmat;
            //Sets the handle material based on the random handle material
            dialogue.handleMaterial = (Sword.MaterialHandle)randomhandlemat;  
            //Runs the price function
            Price();
            //Sets the first sentence
            dialogue.sentences[0] = "Hello";
            //Sets the second sentence
            dialogue.sentences[1] = dialogueManager.greetingSentences[randomgreeting] + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with " 
            + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
            //Sets the third sentences
            dialogue.sentences[2] = "Good bye";
        }
        else if(tutorial == true)
        {
            //Sets a random greetubg based in a rabdin range between 1 and the length of the greeting sentence
            randomgreeting = Random.Range(1, dialogueManager.greetingSentences.Length);
            //Runs the price function
            Price();
            //Sets the first sentence
            dialogue.sentences[0] = "Hello";
            //Sets the second sentence
            dialogue.sentences[1] = dialogueManager.greetingSentences[randomgreeting] + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with "
            + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
            //Sets the third sentences
            dialogue.sentences[2] = "Good bye";
        }
    }

    public void Price()
    {
        //Runs the sword type check function
        SwordTypeCheck();
        //Runs the blade material function
        BladeMatCheck();
        //Runs the handle material check function
        HandleMatCheck();
        //Runs the guard material check function
        GuardMatCheck();
        //Does an equation to find the cost to make the sword
        costToMake = (bladeIngot * bladeIngotCost) + (1 * handleIngotCost) + (1 * guardIngotCost) + (4 * coalCost);
    }

    public void Tip()
    {
        //Does an equation to find the cost of the sword
        cost = (int)(costToMake + (((quality / 100) - 0.5) * costToMake) + 10);
    }

    void SwordTypeCheck()
    {
        //Checks if the blade is a small blade
        if (dialogue.bladeType == (Sword.SwordType)1)
        {
            //Sents the blade ingot to 1
            bladeIngot = 1;
        }
        //Checks if the blade is a medium blade
        else if (dialogue.bladeType == (Sword.SwordType)2)
        {
            //Sents the blade ingot to 2
            bladeIngot = 2;
        }
        //Checks if the blade is a large blade
        else if (dialogue.bladeType == (Sword.SwordType)3)
        {
            //Sents the blade ingot to 3
            bladeIngot = 3;
        }
    }

    void BladeMatCheck()
    {
        //Checks if the blade is a iron blade
        if (dialogue.bladeMaterial == (Sword.MaterialBlade)2)
        {
            //Sets the bladeIngotcost to the ironcost
            bladeIngotCost = ironCost;
        }
        //Checks if the blade is a steel blade
        else if (dialogue.bladeMaterial == (Sword.MaterialBlade)3)
        {
            //Sets the bladeIngotcost to the steelCost
            bladeIngotCost = steelCost;
        }
        //Checks if the blade is a bronze blade
        else if (dialogue.bladeMaterial == (Sword.MaterialBlade)1)
        {
            //Sets the bladeIngotcost to the bronzeCost
            bladeIngotCost = bronzeCost;
        }
    }

    void GuardMatCheck()
    {
        //Checks if the guard is a iron guard
        if (dialogue.guardMaterial == (Sword.MaterialGuard)2)
        {
            //Sets the guardIngotCost to the ironcost
            guardIngotCost = ironCost;
        }
        //Checks if the guard is a iron guard
        else if (dialogue.guardMaterial == (Sword.MaterialGuard)3)
        {
            //Sets the guardIngotCost to the steelCost
            guardIngotCost = steelCost;
        }
        //Checks if the guard is a iron guard
        else if (dialogue.guardMaterial == (Sword.MaterialGuard)1)
        {
            //Sets the guardIngotCost to the bronzeCost
            guardIngotCost = bronzeCost;
        }
    }

    void HandleMatCheck()
    {
        //Checks if the handle is a iron handle
        if (dialogue.handleMaterial == (Sword.MaterialHandle)2)
        {
            //Sets the handleIngotCost to the ironcost
            handleIngotCost = ironCost;
        }
        //Checks if the handle is a steel handle
        else if (dialogue.handleMaterial == (Sword.MaterialHandle)3)
        {
            //Sets the handleIngotCost to the steelCost
            handleIngotCost = steelCost;
        }
        //Checks if the handle is a bronze handle
        else if (dialogue.handleMaterial == (Sword.MaterialHandle)1)
        {
            //Sets the handleIngotCost to the bronzeCost
            handleIngotCost = bronzeCost;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the distance between the gameObject and the player
        dist = Vector3.Distance(gameObject.transform.position, playerStats.gameObject.transform.position);
        //Checks if the distance is less than or equal to 3.2
        if(dist <= 3.2)
        {
            //Sets the bool inRange to true
            inRange = true;
        }
        else
        {
            //Sets the bool inRange to false
            inRange = false;
        }
        //Checks if the bool delayCustomer is true
        if(delayCustomer == true)
        {
            //Decreases delayInteraction by one each frame
            delayInteraction--;
        }
        //Checks if the bool delayAi is true
        if(delayAi == true)
        {
            //Decreases delayAiInteraction by one each frame
            delayAiInteraction--;
        }
        //Checks if the bool inRange is true
        if(inRange == true)
        {
            //Checks if the dialogueDoneforDay is false
            if (dialogueDoneforDay == false)
            {
                //Checks if space is pressed down and dialogueStart is false
                if (Input.GetKeyDown(KeyCode.Space) && dialogueStart == false)
                {
                    //Runs the function trigger Dialogue
                    TriggerDialogue();
                    //Sets the customer Number based on the playerStats customerOrderNumber
                    CustomerNumber = playerStats.CustomerOrderNumber;
                    //Increases the playerStats customerOrderNumber by one
                    playerStats.CustomerOrderNumber++;
                    //Sets the bool inDialogue based on the dialogueManager inchat bool
                    inDialogue = dialogueManager.inChat;
                    //Sets the bool dialogueStart to true
                    dialogueStart = true;
                }
                //Checks if the space is pressed down
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Runs the DisplayNextSentence function
                    dialogueManager.DisplayNextSentence();
                    //Sets the bool inDialogue based on the dialogueManager inchat bool
                    inDialogue = dialogueManager.inChat;
                    //Checks if the bool inDialogue is false
                    if (inDialogue == false)
                    {
                        //Checks if the text index in the tutorial script is equal to 1
                        if (tut.textPos == 1)
                        {
                            //Runs the function Progress tutorial in the tutorial script to index 1
                            tut.ProgressTutorial(1);
                        }
                        //Runs the WaypointUpdate function
                        WaypointUpdate();
                        //Runs the setSlotWayPoint function
                        customerAI.setSlotWayPoint();
                        //Checks if the waypoint1Slot is equal to 1
                        if(customerAI.waypoint1Slot == 1)
                        {
                            //Sets the first waypoint array at index 0 to empty
                            customerAI.waypointManager.waypoint1_1 = "Empty";
                        }
                        //Runs the waypoint1Empty function
                        customerAI.waypointManager.Waypoint1Empty();
                        //Sets the bool dialogueDoneforDay to true
                        dialogueDoneforDay = true;
                        //Sets the bool dialogueStart to false
                        dialogueStart = false;
                        //Runs the SetItemSlot function
                        SetItemSlot();
                        return;
                    }
                }
                else
                {
                    //return;
                }
            }
            else
            {
                return;
            }
        }
        //Checks if the waypointIndex is equal to 4
        if (customerAI.waypointIndex == 4)
        {
            //Runs the EndDialogue function
            dialogueManager.EndDialogue();
        }

    }


    public void SetItemSlot()
    {
        //A for loop which uses i based on the slot's length
        for (int i = 0; i < slots.Length; i++)
        {
            //Checks the customerNumber for each of the slot's slotNumber
            if (CustomerNumber == slots[i].slotNumber)
            {
                //Sets the slotNumber as the slots
                SlotNumber = slots[i];
                //Sets the docketText to be the blade
                SlotNumber.docketBlade.text = dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade.";
                //Sets the docketText to be the guard
                SlotNumber.docketGuard.text = dialogue.guardMaterial.ToString() + " guard ";
                //Sets the docketText to be the handle
                SlotNumber.docketHandle.text = dialogue.handleMaterial.ToString() + " handle";
            }
        }
    }

    public void CheckItemSlot()
    {
        //A for loop which uses i based on the slot's length
        for (int i = 0; i < slots.Length; i++)
        {
            //Checks the customerNumber for each of the slot's slotNumber
            if (CustomerNumber == slots[i].slotNumber)
            {
                //Runs the function CheckItem
                CheckItem();
            }
        }
    }

    public void CheckItem()
    {
        //Checks if the slot's bladeType is the same as the dialogue's bladetype and
        // slot's bladeMaterial is the same as the dialogue's bladeMaterial and
        // slot's guardMaterial is the same as the dialogue's guardMaterial and
        // slot's handleMaterial is the same as the dialogue's handleMaterial
        if (SlotNumber.bladeType == dialogue.bladeType && SlotNumber.bladeMaterial == dialogue.bladeMaterial &&
            SlotNumber.guardMaterial == dialogue.guardMaterial && SlotNumber.handleMaterial == dialogue.handleMaterial)
        {
            //Checks if the bool delayCustomer is equal to false
            if (delayCustomer == false)
            {
                //Sets the delayCustomer to true
                delayCustomer = true;
            }
            //Checks if the bool delayAi is equal to false and delayInteraction is less than or equal to 0
            if (delayAi == false && delayInteraction <= 0)
            {
                //Sets the delayAi to true
                delayAi = true;
            }
            //Checks if the delayInteraction is greater than 0
            if (delayInteraction > 0)
            {
                return;
            }
            else
            {
                //Checks if the delayAiInteraction is greater than 0
                if (delayAiInteraction > 0)
                {
                    return;
                }
                else
                {
                    //Increases the waypointIndex by one
                    customerAI.waypointIndex++;
                }
                //Sets bool delayCustomer to false
                delayCustomer = false;
                //CHecks if the bool delayCustomer is equal to false
                if (delayCustomer == false)
                {
                    //Checks if image is greater than 0
                    if (image > 0)
                    {
                        return;
                    }
                    else
                    {
                        //Sets image to 1
                        image = 1;
                        //Sets the quality to be the slotnumber's quality
                        quality = SlotNumber.quality;
                        //Runs the tip functions
                        Tip();
                        //Adds the cost of the sword to the player's gold
                        playerStats.gold += cost;
                        //Plays audio source
                        coinGain.Play();
                        //Runs the ShowFloatingText function
                        ShowFloatingText();
                        //Runs the Banter function
                        Banter();
                        //Destory the slot's sword gameObjecy
                        Destroy(SlotNumber.sword);
                        //Sets the text to blank
                        SlotNumber.docketBlade.text = "";
                        //Sets the text to blank
                        SlotNumber.docketGuard.text = "";
                        //Sets the text to blank
                        SlotNumber.docketHandle.text = "";

                    }

                }

            }
        }
        else
        {
            //Sets the sword position to a badLocation's position
            SlotNumber.sword.transform.position = SlotNumber.badlocation.position;
        }
    }

    public void ShowFloatingText()
    {
        //Creates an Image GameObject 
        GameObject var = Instantiate(floatingImage, imagePosition.position, Quaternion.identity, transform);
        //Checks if the quality is greater than 0 and less than 25
        if (quality >= 0 && quality < 25)
        {
            //Sets the sprite on the spriteReneder to a badEmo sprite
            var.GetComponent<SpriteRenderer>().sprite = badEmo;
            //Sets the randomBadText int based on a range between 1 and the badQualitySentences's length
            randombadtext = Random.Range(1, dialogueManager.badQualitySentences.Length);
            //Sets the sentence in the 4 index to the badQualitySentences from randomBadText int
            dialogue.sentences[4] = dialogueManager.badQualitySentences[randombadtext];

        }
        else if (quality >= 25 && quality < 75)
        {
            //Sets the sprite on the spriteReneder to a neutralEmo sprite
            var.GetComponent<SpriteRenderer>().sprite = neutralEmo;
            //Sets the randomneturaltext int based on a range between 1 and the neturalQualitySentences's length
            randomneturaltext = Random.Range(1, dialogueManager.neturalQualitySentences.Length);
            //Sets the sentence in the 4 index to the neturalQualitySentences from randomneturaltext int
            dialogue.sentences[4] = dialogueManager.neturalQualitySentences[randomneturaltext];


        }
        else if (quality >= 75 && quality <= 100)
        {
            //Sets the sprite on the spriteReneder to a goodEmo sprite
            var.GetComponent<SpriteRenderer>().sprite = goodEmo;
            //Sets the randomgoodtext int based on a range between 1 and the bestQualitySentences's length
            randomgoodtext = Random.Range(1, dialogueManager.bestQualitySentences.Length);
            //Sets the sentence in the 4 index to the bestQualitySentences from randomgoodtext int
            dialogue.sentences[4] = dialogueManager.bestQualitySentences[randomgoodtext];


        }
    }

    public void Banter()
    {
        //Runs the function banterDialogue with the variable dialogue and 4
        dialogueManager.BanterDialogue(dialogue, 4);
    }

    public void TriggerDialogue()
    {
        //Runs the function startDialogue with the variable dialogue
         dialogueManager.StartDialogue(dialogue);
    }

    public void WaypointUpdate()
    {
        //Checks if the waypoint index is equal to 3
        if (customerAI.waypointIndex == 3)
        {
            //Runs the CheckItem function
            CheckItem();
        }             
        else
        {
            //Increases waypointIndex by 1
            customerAI.waypointIndex++;
        }
    }

}

