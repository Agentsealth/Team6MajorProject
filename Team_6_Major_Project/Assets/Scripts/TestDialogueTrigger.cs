using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueTrigger : MonoBehaviour
{
    public bool inRange = false;
    public Dialogue dialogue;
    public DialogueManager dialogueManager;
    public int gold;
    public PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        inRange = true;
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerStats = FindObjectOfType<PlayerStats>();
        dialogue.sentences[3] = "I would like to order a " + dialogue.bladeType.ToString() + " " + dialogue.bladeMaterial.ToString() + " blade with " + dialogue.guardMaterial.ToString() + " guard " + dialogue.handleMaterial.ToString() + " handle";
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange == true)
        {
            if(Input.GetKeyDown("e"))
            {
                TriggerDialogue();
            }
            else if(Input.GetKeyDown("f"))
            {
                dialogueManager.DisplayNextSentence();
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
                            Destroy(other);
                        }
                    }
                }
            }
        }
    }
}
