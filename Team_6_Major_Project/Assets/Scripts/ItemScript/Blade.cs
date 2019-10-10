using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public enum TypeBlade {none, sword, axe }
    public enum AxeBlade {none, oneSide, twoSide }
    public enum Typeblade {none, small, medium, large };
    public enum BladeMaterial {none, iron, steel, bronze };

    public TypeBlade blade;
    public AxeBlade axe;
    public Typeblade size;
    public BladeMaterial material;

    public int quality;

    public Material[] textures;
    // Start is called before the first frame update
    void Start()
    {
        TextureChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TextureChange()
    {
        if (material == BladeMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
            if (size == Typeblade.small)
            {
                this.gameObject.name = "Small Iron Blade";
            }
            else if (size == Typeblade.medium)
            {
                this.gameObject.name = "Large Iron Blade";
            }
            else if (size == Typeblade.large)
            {
                this.gameObject.name = "Bastard Iron Blade";
            }
        }
        else if (material == BladeMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
            if (size == Typeblade.small)
            {
                this.gameObject.name = "Small Steel Blade";
            }
            else if (size == Typeblade.medium)
            {
                this.gameObject.name = "Large Steel Blade";
            }
            else if (size == Typeblade.large)
            {
                this.gameObject.name = "Bastard Steel Blade";
            }
        }
        else if (material == BladeMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
            if (size == Typeblade.small)
            {
                this.gameObject.name = "Small Bronze Blade";
            }
            else if (size == Typeblade.medium)
            {
                this.gameObject.name = "Large Bronze Blade";
            }
            else if (size == Typeblade.large)
            {
                this.gameObject.name = "Bastard Bronze Blade";
            }
        }
    }
}
