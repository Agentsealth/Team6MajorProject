using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : MonoBehaviour
{
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
    public GameObject options;
    public GameObject axe;


    public bool usingSlider = false;
    public bool isHammering;
    public bool selected;
    public bool buttonSelected;
    public bool resetValue;
    public bool isSwordBlade;
    public bool isAxeBlade;

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
    public GameObject CritPoint;

    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        hammerOriginalPos = hammer.transform.position;
        MTP = GameObject.FindObjectOfType<MoveToPos>();
        Timer = time;
        tut = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonSelected == true)
        {

            usingSlider = true;
            isHammering = true;
            if(resetValue == false)
            {
                resetValue = true;
                gameSlider.SetActive(true);
                gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
                gameSlider.GetComponent<SliderMiniGame>().inUseAnvil = true;
            }

            var position = new Vector3(Random.Range(-3.9f, -3.6f), 0.79f, Random.Range(7.4f, 7.6f));
            Instantiate(CritPoint, position, Quaternion.identity);
        }
        else
        {
            return;
        }

        if (isHammering)
        {
            if (Input.GetAxis("Mouse X") < -0.7f)
            {
                hammer.transform.position = new Vector3(hammer.transform.position.x - 0.01f, hammer.transform.position.y, hammer.transform.position.z);
            }
            if (Input.GetAxis("Mouse X") > 0.7f)
            {
                hammer.transform.position = new Vector3(hammer.transform.position.x + 0.01f, hammer.transform.position.y, hammer.transform.position.z);
            }
            if (Input.GetAxis("Mouse Y") < -0.7f)
            {
                hammer.transform.position = new Vector3(hammer.transform.position.x, hammer.transform.position.y, hammer.transform.position.z - 0.01f);
            }
            if (Input.GetAxis("Mouse Y") > 0.7f)
            {
                hammer.transform.position = new Vector3(hammer.transform.position.x, hammer.transform.position.y, hammer.transform.position.z + 0.01f);
            }
        }

    } 

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            ingotCount = 0;
        }
        else if (other.gameObject.tag == "Iron Sheet")
        {
            other.gameObject.GetComponent<Sheet>().quality = Quality;
            Quality = 0;
            sheetCount = 0;
        }
        else if (other.gameObject.tag == "Iron Blade")
        {
            other.gameObject.GetComponent<Blade>().quality = (Quality + sheetQuality) / 2;
            Quality = 0;
            sheetQuality = 0;
        }
    }

    private void OnMouseOver()
    {
            if (Input.GetKeyDown(KeyCode.F))
            {
                int cCount = Parent.transform.childCount;
                if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ingot")
                {

                //TODO:Fix bug where ingots can still be pick when in minigame stage will also apply with sheets
   
                help(Parent.transform.GetChild(0));
                   
                }
                else
                {
                    MTP.gotoAnvil();
                    tut.TutorialNextStep(12);

            }

        }
    }

    public void chooseSword() //Player chooses to make a swordBlade
    {
        options.SetActive(false);
        buttonSelected = true;
        isSwordBlade = true;
        resetValue = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //playerInPos = true;

    }

    public void chooseAxe() //player chooses to make a AxeBlade
    {
        options.SetActive(false);
        buttonSelected = true;
        isAxeBlade = true;
        resetValue = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        //playerInPos = true;
    }

    public void help(Transform other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {

            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {

                if (ingots.Count > 3)
                {
                    other.gameObject.transform.position = wrongIngotDrop.position;
                }
                else
                {
                    if (ingots.Count == 0)
                    {
                        ingotCount++;
                        other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        //other.transform.position = drop.transform.position;
                        if (ingotplace1 == "empty")
                        {
                            other.transform.position = ingotplace[0].transform.position;
                            other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                            other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                            ingots.Add(other.gameObject);
                            ingotplace1 = "full";

                        }
                    }
                    else if (ingots.Count > 0)
                    {
                        if (other.gameObject.GetComponent<Ingot>().material == ingots[0].GetComponent<Ingot>().material)
                        {
                            other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                            //other.transform.position = drop.transform.position;
                            if (ingotplace2 == "empty")
                            {
                                other.transform.position = ingotplace[1].transform.position;
                                other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                                other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                                ingots.Add(other.gameObject);
                                ingotplace2 = "full";
                                ingotCount++;

                            }
                            else if (ingotplace3 == "empty")
                            {
                                other.transform.position = ingotplace[2].transform.position;
                                other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                                other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);
                                ingots.Add(other.gameObject);
                                ingotplace3 = "full";
                                ingotCount++;
                            }
                        }
                        else
                        {
                            other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                            other.gameObject.transform.position = wrongIngotDrop.position;
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
        else if (other.gameObject.tag == "Iron Sheet")
        {
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = ingotplace[0].transform.position;
                other.transform.eulerAngles = new Vector3(other.transform.eulerAngles.x - other.transform.eulerAngles.x + 180,
                other.transform.eulerAngles.y - other.transform.eulerAngles.y, other.transform.eulerAngles.z - other.transform.eulerAngles.z);

                if (sheetCount > 1)
                {
                    other.gameObject.transform.position = wrongIngotDrop.position;
                }
                else
                {
                    sheetCount++;
                    other.gameObject.GetComponent<Sheet>().quality = sheetQuality;
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
        isHammering = false;
        MTP.returnToPos();
        hammer.transform.position = hammerOriginalPos;

        if (ingots.Count == 1)
        {
            GameObject sheet = Instantiate(sheets[0], drop.position, Quaternion.identity);
            int materialIndex = (int)ingots[0].GetComponent<Ingot>().material;
            Debug.Log(materialIndex);
            sheet.GetComponent<Sheet>().material = (Sheet.SheetMaterial)(materialIndex);
            Destroy(ingots[0]);
            ingots.RemoveRange(0, ingots.Count);
            ingotCount = 0;
            DestroyCrit();
            ingotplace1 = "empty";
        }
        if (ingots.Count == 2)
        {
            GameObject sheet = Instantiate(sheets[1], drop.position, Quaternion.identity);
            int materialIndex = (int)ingots[0].GetComponent<Ingot>().material;
            sheet.GetComponent<Sheet>().material = (Sheet.SheetMaterial)(materialIndex);
            Destroy(ingots[0]);
            Destroy(ingots[1]);
            ingots.RemoveRange(0, ingots.Count);
            ingotCount = 0;
            DestroyCrit();
            ingotplace1 = "empty";
            ingotplace2 = "empty";

        }
        if (ingots.Count == 3)
        {
            GameObject sheet = Instantiate(sheets[2], drop.position, Quaternion.identity);
            int materialIndex = (int)ingots[0].GetComponent<Ingot>().material;
            sheet.GetComponent<Sheet>().material = (Sheet.SheetMaterial)(materialIndex);
            Destroy(ingots[0]);
            Destroy(ingots[1]);
            Destroy(ingots[2]);
            ingots.RemoveRange(0, ingots.Count);
            ingotCount = 0;
            DestroyCrit();
            ingotplace1 = "empty";
            ingotplace2 = "empty";
            ingotplace3 = "empty";

        }
        buttonSelected = false;
    }


    public void anvilSheet()
    {
        if (sheet.Count >= 1)
        {
            isHammering = false;

            MTP.returnToPos();
            hammer.transform.position = hammerOriginalPos;
            if (isSwordBlade == true)
            {
                if (tut.textPos == 12)
                {
                    tut.CanvasToggleOn();

                }
                tut.TutorialNextStep(12);
                if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(0))
                {
                    GameObject small = Instantiate(blades[0], drop.position, Quaternion.identity);
                    int materialIndex = (int)sheet[0].GetComponent<Sheet>().material;
                    small.GetComponent<Blade>().material = (Blade.BladeMaterial)(materialIndex);
                    Destroy(sheet[0]);
                    sheet.RemoveRange(0, sheet.Count);
                    DestroyCrit();
                    sheetCount = 0;
                }
                if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(1))
                {
                    GameObject medium = Instantiate(blades[1], drop.position, Quaternion.identity);
                    int materialIndex = (int)sheet[0].GetComponent<Sheet>().material;
                    medium.GetComponent<Blade>().material = (Blade.BladeMaterial)(materialIndex);
                    Destroy(sheet[0]);
                    sheet.RemoveRange(0, sheet.Count);
                    DestroyCrit();
                    sheetCount = 0;
                }
                if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(2))
                {
                    GameObject large = Instantiate(blades[2], drop.position, Quaternion.identity);
                    int materialIndex = (int)sheet[0].GetComponent<Sheet>().material;
                    large.GetComponent<Blade>().material = (Blade.BladeMaterial)(materialIndex);
                    Destroy(sheet[0]);
                    sheet.RemoveRange(0, sheet.Count);
                    DestroyCrit();
                    sheetCount = 0;
                }
                isSwordBlade = false;
                buttonSelected = false;

            }
            else if (isAxeBlade == true)
            {
                if (sheet[0].GetComponent<Sheet>().size == (Sheet.TypeSheet)(0))
                {
                    GameObject small = Instantiate(axe, drop.position, Quaternion.identity);
                    int materialIndex = (int)sheet[0].GetComponent<Sheet>().material;
                    small.GetComponent<Blade>().material = (Blade.BladeMaterial)(materialIndex);
                    Destroy(sheet[0]);
                    sheet.RemoveRange(0, sheet.Count);
                    DestroyCrit();
                    sheetCount = 0;
                }
            }
        }
    }

    public void DestroyCrit()
    {
        for (var i = 0; i < GameObject.FindGameObjectsWithTag("CriticalPoint").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("CriticalPoint")[i]);
        }
    }

    public void AddCritPoint()
    {
        var position = new Vector3(Random.Range(-3.9f, -3.6f), 0.79f, Random.Range(7.4f, 7.6f));
                Instantiate(CritPoint, position, Quaternion.identity);
    }
}
