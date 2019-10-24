using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradePointClick : MonoBehaviour
{
    public UpgradeShop shop;

    public bool enchanting;
    public Text text;
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

    private void OnMouseOver()
    {
        text.color = new Color32(255, 255, 0, 255);
    }
    private void OnMouseExit()
    {
        text.color = new Color32(255, 255, 255, 255);

    }
}
