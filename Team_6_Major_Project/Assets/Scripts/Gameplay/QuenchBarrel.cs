﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchBarrel : MonoBehaviour
{
    private string objectName;
    private Furnace furnace;
    public GameObject smokeP;
    public AudioSource audioSource;
    private GameObject smokeGO;
    public GameObject Parent;
    public Transform drop;
    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.FindObjectOfType<Furnace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet" ||
                   cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ingot")
            {
                help(Parent.transform.GetChild(0));

            }
        }
        else
        {
            return;
        }
    }

    public void help(Transform other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));

                other.position = drop.position;
                other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                StartCoroutine(CoolIngot(other.gameObject));

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
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                other.position = drop.position;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));


                other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                StartCoroutine(CoolIngot(other.gameObject));

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
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90,0,0));
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
        yield return new WaitForSeconds(2.5f);
        other.GetComponent<Sheet>().ready = false;
        objectName = other.GetComponent<Sheet>().objectName;

        other.name = objectName + " (Not Ready)";
        yield return new WaitForSeconds(5);


    }

    IEnumerator CoolIngot(GameObject other)
    {
        yield return new WaitForSeconds(2.5f);

        other.GetComponent<Ingot>().ready = false;
        objectName = other.GetComponent<Ingot>().objectName;

        other.name = objectName + " (Not Ready)";
        yield return new WaitForSeconds(5);
       
    }
}

