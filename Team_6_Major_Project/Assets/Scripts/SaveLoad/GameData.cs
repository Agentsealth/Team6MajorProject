using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string saveGameName;

    public string Description;

    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    public float playerRotX;
    public float playerRotY;
    public float playerRotZ;

    public float cameraRotX;

    public int itemCount;

    public List<float> itemPosX;
    public List<float> itemPosY;
    public List<float> itemPosZ;

    public List<float> itemRotX;
    public List<float> itemRotY;
    public List<float> itemRotZ;

    public int swordType;
    public int swordBladeMat;
    public int swordHandleMat;
    public int swordGuardMat;
    public int swordQuality;

    public List<int> oreItem;
    public List<int> oreMat;

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

}
