using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smorge : MonoBehaviour
{
    public Furnace furance;
    public Furnace furance2;
    public Smelter smelter;
    public float time;
    public float timeDecrease;
    public float timeIncrease;
    public string objectName;
    public bool smorgeOn = false;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        objectName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            smorgeOn = true;
            furance.smorgeOn = smorgeOn;
            furance2.smorgeOn = smorgeOn;

            smelter.smorgeOn = smorgeOn;
            if (smorgeOn == true)
            {
                this.gameObject.name = objectName + " (Ready)";
            }
            time -= timeDecrease * Time.deltaTime;
        }
        else
        {
            smorgeOn = false;
            furance.smorgeOn = smorgeOn;
            furance2.smorgeOn = smorgeOn;

            smelter.smorgeOn = smorgeOn;
            if (smorgeOn == false)
            {
                this.gameObject.name = objectName + " (Not Ready)";
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Ore")
        {
            if(other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.coal)
            {
                other.gameObject.GetComponent<Ore>().smorge = this;
                other.gameObject.GetComponent<Ore>().timeToDestroy = timeIncrease;
                other.gameObject.GetComponent<Ore>().timeDecrease = timeDecrease;
                time += timeIncrease;
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
