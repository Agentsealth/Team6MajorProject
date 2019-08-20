using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public enum SwordType { small, medium, large };
    public enum MaterialBlade { iron, steel, bronze };
    public enum MaterialHandle { iron, steel, bronze };
    public enum MaterialGuard { iron, steel, bronze };

    public SwordType swordType;
    public MaterialBlade materialBlade;
    public MaterialHandle materialHandle;
    public MaterialGuard materialGuard;

    public Material[] textures;

    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        TextureChangeBlade();
        TextureChangeGuard();
        TextureChangeHandle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TextureChangeBlade()
    {
        if (materialBlade == MaterialBlade.iron)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[0];
        }
        else if (materialBlade == MaterialBlade.steel)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (materialBlade == MaterialBlade.bronze)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[2];
        }
    }

    void TextureChangeGuard()
    {
        if (materialGuard == MaterialGuard.iron)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[0];
        }
        else if (materialGuard == MaterialGuard.steel)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (materialGuard == MaterialGuard.bronze)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[2];
        }
    }

    void TextureChangeHandle()
    {
        if (materialHandle == MaterialHandle.iron)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[0];
        }
        else if (materialHandle == MaterialHandle.steel)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[1];
        }
        else if (materialHandle == MaterialHandle.bronze)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[2];
        }
    }
}
