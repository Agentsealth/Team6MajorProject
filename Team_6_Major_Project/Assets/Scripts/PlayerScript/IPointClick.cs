using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IPointClick : MonoBehaviour
{
    public Ore.OreMaterial material;
    public Shop shop;
    public Text text;

    private void Start()
    {
        shop = this.gameObject.GetComponentInParent<Shop>();
        
    }

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

    private void OnMouseOver()
    {
        text.color = new Color32(255, 255, 0, 255);
    }

    private void OnMouseExit()
    {
        text.color = new Color32(0, 0, 0, 255);

    }
}
