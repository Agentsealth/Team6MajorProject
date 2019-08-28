using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int gold;
    public int CustomerOrderNumber;
    public Text goldText;
    public List<Quest> questes;
    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Gold Coins: " + gold;

    }

    public void QuestHandIn()
    {
        for (int i = 0; i < questes.Count; i++)
        {
            if(questes[i].isActive)
            {
                questes[i].goal.GoalGiven();
                if(questes[i].goal.IsReached())
                {
                    gold += questes[i].goldReward;
                    questes[i].Complete();                    
                    questes.Remove(questes[i]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold Coins: " + gold;
        if(CustomerOrderNumber > 3)
        {
            CustomerOrderNumber = 1;
        }
    }

}
