using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public enum OreMaterial { iron, steel, bronze };

    public OreMaterial material;

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
        if(material == OreMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
        }
        else if(material == OreMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (material == OreMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
        }
    }
}
