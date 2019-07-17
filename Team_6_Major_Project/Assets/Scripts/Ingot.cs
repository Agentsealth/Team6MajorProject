using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingot : MonoBehaviour
{
    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public PickUp IngotPickup;
    // Start is called before the first frame update
    void Start()
    {
        IngotPickup = this.gameObject.GetComponent<PickUp>();
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
            IngotPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
            }
        }        
    }
}
