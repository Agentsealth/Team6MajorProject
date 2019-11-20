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
    //Functions which checks if you use to click on the button due to locking the mouse
    public void OnPointerClick()
    {
        if (enchanting == true)
        {
            shop.BuyEnchanting();
        }
       
    }
    //Functions which runs when the mouse hovers over the gameObject
    private void OnMouseOver()
    {
        text.color = new Color32(255, 255, 0, 255);
    }
    //Functions which runs when the mouse exits the gameObject
    private void OnMouseExit()
    {
        text.color = new Color32(0, 0, 0, 255);

    }
}
