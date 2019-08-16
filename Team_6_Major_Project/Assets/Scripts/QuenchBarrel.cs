using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchBarrel : MonoBehaviour
{
    private string objectName;
    private Furnace furnace;
    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.FindObjectOfType<Furnace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                other.gameObject.GetComponent<Ingot>().ready = false;
                objectName = other.GetComponent<Ingot>().objectName;

                other.gameObject.name = objectName + " (NotReady)";
            }
            else
            {
                return;
            }
        }
        else if (other.gameObject.tag == "Iron Sheet")
        {
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                StartCoroutine(CoolSheet(other.gameObject));
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

    IEnumerator CoolSheet(GameObject other)
    {
        yield return new WaitForSeconds(2);
        other.GetComponent<Sheet>().ready = false;
        objectName = other.GetComponent<Sheet>().objectName;

        other.name = objectName + " (Not Ready)";
    }

    IEnumerator CoolIngot(GameObject other)
    {
        yield return new WaitForSeconds(2);
        other.GetComponent<Sheet>().ready = false;
        objectName = other.GetComponent<Sheet>().objectName;

        other.name = objectName + " (Not Ready)";
    }
}

