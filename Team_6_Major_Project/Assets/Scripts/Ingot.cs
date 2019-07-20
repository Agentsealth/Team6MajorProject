using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingot : MonoBehaviour
{
    public enum Material { iron, silver, gold };

    public Material material;

    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public PickUp ingotPickup;
    // Start is called before the first frame update
    void Start()
    {
        ingotPickup = this.gameObject.GetComponent<PickUp>();
        objectName = this.gameObject.name;
        if(ready == false)
        {
            this.gameObject.name = objectName + " (Not Ready)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Smelt();
    }

    void Smelt()
    {
        if (smeltTime > 0)
        {
            ingotPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
            }
        }        
    }
}
