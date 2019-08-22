using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum Difficulty { Easy, Normal, Hard };

    public Difficulty difficulty;

    public bool isActive;

    [TextArea(3, 10)]
    public string title;

    [TextArea(3, 10)]
    public string description;

    public int goldReward;

    public QuestGoal goal;

    public QuestGiver giver;

    public void Complete()
    {
        isActive = false;
        giver.questWindow.SetActive(false);
        goal.currentAmount = 0;
        giver.gameObject.GetComponent<BoxCollider>().enabled = true;

    }
   
}
