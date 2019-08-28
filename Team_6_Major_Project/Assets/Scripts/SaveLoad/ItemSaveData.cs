using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveData : MonoBehaviour
{
    public float itemPosX;
    public float itemPosY;
    public float itemPosZ;

    public float itemRotX;
    public float itemRotY;
    public float itemRotZ;

    public int swordType;
    public int swordBladeMat;
    public int swordHandleMat;
    public int swordGuardMat;
    public int swordQuality;

    public int oreItem;
    public int oreMat;

    public int handleMat;
    public int handleQuality;

    public int guardMat;
    public int guardQuality;

    public int bladeSize;
    public int bladeMat;
    public int bladeQuality;

    public int ingotMat;
    public bool ingotReady;
    public string ingotName;

    public int sheetSize;
    public int sheetMat;
    public int sheetQuality;
    // Start is called before the first frame update
    public Ore myOre;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Iron Ore")
        {
            oreItem = 1;
            myOre = this.gameObject.GetComponent<Ore>();
            itemPosX = gameObject.transform.position.x;
            itemPosY = gameObject.transform.position.y;
            itemPosZ = gameObject.transform.position.z;

            itemRotX = gameObject.transform.rotation.eulerAngles.x;
            itemRotY = gameObject.transform.rotation.eulerAngles.y; 
            itemRotZ = gameObject.transform.rotation.eulerAngles.z;
        
            oreMat = (int)myOre.material;
        }
    }
}
