using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPointClick : MonoBehaviour
{

    public bool OpenWindow;
    public bool AcceptWindow;
    public bool RejectWindow;
    public bool CancelWindow;
    public QuestGiver quest;
    [Tooltip("This Questgiver is the same as above it only used for the accept/reject button as they start as inactive")]
    public QuestGiver parentQuest;
    // Start is called before the first frame update
    void Start()
    {
        quest = this.gameObject.GetComponent<QuestGiver>();
        if (quest == null)
        {
            parentQuest = this.gameObject.transform.parent.parent.gameObject.GetComponent<QuestGiver>();
        }
        
    }

    public void OnPointerClick()
    {
        if(OpenWindow == true)
        {
            quest.OpenQuestWindow();
        }
        else if(AcceptWindow == true)
        {
            parentQuest.AcceptQuest();   
        }
        else if(RejectWindow == true)
        {
            parentQuest.RejectQuest();
        }
        else if (CancelWindow == true)
        {
            parentQuest.CloseQuest();
        }
        else
        {
            return;
        }
    }

}
