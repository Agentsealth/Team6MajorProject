using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public int ironOre;
    public int goldOre;
    public int silverOre;
    public Transform drop;
    public float time;
    public float smeltTime;

    public GameObject ironIngot;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Ore")
        {
            ironOre++;
            Destroy(other.gameObject);
        }
    }

    private void smeltIron()
    {
        if (ironOre > 0)
        {
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                Instantiate(ironIngot, drop.position, Quaternion.identity);
                ironOre--;
            }
        }
    }

    private void smeltGold()
    {

    }

    private void smeltSilver()
    {

    }
}
