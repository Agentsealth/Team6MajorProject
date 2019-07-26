using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPointClick : MonoBehaviour
{
    public Ore.OreMaterial material;
    public Shop shop;

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
    }
}
