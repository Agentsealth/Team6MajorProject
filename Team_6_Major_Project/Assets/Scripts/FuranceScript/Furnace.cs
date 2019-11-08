using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
{
    public int ironHeat;

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

    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the tutorial variable
        tut = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        //When mouse is hovering over the gameobject and player presses F
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Sets the int value of cCount based of the player's hand child count
            int cCount = Parent.transform.childCount;
            //Checks if cCount is greater than 0 checks if the player's hand child's tag is either a Iron Sheet or Iron ingot
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ingot")
            {
                //Snapping of the gameobjec to a position on the anvil
                Snapping(Parent.transform.GetChild(0));

            }
            else
            {
                return;
            }

        }
    }
    public void Snapping(Transform other)
    {
        //Checks if the bool smorgeOn is true
        if (smorgeOn == true)
        {
            //Checks if the gameObject tag is an Iron Ingot
            if (other.gameObject.tag == "Iron Ingot")
            {
                //Checks if the gameobject has been heated (true)
                if (other.gameObject.GetComponent<Ingot>().ready == false)
                {
                    //Checks if the textIndex for the tutorial is either 8 or 9
                    if (tut.textPos == 9 || tut.textPos == 8)
                    {
                        //Runs the function Progress tutorial in the tutorial script to index 9
                        tut.ProgressTutorial(9);
                    }
                    //Runs the kinematicOffIngot function
                    kinematicOffIngot(other);
                    //Checks if ingotplace 1 is empty
                    if (ingotplace1 == "empty")
                    {
                        //Runs the snappingIngot function at index 0
                        snappingIngot(other, 0);
                    }
                    //Checks if ingotplace 2 is empty
                    else if (ingotplace2 == "empty")
                    {
                        //Runs the snappingIngot function at index 1
                        snappingIngot(other, 1);
                    }
                    //Checks if ingotplace 3 is empty
                    else if (ingotplace3 == "empty")
                    {
                        //Runs the snappingIngot function at index 2
                        snappingIngot(other, 2);
                    }
                    //Checks if ingotplace 4 is empty
                    else if (ingotplace4 == "empty")
                    {
                        //Runs the snappingIngot function at index 3
                        snappingIngot(other, 3);
                    }
                    //Checks if ingotplace 5 is empty
                    else if (ingotplace5 == "empty")
                    {
                        //Runs the snappingIngot function at index 4
                        snappingIngot(other, 4);
                    }
                    //Checks if ingotplace 6 is empty
                    else if (ingotplace6 == "empty")
                    {
                        //Runs the snappingIngot function at index 5
                        snappingIngot(other, 5);
                    }
                }
                else
                {
                    //Sets the positon of the gameobject to the badplace's position
                    other.transform.position = badplace.transform.position;
                    return;
                }
            }
            //Checks if the gameObject tag is an Iron Sheet
            else if (other.gameObject.tag == "Iron Sheet")
            {
                //Checks if the gameobject has been heated (true)
                if (other.gameObject.GetComponent<Sheet>().ready == false)
                {
                    //Checks if the textIndex for the tutorial is either 12 or 13
                    if (tut.textPos == 13 || tut.textPos == 12)
                    {
                        //Runs the function Progress tutorial in the tutorial script to index 13
                        tut.ProgressTutorial(13);
                        //Runs the function Progress tutorial in the tutorial script to index 13
                        tut.ProgressTutorial(13);

                    }
                    //Checks if the textIndex for the tutorial is either 16 or 17
                    if (tut.textPos == 17 || tut.textPos == 16)
                    {
                        //Runs the function Progress tutorial in the tutorial script to index 17
                        tut.ProgressTutorial(17);
                        //Runs the function Progress tutorial in the tutorial script to index 17
                        tut.ProgressTutorial(17);

                    }
                    //Runs the kinematicOffSheet function
                    kinematicOffSheet(other);
                    //Checks if sheetplace1 1 is empty
                    if (sheetplace1 == "empty")
                    {
                        //Runs the snappingIngot function at index 6
                        snappingIngot(other, 6);
                    }
                }
                else
                {
                    //Sets the positon of the gameobject to the badplace's position
                    other.transform.position = badplace.transform.position;
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

    private void kinematicOffIngot(Transform other)
    {
        //Sets the isholding bool to false
        other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
        //Sets the isKinematic bool to true
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //Sets the smeltTime to the ironHeat
        other.gameObject.GetComponent<Ingot>().smeltTime = ironHeat;
        //Sets the furance to this gameObject
        other.gameObject.GetComponent<Ingot>().furance = this;
    }

    private void kinematicOffSheet(Transform other)
    {
        //Sets the isholding bool to false
        other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
        //Sets the isKinematic bool to true
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //Sets the smeltTime to the ironHeat
        other.gameObject.GetComponent<Sheet>().smeltTime = ironHeat;
        //Sets the furance to this gameObject
        other.gameObject.GetComponent<Sheet>().furance = this;
    }

    private void snappingIngot(Transform other, int index)
    {
        //Sets the gameObject's position to the ingotplaceArray at index's position
        other.transform.position = ingotplace[index].transform.position;
        //Sets the place  based on the index + 1
        other.gameObject.GetComponent<Ingot>().place = index + 1;
        //Sets the gameObject's eulerangle a new Vector 3 angles based on the x rotation by 180
        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
        //Checks if index is equal to 0
        if (index == 0)
        {
            //sets ingotplace1 to full
            ingotplace1 = "full";
        }
        //Checks if index is equal to 1
        else if (index == 1)
        {
            //sets ingotplace2 to full
            ingotplace2 = "full";
        }
        //Checks if index is equal to 2
        else if (index == 2)
        {
            //sets ingotplace3 to full
            ingotplace3 = "full";
        }
        //Checks if index is equal to 3
        else if (index == 3)
        {
            //sets ingotplace4 to full
            ingotplace4 = "full";
        }
        //Checks if index is equal to 4
        else if (index == 4)
        {
            //sets ingotplace5 to full
            ingotplace5 = "full";
        }
        //Checks if index is equal to 5
        else if (index == 5)
        {
            //sets ingotplace6 to full
            ingotplace6 = "full";
        }
        //Checks if index is equal to 6
        else if (index == 6)
        {
            //Sets the gameObject's position to the sheetplace's position
            other.transform.position = sheetplace.transform.position;
            //Sets the place based on 1 
            other.gameObject.GetComponent<Sheet>().place = 1;
            //Sets the gameObject's eulerangle a new Vector 3 angles based on the x rotation by 180
            other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
            other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
            //sets sheetplace1 to full
            sheetplace1 = "full";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Runs the snapping function
        Snapping(other.gameObject.transform);
    }

    public void SheetEmpty()
    {
        //Checks if sheetplace is equal to 1
        if (sheetPlace == 1)
        {
            //sets sheetplace1 to empty
            sheetplace1 = "empty";
        }
    }

    public void Empty()
    {
        //Checks if ingotPlace is equal to 1
        if (ingotPlace == 1)
        {
            //sets ingotplace1 to empty
            ingotplace1 = "empty";
        }
        //Checks if ingotPlace is equal to 2
        else if (ingotPlace == 2)
        {
            //sets ingotplace2 to empty
            ingotplace2 = "empty";
        }
        //Checks if ingotPlace is equal to 3
        else if (ingotPlace == 3)
        {
            //sets ingotplace3 to empty
            ingotplace3 = "empty";
        }
        //Checks if ingotPlace is equal to 4
        else if (ingotPlace == 4)
        {
            //sets ingotplace4 to empty
            ingotplace4 = "empty";
        }
        //Checks if ingotPlace is equal to 5
        else if (ingotPlace == 5)
        {
            //sets ingotplace5 to empty
            ingotplace5 = "empty";
        }
        //Checks if ingotPlace is equal to 6
        else if (ingotPlace == 6)
        {
            //sets ingotplace6 to empty
            ingotplace6 = "empty";
        }
    }

}
