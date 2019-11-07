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
        dist = Vector3.Distance(gameObject.transform.position, playerStats.gameObject.transform.position);
        if(dist <= 3.2)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if(delayCustomer == true)
        {
            delayInteraction--;
        }

        if(delayAi == true)
        {
            delayAiInteraction--;
        }

        if(inRange == true)
        {
            if (dialogueDoneforDay == false)
            {
                if (Input.GetKeyDown(KeyCode.Space) && dialogueStart == false)
                {
                    TriggerDialogue();                   
                    CustomerNumber = playerStats.CustomerOrderNumber;
                    playerStats.CustomerOrderNumber++;
                    inDialogue = dialogueManager.inChat;
                    dialogueStart = true;
                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    dialogueManager.DisplayNextSentence();
                    inDialogue = dialogueManager.inChat;
                    if (inDialogue == false)
                    {
                        if (tut.textPos == 1)
                        {
                            tut.ProgressTutorial(1);

                        }

                        WaypointUpdate();
                        customerAI.setSlotWayPoint();
                        if(customerAI.waypoint1Slot == 1)
                        {
                            customerAI.waypointManager.waypoint1_1 = "Empty";
                        }
                        customerAI.waypointManager.Waypoint1Empty();
                        //Waypoint slot is empty
                        dialogueDoneforDay = true;
                        dialogueStart = false;
                        SetItemSlot();
                        return;
                    }
                }
                else
                {
                    //Waypoint slot is full
                }
            }
            else
            {
                return;
            }
        }

        if (customerAI.waypointIndex == 4)
        {
            dialogueManager.EndDialogue();
        }

    }


    public void SetItemSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (CustomerNumber == slots[i].slotNumber)
            {
                SlotNumber = slots[i];
                SlotNumber.docketBlade.text = dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade.";
                SlotNumber.docketGuard.text = dialogue.guardMaterial.ToString() + " guard ";
                SlotNumber.docketHandle.text = dialogue.handleMaterial.ToString() + " handle";
            }
        }
    }

    public void CheckItemSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (CustomerNumber == slots[i].slotNumber)
            {
                CheckItem();
            }
        }
    }

    public void CheckItem()
    {
        if(SlotNumber.bladeType == dialogue.bladeType)
        {
            if(SlotNumber.bladeMaterial == dialogue.bladeMaterial)
            {
                if(SlotNumber.guardMaterial == dialogue.guardMaterial)
                {
                    if(SlotNumber.handleMaterial == dialogue.handleMaterial)
                    {                     
                                              
                            if(delayCustomer == false)
                            {
                                delayCustomer = true;
                            }

                            if (delayAi == false && delayInteraction <= 0)
                            {
                                delayAi = true;
                            }

                            if (delayInteraction > 0)
                            {

                            }
                            else
                            {                               
                                if (delayAiInteraction > 0)
                                {

                                }
                                else
                                {
                                    customerAI.waypointIndex++;
                                }

                                delayCustomer = false;

                                if (delayCustomer == false)
                                {
                                    if(image > 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        image = 1;
                                        quality = SlotNumber.quality;
                                        Tip();
                                        playerStats.gold += cost;
                                        coinGain.Play();
                                        ShowFloatingText();
                                        Banter();                                       
                                        Destroy(SlotNumber.sword);
                                        SlotNumber.docketBlade.text = "";
                                        SlotNumber.docketGuard.text = "";
                                        SlotNumber.docketHandle.text = "";

                                    }
                                        
                                }
                                
                            }                     
                    }
                    else
                    {
                        SlotNumber.sword.transform.position = SlotNumber.badlocation.position;
                    }
                }
                else
                {
                    SlotNumber.sword.transform.position = SlotNumber.badlocation.position;
                }
            }
            else
            {
                SlotNumber.sword.transform.position = SlotNumber.badlocation.position;
            }
        }
        else
        {
            SlotNumber.sword.transform.position = SlotNumber.badlocation.position;
        }
    }

    public void ShowFloatingText()
    {
        GameObject var = Instantiate(floatingImage, imagePosition.position, Quaternion.identity, transform);
        if (quality >= 0 && quality < 25)
        {
            var.GetComponent<SpriteRenderer>().sprite = badEmo;
            randombadtext = Random.Range(1, dialogueManager.badQualitySentences.Length);
            dialogue.sentences[4] = dialogueManager.badQualitySentences[randombadtext];

        }
        else if (quality >= 25 && quality < 75)
        {
            var.GetComponent<SpriteRenderer>().sprite = neutralEmo;
            randomneturaltext = Random.Range(1, dialogueManager.neturalQualitySentences.Length);
            dialogue.sentences[4] = dialogueManager.neturalQualitySentences[randomneturaltext];


        }
        else if (quality >= 75 && quality <= 100)
        {
            var.GetComponent<SpriteRenderer>().sprite = goodEmo;
            randomgoodtext = Random.Range(1, dialogueManager.bestQualitySentences.Length);
            dialogue.sentences[4] = dialogueManager.bestQualitySentences[randomgoodtext];


        }
    }

    public void Banter()
    {
        dialogueManager.BanterDialogue(dialogue, 4);
    }

    public void TriggerDialogue()
    {
         dialogueManager.StartDialogue(dialogue);
    }

    public void WaypointUpdate()
    {
        if (customerAI.waypointIndex == 3)
        {
            CheckItem();
        }             
        else
        {
            customerAI.waypointIndex++;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Iron Sword")
    //    {
    //        Debug.Log(other.ToString());
    //        if(other.gameObject.GetComponent<Sword>().swordType == dialogue.bladeType)
    //        {
    //            if(other.gameObject.GetComponent<Sword>().materialBlade == dialogue.bladeMaterial)
    //            {
    //                if (other.gameObject.GetComponent<Sword>().materialGuard == dialogue.guardMaterial)
    //                {
    //                    if (other.gameObject.GetComponent<Sword>().materialHandle == dialogue.handleMaterial)
    //                    {
    //                        playerStats.gold += gold;
    //                        Destroy(other.gameObject);
    //                        WaypointUpdate();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}

