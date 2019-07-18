using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : MonoBehaviour
{
    public int ingotCount;
    public int sheetCount;
    public int Quality;

    public Transform drop;

    public GameObject gameSlider;

    public bool usingSlider = false;

    public List<GameObject> ingots = new List<GameObject>();

    public GameObject[] sheets;
    public GameObject[] blades;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                ingotCount++;
                ingots.Add(other.gameObject);
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Iron Large Sheet")
        {
            other.gameObject.GetComponent<Sheet>().quality = Quality;
        }
        else if(other.gameObject.tag == "Iron Medium Sheet")
        {
            other.gameObject.GetComponent<Sheet>().quality = Quality;
        }
        else if(other.gameObject.tag == "Iron Large Sheet")
        {
            other.gameObject.GetComponent<Sheet>().quality = Quality;
        }
    }

    private void OnMouseOver()
    {
        Debug.Log("Hover");
        if (ingotCount > 0 || sheetCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Slider On");
                gameSlider.SetActive(true);
                gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
                usingSlider = true;
            }
        }
        else
        {
            return;
        }
    }

    public void usingAnvil()
    {
        if(ingotCount > 0)
        {
            if(ingots.Count == 1)
            {
                Instantiate(sheets[0], drop.position, Quaternion.identity);
                Destroy(ingots[0]);
                ingots.RemoveRange(0, ingots.Count);
                ingotCount = 0;
            }
            if (ingots.Count == 2)
            {
                Instantiate(sheets[1], drop.position, Quaternion.identity);
                Destroy(ingots[0]);
                Destroy(ingots[1]);
                ingots.RemoveRange(0, ingots.Count);
                ingotCount = 0;
            }
            if (ingots.Count == 3)
            {
                Instantiate(sheets[2], drop.position, Quaternion.identity);
                Destroy(ingots[0]);
                Destroy(ingots[1]);
                Destroy(ingots[2]);
                ingots.RemoveRange(0, ingots.Count);
                ingotCount = 0;
            }
        }
    }
}
