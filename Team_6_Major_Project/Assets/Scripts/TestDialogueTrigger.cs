using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueTrigger : MonoBehaviour
{
    public bool inRange = false;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        inRange = true;
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
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
