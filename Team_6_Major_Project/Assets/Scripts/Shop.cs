using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int ironCost;
    public int bronzeCost;
    public int steelCost;

    public Text ironCostText;
    public Text bronzeCostText;
    public Text steelCostText;

    public PlayerStats playerStats;

    public GameObject ore;

    public Transform drop;


    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ironCostText.text = "Iron Ore (" + ironCost + ")";
        bronzeCostText.text = "Bronze Ore (" + bronzeCost + ")";
        steelCostText.text = "Steel Ore (" + steelCost + ")";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyIron()
    {
        if(playerStats.gold >= ironCost)
        {
            playerStats.gold -= ironCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.iron;
            Instantiate(ore, drop.position, Quaternion.identity);
        }
    }

    public void BuyBronze()
    {
        if (playerStats.gold >= bronzeCost)
        {
            playerStats.gold -= bronzeCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.bronze;
            Instantiate(ore, drop.position, Quaternion.identity);

        }
    }

    public void BuySteel()
    {
        if (playerStats.gold >= steelCost)
        {
            playerStats.gold -= steelCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.steel;
            Instantiate(ore, drop.position, Quaternion.identity);

        }
    }
}
