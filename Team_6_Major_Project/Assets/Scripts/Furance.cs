using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furance : MonoBehaviour
{
    public int ironHeat;
    public int silverHeat;
    public int goldHeat;

    public int ironSmallHeat;
    public int ironMediumHeat;
    public int ironLargeHeat;

    public int silverSmallHeat;
    public int silverMediumHeat;
    public int silverLargeHeat;

    public int goldSmallHeat;
    public int goldMediumHeat;
    public int goldLargeHeat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == false)
            {
                other.gameObject.GetComponent<Ingot>().IngotPickup.isHolding = false;
                other.gameObject.GetComponent<Ingot>().smeltTime = ironHeat;
            }
            else
            {
                return;
            }
        }
    }
}
