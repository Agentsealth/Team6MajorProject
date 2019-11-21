using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public enum TypeBlade {none, sword, axe }
    public enum AxeBlade {none, oneSide, twoSide }
    public enum Typeblade {none, small, medium, large };
    public enum BladeMaterial {none, bronze, iron, steel };

    public TypeBlade blade;
    public AxeBlade axe;
    public Typeblade size;
    public BladeMaterial material;

    public int quality;

    public Material[] textures;
    public Material[] gem;
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

            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[0];
            mats[1] = textures[0];
            mats[2] = gem[0];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;

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
            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[1];
            mats[1] = textures[1];
            mats[2] = gem[1];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;           
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

            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[2];
            mats[1] = textures[2];
            mats[2] = gem[2];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;
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
