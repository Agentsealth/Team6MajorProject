using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShop : MonoBehaviour
{
    public int enchantingCost;

    public bool upgradedEnchanting = false;

    public Text upgradeEnchantingText;
    public Text upgradeEnchantingButton;

    public PlayerStats player;

    public GameObject enchanting;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        upgradeEnchantingText.text = "Enchanting table (" + enchantingCost + ")";
        enchanting = GameObject.FindGameObjectWithTag("Enchanting");
        enchanting.SetActive(false);

    }
    //Function to buy enchanting table
    public void BuyEnchanting()
    {
        if (player.gold >= enchantingCost && upgradedEnchanting == false)
        {
            player.gold -= enchantingCost;
            enchanting.SetActive(true);
            upgradedEnchanting = true;
            upgradeEnchantingButton.text = "Brought";
        }
    }
    //Loading the enchanting table for loading function
    public void LoadEnchanting()
    {
        if(upgradedEnchanting == true)
        {
            enchanting.SetActive(true);
            upgradeEnchantingButton.text = "Brought";
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
