using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{

    public enum TypeSheet { small, medium, large };
    public enum SheetMaterial { iron, steel, bronze };

    public TypeSheet size;
    public SheetMaterial material;

    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public int quality;
    public PickUp sheetPickup;

    public Material[] textures;
    // Start is called before the first frame update
    void Start()
    {
        sheetPickup = this.gameObject.GetComponent<PickUp>();
        objectName = this.gameObject.name;
        TextureChange();
        if (ready == false)
        {
            this.gameObject.name = objectName + " (Not Ready)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Smelt();
    }

    void Smelt()
    {
        if (smeltTime > 0)
        {
            sheetPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
            }
        }
    }

    void TextureChange()
    {
        if (material == SheetMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
        }
        else if (material == SheetMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (material == SheetMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
        }
    }
}
