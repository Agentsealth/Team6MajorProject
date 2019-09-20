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

    public static string ingotplace1 = "empty";
    public static string ingotplace2 = "empty";
    public static string ingotplace3 = "empty";
    public static string ingotplace4 = "empty";
    public static string ingotplace5 = "empty";
    public static string ingotplace6 = "empty";

    public static string sheetplace1 = "empty";

    public int ingotPlace;
    public int sheetPlace;

    public Transform[] ingotplace;
    public Transform sheetplace;
    public Transform badplace;

    public bool smorgeOn = false;

    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        tut = FindObjectOfType<Tutorial>();
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
                    if (tut.textPos == 10)
                    {
                        tut.CanvasToggleOn();

                    }
                    tut.TutorialNextStep(10);
                    other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.GetComponent<Ingot>().smeltTime = ironHeat;
                    other.gameObject.GetComponent<Ingot>().furance = this;
                    
                    if (ingotplace1 == "empty")
                    {
                        other.transform.position = ingotplace[0].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 1;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace1 = "full";
                    }
                    else if (ingotplace2 == "empty")
                    {
                        other.transform.position = ingotplace[1].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 2;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace2 = "full";
                    }
                    else if (ingotplace3 == "empty")
                    {
                        other.transform.position = ingotplace[2].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 3;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace3 = "full";
                    }
                    else if (ingotplace4 == "empty")
                    {
                        other.transform.position = ingotplace[3].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 4;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace4 = "full";
                    }
                    else if (ingotplace5 == "empty")
                    {
                        other.transform.position = ingotplace[4].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 5;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace5 = "full";
                    }
                    else if (ingotplace6 == "empty")
                    {
                        other.transform.position = ingotplace[5].transform.position;
                        other.gameObject.GetComponent<Ingot>().place = 6;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        ingotplace6 = "full";
                    }
                }
                else
                {
                    other.transform.position = badplace.transform.position;
                    return;
                }
            }
            else if (other.gameObject.tag == "Iron Sheet")
            {
                if (other.gameObject.GetComponent<Sheet>().ready == false)
                {
                    other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.GetComponent<Sheet>().smeltTime = ironHeat;
                    other.gameObject.GetComponent<Sheet>().furance = this;

                    if (sheetplace1 == "empty")
                    {
                        other.transform.position = sheetplace.transform.position;
                        other.gameObject.GetComponent<Sheet>().place = 1;
                        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                        sheetplace1 = "full";
                    }
                }
                else
                {
                    other.transform.position = badplace.transform.position;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
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

    public void SheetEmpty()
    {
        if (sheetPlace == 1)
        {
            sheetplace1 = "empty";
        }
    }

    public void Empty()
    {
        if (ingotPlace == 1)
        {
            ingotplace1 = "empty";
        }
        else if (ingotPlace == 2)
        {
            ingotplace2 = "empty";
        }
        else if (ingotPlace == 3)
        {
            ingotplace3 = "empty";
        }
        else if (ingotPlace == 4)
        {
            ingotplace4 = "empty";
        }
        else if (ingotPlace == 5)
        {
            ingotplace5 = "empty";
        }
        else if (ingotPlace == 6)
        {
            ingotplace6 = "empty";
        }
    }

}
