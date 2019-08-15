using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public enum HandleMaterial { iron, steel, bronze };

    public HandleMaterial material;

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
        if (material == HandleMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
        }
        else if (material == HandleMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (material == HandleMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
        }
    }

}
