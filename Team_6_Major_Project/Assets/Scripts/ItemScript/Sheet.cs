using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheet : MonoBehaviour
{

    public enum TypeSheet { small, medium, large };
    public enum SheetMaterial { none, bronze, iron, steel };

    public TypeSheet size;
    public SheetMaterial material;

    public bool ready = false;
    public string objectName;
    public float smeltTime;
    public int quality;
    public PickUp sheetPickup;
    public Furnace furance;
    public Rigidbody rigid;

    public int place;

    public Material[] textures;

    public Shader shader;

    public Texture thisTexture;

    public GrindstoneLogic GSLogic;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        GSLogic = FindObjectOfType<GrindstoneLogic>();
        sheetPickup = this.gameObject.GetComponent<PickUp>();
        rigid = this.gameObject.GetComponent<Rigidbody>();
        TextureChange();
        objectName = this.gameObject.name;
        if (ready == false)
        {
            this.gameObject.name = objectName + " (Not Ready)";
        }
    }

    public void finishGrind()
    {
        GSLogic.FinishGrind();
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
            sheetPickup.isHolding = false;
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                ready = true;
                this.gameObject.name = objectName + " (Ready)";
                var NewMat = new Material(shader);
                this.gameObject.GetComponent<MeshRenderer>().material = NewMat;
                NewMat.SetInt("Vector1_B7DBC96B", 1);
                NewMat.SetTexture("Texture2D_45580971", thisTexture);
                rigid.isKinematic = false;
                furance.ingotPlace = place;
                furance.Empty();
            }
        }
    }

    void TextureChange()
    {
        if (material == SheetMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
            thisTexture = textures[0].mainTexture;
            if(size == TypeSheet.small)
            {
                this.gameObject.name = "Small Iron Sheet";
            }
            else if (size == TypeSheet.medium)
            {
                this.gameObject.name = "Medium Iron Sheet";
            }
            else if (size == TypeSheet.large)
            {
                this.gameObject.name = "Large Iron Sheet";
            }
        }
        else if (material == SheetMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
            thisTexture = textures[1].mainTexture;
            if (size == TypeSheet.small)
            {
                this.gameObject.name = "Small Steel Sheet";
            }
            else if (size == TypeSheet.medium)
            {
                this.gameObject.name = "Medium Steel Sheet";
            }
            else if (size == TypeSheet.large)
            {
                this.gameObject.name = "Large Steel Sheet";
            }
        }
        else if (material == SheetMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
            thisTexture = textures[2].mainTexture;
            if (size == TypeSheet.small)
            {
                this.gameObject.name = "Small Bronze Sheet";

            }
            else if (size == TypeSheet.medium)
            {
                this.gameObject.name = "Medium Bronze Sheet";
            }
            else if (size == TypeSheet.large)
            {
                this.gameObject.name = "Large Bronze Sheet";
            }
        }
    }
}
