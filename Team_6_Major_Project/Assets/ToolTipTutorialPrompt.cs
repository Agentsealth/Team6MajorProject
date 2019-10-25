using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipTutorialPrompt : MonoBehaviour
{
    public GameObject toolTip;
    public GameObject toolTipHighlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        toolTip.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseToolTip()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        toolTip.SetActive(false);
        
    }
}
