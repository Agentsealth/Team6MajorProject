using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class QuestGoal
{
    public enum GoalType { Sword, Ingot, Ore, Guard, Handle, Blade, Sheet}
    public GoalType goalType;

    public Sword.SwordType swordBladeType;
    public Sword.MaterialBlade swordBladeMaterial;
    public Sword.MaterialGuard swordGuardMaterial;
    public Sword.MaterialHandle swordHandleMaterial;

    public Ingot.IngotMaterial ingotMaterial;

    public Ore.OreMaterial oreMaterial;

    public Guard.GuardMaterial guardMaterial;

    public Handle.HandleMaterial handleMaterial;

    public Blade.Typeblade bladeType;
    public Blade.BladeMaterial bladeMaterial;

    public Sheet.TypeSheet sheetType;
    public Sheet.SheetMaterial sheetMaterial;

    public QuestDropPoint questDrop;

    public int minAmount;
    public int maxAmount;

    public int requiredQuality;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void GoalGiven()
    {
         SwordCheck();
         IngotCheck();
         OreCheck();
         GuardCheck();
         HandleCheck();
         SheetCheck();
         BladeCheck();
    }

    public void SwordCheck()
    {
        if (goalType == GoalType.Sword)
        {
            if (questDrop.swordBladeType == swordBladeType &&
                questDrop.swordBladeMaterial == swordBladeMaterial &&
                questDrop.swordGuardMaterial == swordGuardMaterial &&
                questDrop.swordHandleMaterial == swordHandleMaterial &&
                questDrop.quality >= requiredQuality)
            {

                currentAmount++;
                questDrop.Destroy();
                
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void IngotCheck()
    {
        if (goalType == GoalType.Ingot)
        {
            if (questDrop.ingotMaterial == ingotMaterial)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void OreCheck()
    {
        if (goalType == GoalType.Ore)
        {
            if (questDrop.oreMaterial == oreMaterial)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void GuardCheck()
    {
        if (goalType == GoalType.Guard)
        {
            if (questDrop.guardMaterial == guardMaterial)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void HandleCheck()
    {
        if (goalType == GoalType.Handle)
        {
            if (questDrop.handleMaterial == handleMaterial)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void SheetCheck()
    {
        if (goalType == GoalType.Sheet)
        {
            if (questDrop.sheetMaterial == sheetMaterial && questDrop.sheetType == sheetType)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

    public void BladeCheck()
    {
        if (goalType == GoalType.Blade)
        {
            if (questDrop.bladeMaterial == bladeMaterial && questDrop.bladeType == bladeType)
            {
                currentAmount++;
                questDrop.Destroy();
            }
            else
            {
                questDrop.item.transform.position = questDrop.badlocation.position;
            }
        }
    }

}
