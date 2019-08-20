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
         if (goalType == GoalType.Ore)
         {
             currentAmount++;
         }
            if (goalType == GoalType.Guard)
            {
                currentAmount++;
            }
            if (goalType == GoalType.Handle)
            {
                currentAmount++;
            }
            if (goalType == GoalType.Sheet)
            {
                currentAmount++;
            }
            if (goalType == GoalType.Blade)
            {
                currentAmount++;
            }
    }

    public void SwordCheck()
    {
        if (goalType == GoalType.Sword)
        {
            if (questDrop.swordBladeType == swordBladeType &&
                questDrop.swordBladeMaterial == swordBladeMaterial &&
                questDrop.swordGuardMaterial == swordGuardMaterial &&
                questDrop.swordHandleMaterial == swordHandleMaterial)
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

    }

}
