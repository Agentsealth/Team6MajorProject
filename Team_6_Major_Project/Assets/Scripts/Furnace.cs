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

    [Range(0,100)]
    public float temperture;

    public float tempertureGain;
    public float tempertureLoss;
    public Slider tempertureIndicator;
    // Start is called before the first frame update
    void Start()
    {
        temperture = 100;
        tempertureIndicator.maxValue = 100;
        tempertureIndicator.value = 100;
        tempertureIndicator.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (temperture <= 100 && temperture >= 0)
        {
            TempertureLoss();
        }
        else
        {
            temperture = 0;
            tempertureIndicator.value = temperture;
        }
    }

    void TempertureLoss()
    {
        temperture -= tempertureLoss * Time.deltaTime;
        tempertureIndicator.value = temperture;
    }

    void TempertureGain()
    {
        temperture += tempertureGain * Time.deltaTime;
        tempertureIndicator.value = temperture;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (temperture > 30)
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
