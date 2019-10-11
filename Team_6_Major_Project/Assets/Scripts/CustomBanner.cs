using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;
using UnityEngine;

public class CustomBanner : MonoBehaviour
{
    public Material material;
    public Texture texture;
    Texture2D tex = null;
    byte[] fileData;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "customBanner" + ".png"))
        {
            fileData = File.ReadAllBytes(Application.persistentDataPath + "/" + "customBanner" + ".png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
        texture = tex;
        material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
