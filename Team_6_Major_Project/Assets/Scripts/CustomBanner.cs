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
    public Sprite sprite;
    public Texture2D tex = null;
    private byte[] fileData;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6"))
        {
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6");
        }

        if(!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png"))
        {
            tex = texture as Texture2D;
            fileData = tex.EncodeToPNG();
            File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png", fileData);
        }
        else
        {
            fileData = File.ReadAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            Material customMat = this.gameObject.GetComponent<MeshRenderer>().material;
            customMat.SetTexture("Texture2D_EE4CDF5F", tex);
        }

        //if (File.Exists(Application.persistentDataPath + "/" + "customBanner" + ".png"))
        //{
        //    fileData = File.ReadAllBytes(Application.persistentDataPath + "/" + "customBanner" + ".png");
        //    tex = new Texture2D(2, 2);
        //    tex.LoadImage(fileData);
        //    Material customMat = this.gameObject.GetComponent<MeshRenderer>().material;
        //    customMat.SetTexture("Texture2D_EE4CDF5F", tex);

        //}
        texture = tex;
        material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
