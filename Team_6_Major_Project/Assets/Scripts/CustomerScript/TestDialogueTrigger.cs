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
        delayInteraction = 200;
        delayAiInteraction = 100;
        dialogueManager = FindObjectOfType<DialogueManager>();
        customerAI =this.gameObject.GetComponent<CustomerAI>();
        playerStats = FindObjectOfType<PlayerStats>();
        slots = FindObjectsOfType<ItemSlot>();
        tut = FindObjectOfType<Tutorial>();

        shop = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Shop>();
        coalCost = shop.coalCost;
        ironCost = shop.ironCost;
        steelCost = shop.steelCost;
        bronzeCost = shop.bronzeCost;
        if (tutorial == false)
        {
            randomtype = Random.Range(1, 4);
            randomblademat = Random.Range(1, materialGen);
            randomguardmat = Random.Range(1, materialGen);
            randomhandlemat = Random.Range(1, materialGen);
            dialogue.bladeType = (Sword.SwordType)randomtype;
            dialogue.bladeMaterial = (Sword.MaterialBlade)randomblademat;
            dialogue.guardMaterial = (Sword.MaterialGuard)randomguardmat;
            dialogue.handleMaterial = (Sword.MaterialHandle)randomhandlemat;         
            Price();
            dialogue.sentences[0] = "Hello";
            dialogue.sentences[1] = "I would like to order a " + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with " 
            + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
            //dialogue.sentences[2] = "I will pay " + (costToMake + 10);
            dialogue.sentences[2] = "Good bye";
        }
        else if(tutorial == true)
        {
            Price();
            dialogue.sentences[0] = "Hello, my name is " + dialogue.npcName;
            dialogue.sentences[1] = "I would like to order a " + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with "
            + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
            //dialogue.sentences[2] = "I will pay " + (costToMake + 10);
            dialogue.sentences[2] = "Good bye";
        }
    }

    public void Price()
    {
        SwordTypeCheck();
        BladeMatCheck();
        HandleMatCheck();
        GuardMatCheck();
        costToMake = (bladeIngot * bladeIngotCost) + (1 * handleIngotCost) + (1 * guardIngotCost) + (4 * coalCost);
    }

    public void Tip()
    {
        cost = (int)(costToMake + (((quality / 100) - 0.5) * costToMake) + 10);
    }

    void SwordTypeCheck()
    {
        if (dialogue.bladeType == (Sword.SwordType)1)
        {
            bladeIngot = 1;
        }
        else if (dialogue.bladeType == (Sword.SwordType)2)
        {
            bladeIngot = 2;
        }
        else if (dialogue.bladeType == (Sword.SwordType)3)
        {
            bladeIngot = 3;
        }
    }

    void BladeMatCheck()
    {
        if (dialogue.bladeMaterial == (Sword.MaterialBlade)2)
        {
            bladeIngotCost = ironCost;
        }
        else if (dialogue.bladeMaterial == (Sword.MaterialBlade)3)
        {
            bladeIngotCost = steelCost;
        }
        else if (dialogue.bladeMaterial == (Sword.MaterialBlade)1)
        {
            bladeIngotCost = bronzeCost;
        }
    }

    void GuardMatCheck()
    {
        if (dialogue.guardMaterial == (Sword.MaterialGuard)2)
        {
            guardIngotCost = ironCost;
        }
        else if (dialogue.guardMaterial == (Sword.MaterialGuard)3)
        {
            guardIngotCost = steelCost;
        }
        else if (dialogue.guardMaterial == (Sword.MaterialGuard)1)
        {
            guardIngotCost = bronzeCost;
        }
    }

    void HandleMatCheck()
    {
        if (dialogue.handleMaterial == (Sword.MaterialHandle)2)
        {
            handleIngotCost = ironCost;
        }
        else if (dialogue.handleMaterial == (Sword.MaterialHandle)3)
        {
            handleIngotCost = steelCost;
        }
        else if (dialogue.handleMaterial == (Sword.MaterialHandle)1)
        {
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
                                quality = SlotNumber.quality;                               
                                Tip();
                                playerStats.gold += cost;
                                coinGain.Play();
                                if (delayAiInteraction > 0)
                                {

                                }
                                else
                                {
                                    customerAI.waypointIndex++;
                                }
                                Destroy(SlotNumber.sword);
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
                                        ShowFloatingText();
                                    }
                                        
                                }
                                SlotNumber.docketBlade.text = "";
                                SlotNumber.docketGuard.text = "";
                                SlotNumber.docketHandle.text = "";
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
        }
        else if (quality >= 25 && quality < 75)
        {
            var.GetComponent<SpriteRenderer>().sprite = neutralEmo;
        }
        else if (quality >= 75 && quality <= 100)
        {
            var.GetComponent<SpriteRenderer>().sprite = goodEmo;
        }
    }

    public void Banter()
    {
        dialogueManager.BanterDialogue(dialogue, 5);
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

