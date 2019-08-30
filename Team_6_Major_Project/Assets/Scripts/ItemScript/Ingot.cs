﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingot : MonoBehaviour
{
    public enum IngotMaterial { iron, steel, bronze };

    public IngotMaterial material;

    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public PickUp ingotPickup;

    public Material[] textures;

    public Shader shader;

    private Texture thisTexture;

    // Start is called before the first frame update
    void Start()
    {
        ingotPickup = this.gameObject.GetComponent<PickUp>();
        objectName = this.gameObject.name;
        TextureChange();
        if (ready == false)
        {
            this.gameObject.name = objectName + " (Not Ready)";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Smelt();

    }

    void Smelt()
    {
        if (smeltTime > 0)
        {
            ingotPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
                var NewMat = new Material(shader);
                this.gameObject.GetComponent<MeshRenderer>().material = NewMat;
                NewMat.SetInt("Vector1_B7DBC96B", 1);
                NewMat.SetTexture("Texture2D_45580971", thisTexture);
            }
        }        
    }

    void TextureChange()
    {
        if (material == IngotMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
            thisTexture = textures[0].mainTexture;


        }
        else if (material == IngotMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
            thisTexture = textures[1].mainTexture;

        }
        else if (material == IngotMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
            thisTexture = textures[2].mainTexture;

        }
    }
}
