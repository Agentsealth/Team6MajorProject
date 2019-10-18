using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    public enum GuardMaterial {none, bronze, iron, steel };

    public GuardMaterial material;

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
        if (material == GuardMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
            this.gameObject.name = "Iron Guard";
        }
        else if (material == GuardMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
            this.gameObject.name = "Steel Guard";
        }
        else if (material == GuardMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
            this.gameObject.name = "Bronze Guard";
        }
    }

}
