using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public int ironOre;
    public int steelOre;
    public int bronzeOre;
    public Transform drop;
    public float time;
    public float smeltTime;

    public GameObject ironIngot;

    public bool smorgeOn = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(smeltTime <= 0)
        {
            smeltTime = time;
        }
        smeltIron();
        smeltSteel();
        smeltBronze();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (smorgeOn == true)
        {
            if (other.gameObject.tag == "Iron Ore")
            {
                if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.iron)
                {
                    ironOre++;
                }
                else if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.steel)
                {
                    steelOre++;
                }
                else if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.bronze)
                {
                    bronzeOre++;
                }
                Destroy(other.gameObject);
            }
        }
        else
        {
            return;
        }
    }

    private void smeltIron()
    {
        if (ironOre > 0)
        {
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject iron = Instantiate(ironIngot, drop.position, Quaternion.identity);
                iron.GetComponent<Ingot>().material = Ingot.IngotMaterial.iron;
                ironOre--;
            }
        }
    }

    private void smeltSteel()
    {
        if (steelOre > 0)
        {
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject steel = Instantiate(ironIngot, drop.position, Quaternion.identity);
                steel.GetComponent<Ingot>().material = Ingot.IngotMaterial.steel;
                steelOre--;
            }
        }
    }

    private void smeltBronze()
    {
        if (bronzeOre > 0)
        {
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject bronze = Instantiate(ironIngot, drop.position, Quaternion.identity);
                bronze.GetComponent<Ingot>().material = Ingot.IngotMaterial.bronze;
                bronzeOre--;
            }
        }
    }
}
