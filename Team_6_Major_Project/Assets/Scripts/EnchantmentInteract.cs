using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantmentInteract : MonoBehaviour
{
    public MoveToPos MTP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Mouse hovers over the gameObject
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MTP.gotoEnchant();
        }
    }
}
