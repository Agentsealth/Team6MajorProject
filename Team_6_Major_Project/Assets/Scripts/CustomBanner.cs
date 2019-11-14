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
        //Sets the path to the MyDocuments on the pc
        path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        //Checks if the Directory exist for Redacted6
        if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6"))
        {
            //Creates a Directory
            Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6");
        }
        //Checks if the File exist for image
        if(!File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png"))
        {
            //Sets the tex as a texture2D
            tex = texture as Texture2D;
            //Encodes the PNG to a fileData
            fileData = tex.EncodeToPNG();
            //Writes the fileBytes to the directory and creates an image
            File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png", fileData);
        }
        else
        {
            //Reads the Bytes from the directory being an image
            fileData = File.ReadAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/" + "Redacted6" + "/" + "customBanner" + ".png");
            //Creates a texture2D
            tex = new Texture2D(2, 2);
            //Lods the image to the texture
            tex.LoadImage(fileData);
            //Creates a new material
            Material customMat = this.gameObject.GetComponent<MeshRenderer>().material;
            //Sets the texture
            customMat.SetTexture("Texture2D_EE4CDF5F", tex);
        }
        //Sets textures
        texture = tex;
        //Sets the main texture
        material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
