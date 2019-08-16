using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
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

    public bool smorgeOn = false;

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
        if (smorgeOn == true)
        {

            if (other.gameObject.tag == "Iron Ingot")
            {
                if (other.gameObject.GetComponent<Ingot>().ready == false)
                {
                    other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                    other.gameObject.GetComponent<Ingot>().smeltTime = ironHeat;
                }
                else
                {
                    return;
                }
            }
            else if (other.gameObject.tag == "Iron Sheet")
            {
                if (other.gameObject.GetComponent<Sheet>().ready == false)
                {
                    other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                    other.gameObject.GetComponent<Sheet>().smeltTime = ironHeat;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
    
}
