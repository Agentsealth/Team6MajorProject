using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSelector : MonoBehaviour
{
    public GameObject[] buttons;
    public int buttonindex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (buttonindex != buttons.Length - 1)
            {
                buttons[buttonindex].SetActive(false);
                buttonindex++;
                buttons[buttonindex].SetActive(true);
            }
            else
            {
                buttons[buttonindex].SetActive(false);
                buttonindex = 0;
                buttons[buttonindex].SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (buttonindex != 0)
            {
                buttons[buttonindex].SetActive(false);
                buttonindex--;
                buttons[buttonindex].SetActive(true);
            }
            else
            {
                buttons[buttonindex].SetActive(false);
                buttonindex = buttons.Length - 1;
                buttons[buttonindex].SetActive(true);
            }
        }
    }
}
