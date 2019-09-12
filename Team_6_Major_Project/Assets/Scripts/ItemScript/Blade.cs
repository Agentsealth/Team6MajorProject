using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public enum Typeblade {none, small, medium, large };
    public enum BladeMaterial {none, iron, steel, bronze };

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
        }
        else if (material == BladeMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (material == BladeMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
        }
    }
}
