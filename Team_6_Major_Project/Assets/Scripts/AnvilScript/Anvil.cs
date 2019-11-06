using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : MonoBehaviour
{
    public GameObject prompt;
    public PromptScript PS;
    public int ingotCount;
    public int sheetCount;
    public int Quality;
    public int sheetQuality;
    public int time;
    public int Timer;

    public Transform drop;
    public Transform wrongIngotDrop;
    public Transform[] ingotplace;

    public GameObject gameSlider;
    public GameObject hammer;
    public GameObject Parent;
    //public GameObject options;
    public GameObject axe;


    public bool usingSlider = false;
    public bool isHammering;
    public bool selected;
    public bool buttonSelected;
    public bool resetValue;
    public bool isSwordBlade;
    public bool isAxeBlade;
    public bool canHammer;

    public List<GameObject> ingots = new List<GameObject>();
    public List<GameObject> sheet = new List<GameObject>();

    public GameObject[] sheets;
    public GameObject[] blades;
    public GameObject[] crit;

    private MoveToPos MTP;

    public GameObject warning;

    public static string ingotplace1 = "empty";
    public static string ingotplace2 = "empty";
    public static string ingotplace3 = "empty";

    private Vector3 hammerOriginalPos;

    public AudioSource placeDown;

    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the hammers original position
        hammerOriginalPos = hammer.transform.position;
        //Finds the Move To Position script
        MTP = GameObject.FindObjectOfType<MoveToPos>();
        //Sets the timer variable
        Timer = time;
        //Finds the tutorial script
        tut = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the buttonSelected is true.
        if (buttonSelected == true)
        {
            //sets the sliders/hammering bool to true to play minigame
            usingSlider = true;
            isHammering = true;

            //Checks if the bool resetValue is false
            if(resetValue == false)
            {
                //sets the bool resetValue to true
                resetValue = true;
                //Sets the anvil Minigame slider's active to true
                gameSlider.SetActive(true);
                //Sets the repeat value in the minigame slider script to 0
                gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
                //Sets the bool inUseAnvil in the minigame slider script to true
                gameSlider.GetComponent<SliderMiniGame>().inUseAnvil = true;
            }
        }
        else
        {
            return;
        }

        //Checks if the bool isHammering is true
        if (isHammering == true)
        {
            //Checks if the mouse X input is less than -0.7
            if (Input.GetAxis("Mouse X") < -0.7f)
            {
                //Moves the hammer position on the x axis negatively
                hammer.transform.position = new Vector3(hammer.transform.position.x - 0.01f, hammer.transform.position.y, hammer.transform.position.z);
            }
            //Checks if the mouse X input is greater than 0.7
            if (Input.GetAxis("Mouse X") > 0.7f)
            {
                //Moves the hammer position on the x axis positvely
                hammer.transform.position = new Vector3(hammer.transform.position.x + 0.01f, hammer.transform.position.y, hammer.transform.position.z);
            }
            //Checks if the mouse Y input is less than -0.7
            if (Input.GetAxis("Mouse Y") < -0.7f)
            {
                //Moves the hammer position on the y axis negatively
                hammer.transform.position = new Vector3(hammer.transform.position.x, hammer.transform.position.y, hammer.transform.position.z - 0.01f);
            }
            //Checks if the mouse Y input is greater than 0.7
            if (Input.GetAxis("Mouse Y") > 0.7f)
            {
                //Moves the hammer position on the y axis positvely
                hammer.transform.position = new Vector3(hammer.transform.position.x, hammer.transform.position.y, hammer.transform.position.z + 0.01f);
            }
        }

    } 

    private void OnTriggerExit(Collider other)
    {
        //Checks if the gameobject that exited the collider has a tag called Iron Ingot
        if (other.gameObject.tag == "Iron Ingot")
        {
            //Resets the int value ingotCount to 0 
            ingotCount = 0;
        }
        //Checks if the gameobject that exited the collider has a tag called Iron Sheet
        else if (other.gameObject.tag == "Iron Sheet")
        {
            //Sets the gameobject's sheet Quality to the quality created from the minigame
            other.gameObject.GetComponent<Sheet>().quality = Quality;
            //Runs the resetValue function
            ResetValue();
        }
        //Checks if the gameobject that exited the collider has a tag called Iron Blade
        else if (other.gameObject.tag == "Iron Blade")
        {
            //Sets the gameobject's blade Quality to the quality created from the minigame plus sheetquality divided by 2
            other.gameObject.GetComponent<Blade>().quality = (Quality + sheetQuality) / 2;
            //Runs the resetValue function
            ResetValue();
        }
    }

    private void ResetValue()
    {
        //Resets the quality int value to 0
        Quality = 0;
        //Resets the int value sheetCount to 0
        sheetQuality = 0;
    }

    private void OnMouseOver()
    {
            //When mouse is hovering over the gameobject and player presses F
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Sets the prompt's active to false
                prompt.SetActive(false);
                //Sets the prompt's script can show bool to false
                PS.canShow = false;
                //Sets the canHammer bool to true
                canHammer = true;
                //Sets the int value of cCount based of the player's hand child count
                int cCount = Parent.transform.childCount;
                //Checks if cCount is greater than 0 checks if the player's hand child's tag is either a Iron Sheet or Iron ingot
                if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ingot")
                {

                    //Snapping of the gameobjec to a position on the anvil
                    Snapping(Parent.transform.GetChild(0));
                    //Plays an audio source
                    placeDown.Play();
                    //Checks if the textIndex for the tutorial is either 10 or 11
                    if (tut.textPos == 11 || tut.textPos == 10)
                    {
                        //Runs the function Progress tutorial in the tutorial script to index 10
                        tut.ProgressTutorial(10);
                    }
                }
                //Checks if the ingot Count or Sheet count is not equal to 0
                else if(ingots.Count != 0 || sheet.Count != 0)
                {                   
                    //Runs the gotoAnvil function in the MoveToPosition script
                    MTP.gotoAnvil();
                    //Checks if the textIndex for the tutorial is either 10 or 11
                    if (tut.textPos == 11 || tut.textPos == 10)
                    {
                         //Runs the function Progress tutorial in the tutorial script to index 11
                         tut.ProgressTutorial(11);
                    }               
                }

            }
            else
            {
                return;
            }
    }

    public void Snapping(Transform other)
    {
        //Checks if the gameObject tag is an Iron Ingot
        if (other.gameObject.tag == "Iron Ingot")
        {
            //Checkis if the gameobject has been heated (true)
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                //Checks if the textIndex for the tutorial is either 9 or 10
                if (tut.textPos == 10 || tut.textPos == 9)
                {
                    //Runs the function Progress tutorial in the tutorial script to index 10
                    tut.ProgressTutorial(10);
                }
                //Checks if the ingots count is more than 3
                if (ingots.Count > 3)
                {
                    //Sets the gameobjects position to a position which is decided beforehand which is in wrongIngotDrop
                    other.gameObject.transform.position = wrongIngotDrop.position;
                }
                else
                {
                    //Checks if the ingot count is equal to 0
                    if (ingots.Count == 0)
                    {
                        increaseIngotCount(other);
                        //Checks if the ingotplace1 is empty
                        if (ingotplace1 == "empty")
                        {
                            //Snapping ingot 1
                            snappingIngot(other, 0);
                        }
                        //Sets the gameObject to isHammering(true)
                        other.gameObject.GetComponent<Ingot>().ingotPickup.inHammering = true;
                    }
                    //Checks if the ingotCount is greater than 0
                    else if (ingots.Count > 0)
                    {
                        //Checks if the gameObject's material in the ingot script is the same as the ingot at index 0's material
                        if (other.gameObject.GetComponent<Ingot>().material == ingots[0].GetComponent<Ingot>().material)
                        {
                            increaseIngotCount(other);
                            //Checks if the ingotplace2 is empty
                            if (ingotplace2 == "empty")
                            {
                                //Snapping ingot 2
                                snappingIngot(other, 1);
                            }
                            //Checks if the ingotplace3 is empty
                            else if (ingotplace3 == "empty")
                            {
                                //Snapping ingot 2
                                snappingIngot(other, 2);
                            }
                            //Sets the gameObject to isHammering(true)
                            other.gameObject.GetComponent<Ingot>().ingotPickup.inHammering = true;
                        }
                        else
                        {
                            //Sets the gameObject's isHolding to true
                            other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                            //Sets the gameobjects position to a position which is decided beforehand which is in wrongIngotDrop
                            other.gameObject.transform.position = wrongIngotDrop.position;
                            //Sets the warning's active to true
                            warning.SetActive(true);

                        }

                    }
                }
            }
            else
            {
                return;
            }
        }
        //Checks if the gameObject tag is an Iron Sheet
        else if (other.gameObject.tag == "Iron Sheet")
        {
            //Checkis if the gameobject has been heated (true)
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                //Sets the gameObject's isHolding to false
                other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                //Sets the gameObject's rigidbody iskinematic to true
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //Sets the gameObject's position to the ingotplaceArray at index 1's position
                other.transform.position = ingotplace[1].transform.position;
                //Sets the gameObject's eulerangle a new Vector 3 angles based on the x rotation by 180
                other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);

                //Checks if the ingotCount is greater than 1
                if (sheetCount > 1)
                {
                    //Sets the gameobjects position to a position which is decided beforehand which is in wrongIngotDrop
                    other.gameObject.transform.position = wrongIngotDrop.position;
                }
                else
                {
                    //Increases the sheet count by 1
                    sheetCount++;
                    //Sets the gameobject's sheet Quality to the quality created from the minigame
                    other.gameObject.GetComponent<Sheet>().quality = sheetQuality;
                    //Sets the gameObject to isHammering(true)
                    other.gameObject.GetComponent<Sheet>().sheetPickup.inHammering = true;
                    //Adds the gameobject to the list of sheets
                    sheet.Add(other.gameObject);
                }
            }
            else
            {
                return;
            }
        }
    }

    public void anvilIngot()
    {
        resettingHammer();

        //Checks if the textIndex for the tutorial is either 11 or 12
        if (tut.textPos == 12 || tut.textPos == 11)
        {
            //Runs the function Progress tutorial in the tutorial script to index 12
            tut.ProgressTutorial(12);
        }
        //Checks if the textIndex for the tutorial is either 13 or 14
        if (tut.textPos == 14 || tut.textPos == 13)
        {
            //Runs the function Progress tutorial in the tutorial script to index 14
            tut.ProgressTutorial(14);
        }

        //Checks if the ingot count is 1
        if (ingots.Count == 1)
        {
            removingIngot(0);
        }
        //Checks if the ingot count is 2
        if (ingots.Count == 2)
        {
            removingIngot(1);
        }
        //Checks if the ingot count is 3
        if (ingots.Count == 3)
        {
            removingIngot(2);
        }
        //Sets button selected to false
        buttonSelected = false;
    }


    public void anvilSheet()
    {
        //Checks if the sheet count is greater or equal to 1
        if (sheet.Count >= 1)
        {
            resettingHammer();       
            //Checks if the sizes of the sheet is small
            if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(0))
            {
                removingSheet(0);
            }
            //Checks if the sizes of the sheet is medium
            if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(1))
            {
                removingSheet(1);
            }
            //Checks if the sizes of the sheet is large
            if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(2))
            {
                removingSheet(2);
            }
            //Sets swordblade to false
            isSwordBlade = false;
            //Sets buttonSelected to false
            buttonSelected = false;          
        }
    }

    private void resettingHammer()
    {
        //Sets is hammering to false
        isHammering = false;
        //Runs the returnToPosing in the moving to Position script
        MTP.returnToPos();
        //Sets the prompt gameobject to true
        prompt.SetActive(true);
        //Sets the canshow in Prompt script to true
        PS.canShow = true;
        //Resets the hammer position to the original hammer position
        hammer.transform.position = hammerOriginalPos;
    }

    private void removingSheet(int index)
    {
        //Creates a small sheet prefab at a drop position
        GameObject small = Instantiate(blades[index], drop.position, Quaternion.identity);
        //Sets the material index based on the first ingot material
        int materialIndex = (int)sheet[0].GetComponent<Sheet>().material;
        //Sets the blade material based on the material index
        small.GetComponent<Blade>().material = (Blade.BladeMaterial)(materialIndex);
        //Destroy the sheet in the list
        Destroy(sheet[0]);
        //Removes the ingot from the list
        sheet.RemoveRange(0, sheet.Count);
        //Sets the count to 0
        sheetCount = 0;
    }

    private void removingIngot(int index)
    {
        //Creates a small sheet prefab at a drop position
        GameObject sheet = Instantiate(sheets[index], drop.position, Quaternion.identity);
        //Sets the material index based on the first ingot material
        int materialIndex = (int)ingots[0].GetComponent<Ingot>().material;
        //Sets the sheets material based on the material index
        sheet.GetComponent<Sheet>().material = (Sheet.SheetMaterial)(materialIndex);
        //Removes the ingot from the list
        ingots.RemoveRange(0, ingots.Count);
        //Sets the count to 0
        ingotCount = 0;

        if (index == 0)
        {
            //Destroy the ingot in the list
            Destroy(ingots[0]);
            //Sets the ingotplace to empty
            ingotplace1 = "empty";
        }
        else if (index == 1)
        {
            //Destroy the ingot in the list
            Destroy(ingots[0]);
            Destroy(ingots[1]);

            //Sets the ingotplace to empty
            ingotplace1 = "empty";
            ingotplace2 = "empty";
        }
        else if (index == 2)
        {
            //Destroy the ingot in the list
            Destroy(ingots[0]);
            Destroy(ingots[1]);
            Destroy(ingots[2]);

            //Sets the ingotplace to empty
            ingotplace1 = "empty";
            ingotplace2 = "empty";
            ingotplace3 = "empty";
        }
    }

    private void snappingIngot(Transform other, int index)
    {
        //Sets the gameObject's position to the ingotplaceArray at index 0's position
        other.transform.position = ingotplace[index].transform.position;
        //Sets the gameObject's eulerangle a new Vector 3 angles based on the x rotation by 180
        other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
        other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
        //Adds the gameobject to the list of ingots
        ingots.Add(other.gameObject);
        if (index == 0)
        {
            //Sets the ingotplace1 to full
            ingotplace1 = "full";
        }
        else if (index == 1)
        {
            //Sets the ingotplace2 to full
            ingotplace2 = "full";
        }
        else if (index == 2)
        {
            //Sets the ingotplace2 to full
            ingotplace3 = "full";
        }
    }

    private void increaseIngotCount(Transform other)
    {
        //Increases the ingot count by 1
        ingotCount++;
        //Sets the gameObject's isHolding to false
        other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
        //Sets the gameObject's rigidbody iskinematic to true
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
