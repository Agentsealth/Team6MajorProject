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

    public GameObject gameSlider;

    public bool usingSlider = false;

    public List<GameObject> ingots = new List<GameObject>();
    public List<GameObject> sheet = new List<GameObject>();

    public GameObject[] sheets;
    public GameObject[] blades;

    private MoveToPos MTP;

    public GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        //MTP = GameObject.FindObjectOfType<MoveToPos>();
        Timer = time;
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

                if (ingotCount > 3)
                {
                    return;
                }
                else
                {
                    if (ingotCount == 0)
                    {
                        ingotCount++;
                        ingots.Add(other.gameObject);
                        //MTP.gotoAnvil();
                        other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                        other.transform.position = drop.transform.position;
                    }
                    else if (ingotCount > 0)
                    {
                        if (other.gameObject.GetComponent<Ingot>().material == ingots[0].GetComponent<Ingot>().material)
                        {
                            ingotCount++;
                            ingots.Add(other.gameObject);
                            //MTP.gotoAnvil();
                            other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                            other.transform.position = drop.transform.position;
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
        else if(other.gameObject.tag == "Iron Sheet")
        {
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.transform.position = drop.transform.position;


                if (sheetCount > 1)
                {
                    return;
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

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Iron Ingot")
        {
            ingotCount = 0;
        }
        else if(other.gameObject.tag == "Iron Sheet")
        {
            other.gameObject.GetComponent<Sheet>().quality = Quality;
            Quality = 0;
            sheetCount = 0;
        }
        else if(other.gameObject.tag == "Iron Blade")
        {
            other.gameObject.GetComponent<Blade>().quality = (Quality + sheetQuality) / 2;
            Quality = 0;
            sheetQuality = 0;
        }
    }

    private void OnMouseOver()
    {
        if (ingotCount > 0 || sheetCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //TODO:Fix bug where ingots can still be pick when in minigame stage will also apply with sheets
                //MTP.gotoAnvil();
                gameSlider.SetActive(true);
                gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
                gameSlider.GetComponent<SliderMiniGame>().inUseAnvil = true;
                usingSlider = true;
            }
        }
        else
        {
            return;
        }
    }

    public void anvilIngot()
    {
        if(ingotCount > 0)
        {
            //MTP.returnToPos();
            if(ingots.Count == 1)
            {
                GameObject sheet = Instantiate(sheets[0], drop.position, Quaternion.identity);
                int materialIndex = (int)ingots[0].GetComponent<Ingot>().material;
                sheet.GetComponent<Sheet>().material = (Sheet.SheetMaterial)(materialIndex);
                Destroy(ingots[0]);
                ingots.RemoveRange(0, ingots.Count);
                ingotCount = 0;
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
            }
        }
    }

    public void anvilSheet()
    {
        if (sheetCount > 0)
        {
            //MTP.returnToPos();
            if (sheet.Count == 1)
            {
                Instantiate(blades[0], drop.position, Quaternion.identity);
                Destroy(sheet[0]);
                sheet.RemoveRange(0, sheet.Count);
                sheetCount = 0;
            }
            if (sheet.Count == 2)
            {
                Instantiate(blades[1], drop.position, Quaternion.identity);
                Destroy(sheet[0]);
                Destroy(sheet[1]);
                sheet.RemoveRange(0, sheet.Count);
                sheetCount = 0;
            }
            if (sheet.Count == 3)
            {
                Instantiate(blades[2], drop.position, Quaternion.identity);
                Destroy(sheet[0]);
                Destroy(sheet[1]);
                Destroy(sheet[2]);
                sheet.RemoveRange(0, sheet.Count);
                sheetCount = 0;
            }
        }
    }
}
