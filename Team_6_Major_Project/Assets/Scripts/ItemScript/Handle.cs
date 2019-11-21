using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    public enum HandleMaterial {none, bronze, iron, steel };

    public HandleMaterial material;

    public int quality;

    public Material[] textures;
    public Material[] cloth;

    // Start is called before the first frame update
    void Start()
    {
        TextureChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Functions which changes the texture for the handle
    void TextureChange()
    {
        if (material == HandleMaterial.iron)
        {
            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[0];
            mats[1] = cloth[0];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;
        }
        else if (material == HandleMaterial.steel)
        {
            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[1];
            mats[1] = cloth[1];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;
        }
        else if (material == HandleMaterial.bronze)
        {
            Material[] mats = this.gameObject.GetComponent<MeshRenderer>().materials;
            mats[0] = textures[2];
            mats[1] = cloth[2];
            this.gameObject.GetComponent<MeshRenderer>().materials = mats;
        }
    }

}
