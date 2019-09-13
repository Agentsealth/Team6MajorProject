using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePointClick : MonoBehaviour
{
    public UpgradeShop shop;

    public bool enchanting;

    // Start is called before the first frame update
    void Start()
    {
        shop = this.gameObject.GetComponentInParent<UpgradeShop>();
    }

    public void OnPointerClick()
    {
        if (enchanting == true)
        {
            shop.BuyEnchanting();
        }
       
    }

}
