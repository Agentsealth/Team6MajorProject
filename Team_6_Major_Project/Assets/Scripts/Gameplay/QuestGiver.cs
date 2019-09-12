using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    
    public int easyMaxAmount;
    public int normalMaxAmount;
    public int hardMaxAmount;
    public int minAmount;
    

    public int easyQualityAmount;
    public int normalQualityAmount;
    public int hardQualityAmount;

    public int easyGoldAmount;
    public int normalGoldAmount;
    public int hardGoldAmount;

    public PlayerStats player;

    public QuestGoal goal;

    public GameObject questWindow;

    public Text titleText;
    public Text descriptionText;
    public Text difficultyText;
    public Text goldText;
    public Text amountText;

    public GameObject cancelButton;
    public GameObject acceptButton;
    public GameObject rejectButton;



    public void Start()
    {
        goal = quest.goal;
    }

    public void Update()
    {
        amountText.text = goal.currentAmount + " / " + goal.requiredAmount;
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        if (quest.isActive == false)
        {
            CheckEasy();
            CheckNormal();
            CheckHard();
            quest.title = "Farmer needs " + goal.goalType.ToString();
            titleText.text = quest.title;
            CheckGoalDescription();
            descriptionText.text = quest.description;
            goldText.text = quest.goldReward.ToString();
            difficultyText.text = quest.difficulty.ToString();
            amountText.text = goal.currentAmount + " / " + goal.requiredAmount;
            acceptButton.SetActive(true);
            rejectButton.SetActive(true);
            amountText.gameObject.SetActive(false);
            cancelButton.SetActive(false);
        }
       
    }

    public void AcceptQuest()
    {

        if (quest.isActive == false)
        {

            quest.isActive = true;
            quest.giver = this;
            player.questes.Add(quest);
            quest.title = "Farmer needs " + goal.goalType.ToString();
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            goldText.text = quest.goldReward.ToString();
            difficultyText.text = quest.difficulty.ToString();
            cancelButton.SetActive(true);
            acceptButton.SetActive(false);
            rejectButton.SetActive(false);
            amountText.gameObject.SetActive(true);
            //questWindow.SetActive(false);
            //gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            return;
        }
    }

    public void RejectQuest()
    {
        questWindow.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void CloseQuest()
    {
        questWindow.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void CheckEasy()
    {
        if (quest.difficulty == Quest.Difficulty.Easy)
        {
            goal.maxAmount = easyMaxAmount;
            goal.minAmount = minAmount;
            goal.requiredQuality = easyQualityAmount;
            quest.goldReward = easyGoldAmount;
            goal.goalType = (QuestGoal.GoalType)Random.Range(1, 6);
            goal.requiredAmount = Random.Range(goal.minAmount, goal.maxAmount);
        }
    }

    public void CheckNormal()
    {
        if (quest.difficulty == Quest.Difficulty.Normal)
        {
            goal.maxAmount = normalMaxAmount;
            goal.minAmount = minAmount;
            goal.requiredQuality = normalQualityAmount;
            quest.goldReward = normalGoldAmount;
            goal.goalType = (QuestGoal.GoalType)0;
            goal.requiredAmount = Random.Range(goal.minAmount, goal.maxAmount);
        }
    }
    public void CheckHard()
    {
        if (quest.difficulty == Quest.Difficulty.Hard)
        {
            goal.maxAmount = hardMaxAmount;
            goal.minAmount = minAmount;
            goal.requiredQuality = hardQualityAmount;
            quest.goldReward = hardGoldAmount;
            goal.goalType = (QuestGoal.GoalType)0;
            goal.requiredAmount = Random.Range(goal.minAmount, goal.maxAmount);
        }
    }
    public void CheckGoalDescription()
    {
        if(goal.goalType == QuestGoal.GoalType.Sword)
        {
            goal.swordBladeType = (Sword.SwordType)Random.Range(1, 4);
            goal.swordBladeMaterial = (Sword.MaterialBlade)Random.Range(1, 4);
            goal.swordGuardMaterial = (Sword.MaterialGuard)Random.Range(1, 4);
            goal.swordHandleMaterial = (Sword.MaterialHandle)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.swordBladeType.ToString() + " " 
                + goal.swordBladeMaterial.ToString() + " blade with " + goal.swordGuardMaterial.ToString() + " guard and " 
                + goal.swordHandleMaterial.ToString() + " handle with quality of " + goal.requiredQuality.ToString() + " or higher.";
        }
        else if (goal.goalType == QuestGoal.GoalType.Blade)
        {
            goal.bladeType = (Blade.Typeblade)Random.Range(1, 4);
            goal.bladeMaterial = (Blade.BladeMaterial)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.bladeType.ToString() + " "
                + goal.swordBladeMaterial.ToString() + " blade.";
        }
        else if (goal.goalType == QuestGoal.GoalType.Guard)
        {
            goal.bladeType = (Blade.Typeblade)Random.Range(1, 4);
            goal.bladeMaterial = (Blade.BladeMaterial)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.guardMaterial.ToString() + " "
                + " guard.";
        }
        else if (goal.goalType == QuestGoal.GoalType.Handle)
        {
            goal.bladeType = (Blade.Typeblade)Random.Range(1, 4);
            goal.bladeMaterial = (Blade.BladeMaterial)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.handleMaterial.ToString() + " "
                + " handle.";
        }
        else if (goal.goalType == QuestGoal.GoalType.Ingot)
        {
            goal.bladeType = (Blade.Typeblade)Random.Range(1, 4);
            goal.bladeMaterial = (Blade.BladeMaterial)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.ingotMaterial.ToString() + " "
                 + " ingot.";
        }
        else if (goal.goalType == QuestGoal.GoalType.Sheet)
        {
            goal.bladeType = (Blade.Typeblade)Random.Range(1, 4);
            goal.bladeMaterial = (Blade.BladeMaterial)Random.Range(1, 4);
            quest.description = "A farmer near the northpart of town requires " + goal.requiredAmount.ToString() + " " + goal.sheetType.ToString() + " "
                + goal.sheetMaterial.ToString() + " sheet.";
        }
    }
}
