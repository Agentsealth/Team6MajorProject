using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueTrigger : MonoBehaviour
{
    public bool inRange = false;
    public bool inDialogue = false;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public CustomerAI customerAI;
    public int gold;
    public PlayerStats playerStats;
    public float dist;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        customerAI =this.gameObject.GetComponent<CustomerAI>();
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue.sentences[3] = "I would like to order a " + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with " 
            + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, playerStats.gameObject.transform.position);
        if(dist <= 7)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        if(inRange == true)
        {
            if(Input.GetKeyDown("e"))
            {
                TriggerDialogue();
                inDialogue = dialogueManager.inChat;
            }
            else if(Input.GetKeyDown("g"))
            {
                dialogueManager.DisplayNextSentence();
                inDialogue = dialogueManager.inChat;
                if (inDialogue == false)
                {
                    customerAI.waypointIndex++;
                }
            }
        }
    }

    public void TriggerDialogue()
    {
         dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Sword")
        {
            Debug.Log(other.ToString());
            if(other.gameObject.GetComponent<Sword>().swordType == dialogue.bladeType)
            {
                if(other.gameObject.GetComponent<Sword>().materialBlade == dialogue.bladeMaterial)
                {
                    if (other.gameObject.GetComponent<Sword>().materialGuard == dialogue.guardMaterial)
                    {
                        if (other.gameObject.GetComponent<Sword>().materialHandle == dialogue.handleMaterial)
                        {
                            playerStats.gold += gold;
                            Destroy(other.gameObject);
                            customerAI.waypointIndex++;
                        }
                    }
                }
            }
        }
    }
}
