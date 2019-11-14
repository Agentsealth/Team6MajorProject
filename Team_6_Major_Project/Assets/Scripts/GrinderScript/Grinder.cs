using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grinder : MonoBehaviour
{
    public int sheetCount;
    public int sheetQuality;
    public int Quality;
    public GameObject gameSlider;
    public GameObject options;
    public GameObject guard;
    public GameObject handle;
    public GameObject sheet;
    public Transform drop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Functions which checks if the mouse is hovering over the gameObject
    private void OnMouseOver()
    {
        if (sheetCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                options.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }
    //Function which check if an object collides with the gameObject 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Sheet")
        {
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                if (sheetCount > 1)
                {
                    return;
                }
                else
                {
                    sheetCount++;
                    other.gameObject.GetComponent<Sheet>().quality = sheetQuality;
                    sheet = other.gameObject;
                }
            }
            else
            {
                return;
            }
        }
    }
    //Function which check if an object has exited the collision off the gameObject
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Iron Guard")
        {
            other.gameObject.GetComponent<Guard>().quality = (Quality + sheetQuality) / 2;
            Quality = 0;
            sheetCount = 0;
            sheetQuality = 0;
        }
        else if (other.gameObject.tag == "Iron Handle")
        {
            other.gameObject.GetComponent<Handle>().quality = (Quality + sheetQuality) / 2;
            sheetCount = 0;
            Quality = 0;
            sheetQuality = 0;
        }
    }
    //Functions which plays the minigame for the handle
    public void MinigameHandle()
    {
        options.SetActive(false);
        gameSlider.SetActive(true);
        gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
        gameSlider.GetComponent<SliderMiniGame>().inUseGrinder = true;
        gameSlider.GetComponent<SliderMiniGame>().handle = true;

    }
    //Functions which plays the minigame for the guard
    public void MinigameGuard()
    {
        options.SetActive(false);
        gameSlider.SetActive(true);
        gameSlider.GetComponent<SliderMiniGame>().repeat = 0;
        gameSlider.GetComponent<SliderMiniGame>().inUseGrinder = true;
        gameSlider.GetComponent<SliderMiniGame>().guard = true;

    }
    //Function which grinds the handle
    public void GrinderHandle()
    {
        if(sheetCount > 0 )
        {
            Instantiate(handle, drop.position, Quaternion.identity);
            sheetCount = 0;
            Destroy(sheet);
        }
    }
    //Function which grinds the guard
    public void GrinderGuard()
    {
        if (sheetCount > 0)
        {
            Instantiate(guard, drop.position, Quaternion.identity);
            sheetCount = 0;
            Destroy(sheet);
        }
    }
}
