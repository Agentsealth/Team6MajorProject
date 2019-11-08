using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int ironCost;
    public int bronzeCost;
    public int steelCost;
    public int coalCost;

    public Text ironCostText;
    public Text bronzeCostText;
    public Text steelCostText;
    public Text coalCostText;

    public PlayerStats playerStats;

    public GameObject ore;

    public Transform drop;


    public Tutorial tut;
    public GameObject player;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        ironCostText.text = "Iron Ore (" + ironCost + ")";
        bronzeCostText.text = "Bronze Ore (" + bronzeCost + ")";
        steelCostText.text = "Steel Ore (" + steelCost + ")";
        coalCostText.text = "Coal (" + coalCost + ")";
        tut = FindObjectOfType<Tutorial>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (dist < 3 && hasRun == false)
        {
            if(tut.textPos == 3 || tut.textPos == 2)
            {
                tut.ProgressTutorial(3);
            }
        }
    }

    //Function used to buy Iron Chucks
    public void BuyIron()
    {
        if(playerStats.gold >= ironCost)
        {
            playerStats.gold -= ironCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.iron;
            Instantiate(ore, drop.position, Quaternion.identity);
        }
    }
    //Function used to buy Bronze Chucks
    public void BuyBronze()
    {
        if (playerStats.gold >= bronzeCost)
        {
            playerStats.gold -= bronzeCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.bronze;
            Instantiate(ore, drop.position, Quaternion.identity);

        }
    }
    //Function used to buy Steel Chucks
    public void BuySteel()
    {
        if (playerStats.gold >= steelCost)
        {
            playerStats.gold -= steelCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.steel;
            Instantiate(ore, drop.position, Quaternion.identity);

        }
    }
    //Function used to buy Coal Chucks
    public void BuyCoal()
    {
        if (playerStats.gold >= coalCost)
        {
            playerStats.gold -= coalCost;
            ore.GetComponent<Ore>().material = Ore.OreMaterial.coal;
            Instantiate(ore, drop.position, Quaternion.identity);

        }
    }

}
