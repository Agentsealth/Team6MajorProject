using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IPointClick : MonoBehaviour
{
    public Ore.OreMaterial material;
    public Shop shop;
    public Text text;
    // Start is called before the first frame update
    private void Start()
    {
        shop = this.gameObject.GetComponentInParent<Shop>();
        
    }
    //Used the click onto the button in the shop due to cusor locking and using raycast
    public void OnPointerClick()
    {
        if (material == Ore.OreMaterial.iron)
        {
            shop.BuyIron();
        }
        else if (material == Ore.OreMaterial.steel)
        {
            shop.BuySteel();
        }
        else if (material == Ore.OreMaterial.bronze)
        {
            shop.BuyBronze();
        }
        else if (material == Ore.OreMaterial.coal)
        {
            shop.BuyCoal();
        }
    }
    //When the mouse hover overs the gameObject
    private void OnMouseOver()
    {
        text.color = new Color32(255, 255, 0, 255);
    }
    //When the mouse exit the gameObject
    private void OnMouseExit()
    {
        text.color = new Color32(0, 0, 0, 255);

    }
}
