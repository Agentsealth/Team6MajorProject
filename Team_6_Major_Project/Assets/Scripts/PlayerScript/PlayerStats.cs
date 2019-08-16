using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int gold;
    public int CustomerOrderNumber;
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        gold = 500;
        CustomerOrderNumber = 1;
        goldText.text = "Gold Coins: " + gold;
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
