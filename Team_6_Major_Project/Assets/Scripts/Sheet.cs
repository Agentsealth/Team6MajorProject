using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{
    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public int quality;
    public PickUp sheetPickup;
    // Start is called before the first frame update
    void Start()
    {
        sheetPickup = this.gameObject.GetComponent<PickUp>();
        objectName = this.gameObject.name;
        if (ready == false)
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
            sheetPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
            }
        }
    }
}
