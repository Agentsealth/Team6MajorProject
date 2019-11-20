using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMTP : MonoBehaviour
{
    public MoveToPos MTP;
    public GameObject outline;

    public bool IsInShop;
    // Start is called before the first frame update
    void Start()
    {
        MTP = FindObjectOfType<MoveToPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsInShop == true)
            {
                MTP.returnToPos();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                IsInShop = false;
                Cursor.visible = false;

            }
        }
    }

    private void OnMouseOver()
    {
        //outline.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F))
        {
            MTP.gotoShop();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            IsInShop = true;
        }

    }

    private void OnMouseExit()
    {
        //SetActive(false);
    }
}
