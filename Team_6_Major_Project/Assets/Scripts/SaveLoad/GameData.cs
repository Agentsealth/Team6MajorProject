using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OreInfo
{
    public float OrePosX;
    public float OrePosY;
    public float OrePosZ;

    public float OreRotX;
    public float OreRotY;
    public float OreRotZ;

    public int oreMat;
}

[System.Serializable]
public class GuardInfo
{
    public float GuardPosX;
    public float GuardPosY;
    public float GuardPosZ;

    public float GuardRotX;
    public float GuardRotY;
    public float GuardRotZ;

    public int GuardMat;
    public int GuardQuality;
}

[System.Serializable]
public class HandleInfo
{
    public float HandlePosX;
    public float HandlePosY;
    public float HandlePosZ;

    public float HandleRotX;
    public float HandleRotY;
    public float HandleRotZ;

    public int HandleMat;
    public int HandleQuality;
}

[System.Serializable]
public class BladeInfo
{
    public float BladePosX;
    public float BladePosY;
    public float BladePosZ;

    public float BladeRotX;
    public float BladeRotY;
    public float BladeRotZ;

    public int BladeMat;
    public int BladeQuality;
    public int BladeSize;
}

[System.Serializable]
public class SheetInfo
{
    public float SheetPosX;
    public float SheetPosY;
    public float SheetPosZ;

    public float SheetRotX;
    public float SheetRotY;
    public float SheetRotZ;

    public int SheetMat;
    public int SheetQuality;
    public int SheetSize;
}

[System.Serializable]
public class IngotInfo
{
    public float IngotPosX;
    public float IngotPosY;
    public float IngotPosZ;

    public float IngotRotX;
    public float IngotRotY;
    public float IngotRotZ;

    public int IngotMat;
    public bool IngotReady;
}

[System.Serializable]
public class SwordInfo
{
    public float SwordPosX;
    public float SwordPosY;
    public float SwordPosZ;

    public float SwordRotX;
    public float SwordRotY;
    public float SwordRotZ;

    public int SwordBladeMat;
    public int SwordGuardMat;
    public int SwordHandleMat;
    public int SwordQuality;
    public int SwordSize;
}

[System.Serializable]
public class UpgradeInfo
{
    public bool enchantingUpgrade;
}


[System.Serializable]
public class GameData
{
    public string saveGameName;

    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    public float playerRotX;
    public float playerRotY;
    public float playerRotZ;

    public int goldValue;
    public int customerOrderNumber;
    public int dayNumber;

    public float cameraRotX;

    public int oreCount;
    public int guardCount;
    public int handleCount;
    public int bladeCount;
    public int sheetCount;
    public int ingotCount;
    public int swordCount;

    public List<OreInfo> OreInfoList = new List<OreInfo>();
    public List<GuardInfo> GuardInfoList = new List<GuardInfo>();
    public List<HandleInfo> HandleInfoList = new List<HandleInfo>();
    public List<BladeInfo> BladeInfoList = new List<BladeInfo>();
    public List<SheetInfo> SheetInfoList = new List<SheetInfo>();
    public List<IngotInfo> IngotInfoList = new List<IngotInfo>();
    public List<SwordInfo> SwordInfoList = new List<SwordInfo>();

    public UpgradeInfo upgradeInfo = new UpgradeInfo();
}
