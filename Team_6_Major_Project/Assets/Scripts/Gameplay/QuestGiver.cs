using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerStats player;

    public GameObject questWindow;

    public Text titleText;
    public Text descriptionText;
    public Text difficultyText;
    public Text goldText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
        difficultyText.text = quest.difficulty.ToString();
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.questes.Add(quest);
    }

    public void RejectQuest()
    {
        questWindow.SetActive(false);
    }

    public void CloseQuest()
    {
        questWindow.SetActive(false);
    }
}
