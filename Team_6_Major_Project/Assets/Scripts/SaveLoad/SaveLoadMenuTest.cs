using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;

public class SaveLoadMenuTest : MonoBehaviour
{
    public string description;
    public string saveGameName;
    public GameObject player;
    public GameObject playerCamera;
    public PlayerMotor motor;
    public GameObject day;
    public List<Ore> oreList = new List<Ore>();
    public List<Guard> guardList = new List<Guard>();
    public List<Handle> handleList = new List<Handle>();
    public List<Blade> bladeList = new List<Blade>();
    public List<Sheet> sheetList = new List<Sheet>();
    public List<Ingot> ingotList = new List<Ingot>();
    public List<Sword> swordList = new List<Sword>();

    [Header("UI")]
    public GameObject autoSaveSlot1;
    public GameObject autoSaveSlot2;
    public GameObject autoSaveSlot3;
    public GameObject saveButton;
    public GameObject loadButton;

    public Text saveName;
    public Text dayProgress;
    public Text dateTime;

    [Header("Loading")]
    public GameObject Ore;
    public GameObject guard;
    public GameObject handle;
    public GameObject ingot;
    public GameObject[] blade;
    public GameObject[] sheet;
    public GameObject[] sword;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        motor = player.GetComponent<PlayerMotor>();
        playerCamera = GameObject.FindWithTag("MainCamera");
    }

    public void SetSave1()
    {
        saveName.text = autoSaveSlot1.GetComponentInChildren<Text>().text;
        bool exist = SaveLoad.CheckFileExist(autoSaveSlot1.GetComponentInChildren<Text>().text);
        if (exist == true)
        {
            saveGameName = autoSaveSlot1.GetComponentInChildren<Text>().text;
            GameData loadedGame = SaveLoad.Load(saveGameName);
            dayProgress.text = "Day: " + loadedGame.dayNumber.ToString();
            dateTime.text = "Time: " + File.GetCreationTime(saveGameName).ToString();
            saveButton.SetActive(true);
            loadButton.SetActive(true);
        }
        else if (exist == false)
        {
            saveGameName = autoSaveSlot1.GetComponentInChildren<Text>().text;
            dayProgress.text = "Day: (Needs a Save)";
            dateTime.text = "Time: (Needs a Save)";
            saveButton.SetActive(true);

        }
    }

    public void SetSave2()
    {
        saveName.text = autoSaveSlot2.GetComponentInChildren<Text>().text;
        bool exist = SaveLoad.CheckFileExist(autoSaveSlot2.GetComponentInChildren<Text>().text);
        if (exist == true)
        {
            saveGameName = autoSaveSlot2.GetComponentInChildren<Text>().text;
            GameData loadedGame = SaveLoad.Load(saveGameName);
            dayProgress.text = "Day: " + loadedGame.dayNumber.ToString();
            dateTime.text = "Time: " + File.GetCreationTime(saveGameName).ToString();
            saveButton.SetActive(true);
            loadButton.SetActive(true);
        }
        else if (exist == false)
        {
            saveGameName = autoSaveSlot2.GetComponentInChildren<Text>().text;
            dayProgress.text = "Day: (Needs a Save)";
            dateTime.text = "Time: (Needs a Save)";
            saveButton.SetActive(true);

        }
    }

    public void SetSave3()
    {
        saveName.text = autoSaveSlot3.GetComponentInChildren<Text>().text;
        bool exist = SaveLoad.CheckFileExist(autoSaveSlot3.GetComponentInChildren<Text>().text);
        if (exist == true)
        {
            saveGameName = autoSaveSlot3.GetComponentInChildren<Text>().text;
            GameData loadedGame = SaveLoad.Load(saveGameName);
            dayProgress.text = "Day: " + loadedGame.dayNumber.ToString();
            dateTime.text = "Time: " + File.GetCreationTime(saveGameName).ToString();
            saveButton.SetActive(true);
            loadButton.SetActive(true);
        }
        else if (exist == false)
        {
            saveGameName = autoSaveSlot3.GetComponentInChildren<Text>().text;
            dayProgress.text = "Day: (Needs a Save)";
            dateTime.text = "Time: (Needs a Save)";
            saveButton.SetActive(true);

        }
    }

    public void Save()
    {
        GameData newSaveGame = new GameData();
        newSaveGame.saveGameName = saveGameName;
        newSaveGame.playerPosX = player.transform.position.x;

        newSaveGame.playerPosY = player.transform.position.y;

        newSaveGame.playerPosZ = player.transform.position.z;

        newSaveGame.playerRotX = player.transform.rotation.eulerAngles.x;

        newSaveGame.playerRotY = player.transform.rotation.eulerAngles.y;

        newSaveGame.playerRotZ = player.transform.rotation.eulerAngles.z;


        newSaveGame.goldValue = player.GetComponent<PlayerStats>().gold;

        newSaveGame.customerOrderNumber = player.GetComponent<PlayerStats>().CustomerOrderNumber;

        newSaveGame.dayNumber = day.GetComponent<DayProgression>().nextDay + 1;

        newSaveGame.cameraRotX = playerCamera.transform.rotation.eulerAngles.x;


        foreach (Ore go in GameObject.FindObjectsOfType<Ore>())
        {
            oreList.Add(go);
        }

        foreach (Guard go in GameObject.FindObjectsOfType<Guard>())
        {
            guardList.Add(go);
        }

        foreach (Handle go in GameObject.FindObjectsOfType<Handle>())
        {
            handleList.Add(go);
        }

        foreach (Blade go in GameObject.FindObjectsOfType<Blade>())
        {
            bladeList.Add(go);
        }

        foreach (Sheet go in GameObject.FindObjectsOfType<Sheet>())
        {
            sheetList.Add(go);
        }

        foreach (Ingot go in GameObject.FindObjectsOfType<Ingot>())
        {
            ingotList.Add(go);
        }

        foreach (Sword go in GameObject.FindObjectsOfType<Sword>())
        {
            swordList.Add(go);
        }

        for (int i = 0; i < oreList.Count; i++)
        {
            OreInfo info = new OreInfo();
            info.OrePosX = oreList[i].gameObject.transform.position.x;
            info.OrePosY = oreList[i].gameObject.transform.position.y;
            info.OrePosZ = oreList[i].gameObject.transform.position.z;
            info.OreRotX = oreList[i].gameObject.transform.rotation.eulerAngles.x;
            info.OreRotY = oreList[i].gameObject.transform.rotation.eulerAngles.y;
            info.OreRotZ = oreList[i].gameObject.transform.rotation.eulerAngles.z;
            info.oreMat = (int)oreList[i].material;

            newSaveGame.OreInfoList.Add(info);
            newSaveGame.oreCount = oreList.Count;
        }

        for (int i = 0; i < guardList.Count; i++)
        {
            GuardInfo info = new GuardInfo();
            info.GuardPosX = guardList[i].gameObject.transform.position.x;
            info.GuardPosY = guardList[i].gameObject.transform.position.y;
            info.GuardPosZ = guardList[i].gameObject.transform.position.z;
            info.GuardRotX = guardList[i].gameObject.transform.rotation.eulerAngles.x;
            info.GuardRotY = guardList[i].gameObject.transform.rotation.eulerAngles.y;
            info.GuardRotZ = guardList[i].gameObject.transform.rotation.eulerAngles.z;
            info.GuardMat = (int)guardList[i].material;
            info.GuardQuality = guardList[i].quality;

            newSaveGame.GuardInfoList.Add(info);
            newSaveGame.guardCount = guardList.Count;
        }

        for (int i = 0; i < handleList.Count; i++)
        {
            HandleInfo info = new HandleInfo();
            info.HandlePosX = handleList[i].gameObject.transform.position.x;
            info.HandlePosY = handleList[i].gameObject.transform.position.y;
            info.HandlePosZ = handleList[i].gameObject.transform.position.z;
            info.HandleRotX = handleList[i].gameObject.transform.rotation.eulerAngles.x;
            info.HandleRotY = handleList[i].gameObject.transform.rotation.eulerAngles.y;
            info.HandleRotZ = handleList[i].gameObject.transform.rotation.eulerAngles.z;
            info.HandleMat = (int)handleList[i].material;
            info.HandleQuality = handleList[i].quality;

            newSaveGame.HandleInfoList.Add(info);
            newSaveGame.handleCount = handleList.Count;
        }

        for (int i = 0; i < bladeList.Count; i++)
        {
            BladeInfo info = new BladeInfo();
            info.BladePosX = bladeList[i].gameObject.transform.position.x;
            info.BladePosY = bladeList[i].gameObject.transform.position.y;
            info.BladePosZ = bladeList[i].gameObject.transform.position.z;
            info.BladeRotX = bladeList[i].gameObject.transform.rotation.eulerAngles.x;
            info.BladeRotY = bladeList[i].gameObject.transform.rotation.eulerAngles.y;
            info.BladeRotZ = bladeList[i].gameObject.transform.rotation.eulerAngles.z;
            info.BladeMat = (int)bladeList[i].material;
            info.BladeSize = (int)bladeList[i].size;
            info.BladeQuality = bladeList[i].quality;

            newSaveGame.BladeInfoList.Add(info);
            newSaveGame.bladeCount = bladeList.Count;
        }

        for (int i = 0; i < sheetList.Count; i++)
        {
            SheetInfo info = new SheetInfo();
            info.SheetPosX = sheetList[i].gameObject.transform.position.x;
            info.SheetPosY = sheetList[i].gameObject.transform.position.y;
            info.SheetPosZ = sheetList[i].gameObject.transform.position.z;
            info.SheetRotX = sheetList[i].gameObject.transform.rotation.eulerAngles.x;
            info.SheetRotY = sheetList[i].gameObject.transform.rotation.eulerAngles.y;
            info.SheetRotZ = sheetList[i].gameObject.transform.rotation.eulerAngles.z;
            info.SheetMat = (int)sheetList[i].material;
            info.SheetSize = (int)sheetList[i].size;
            info.SheetQuality = sheetList[i].quality;

            newSaveGame.SheetInfoList.Add(info);
            newSaveGame.sheetCount = sheetList.Count;
        }

        for (int i = 0; i < ingotList.Count; i++)
        {
            IngotInfo info = new IngotInfo();
            info.IngotPosX = ingotList[i].gameObject.transform.position.x;
            info.IngotPosY = ingotList[i].gameObject.transform.position.y;
            info.IngotPosZ = ingotList[i].gameObject.transform.position.z;
            info.IngotRotX = ingotList[i].gameObject.transform.rotation.eulerAngles.x;
            info.IngotRotY = ingotList[i].gameObject.transform.rotation.eulerAngles.y;
            info.IngotRotZ = ingotList[i].gameObject.transform.rotation.eulerAngles.z;
            info.IngotMat = (int)ingotList[i].material;
            info.IngotReady = ingotList[i].ready;

            newSaveGame.IngotInfoList.Add(info);
            newSaveGame.sheetCount = ingotList.Count;
        }

        for (int i = 0; i < swordList.Count; i++)
        {
            SwordInfo info = new SwordInfo();
            info.SwordPosX = swordList[i].gameObject.transform.position.x;
            info.SwordPosY = swordList[i].gameObject.transform.position.y;
            info.SwordPosZ = swordList[i].gameObject.transform.position.z;
            info.SwordRotX = swordList[i].gameObject.transform.rotation.eulerAngles.x;
            info.SwordRotY = swordList[i].gameObject.transform.rotation.eulerAngles.y;
            info.SwordRotZ = swordList[i].gameObject.transform.rotation.eulerAngles.z;
            info.SwordBladeMat = (int)swordList[i].materialBlade;
            info.SwordGuardMat = (int)swordList[i].materialGuard;
            info.SwordHandleMat = (int)swordList[i].materialHandle;
            info.SwordSize = (int)swordList[i].swordType;
            info.SwordQuality = swordList[i].quality;


            newSaveGame.SwordInfoList.Add(info);
            newSaveGame.swordCount = swordList.Count;
        }

        SaveLoad.Save(newSaveGame);
        saveButton.SetActive(false);
        loadButton.SetActive(false);
    }

    public void Load()
    {
        GameData loadedGame = SaveLoad.Load(saveGameName);
        if (loadedGame != null)
        {
            player.transform.SetPositionAndRotation(new Vector3(loadedGame.playerPosX, loadedGame.playerPosY, loadedGame.playerPosZ),
                Quaternion.Euler(loadedGame.playerRotX, loadedGame.playerRotY, loadedGame.playerRotZ));

            player.GetComponent<PlayerStats>().gold = loadedGame.goldValue;
            player.GetComponent<PlayerStats>().CustomerOrderNumber = loadedGame.customerOrderNumber;
            day.GetComponent<DayProgression>().nextDay = loadedGame.dayNumber - 1;
            day.GetComponent<DayProgression>().dayText.text = "Day " + (loadedGame.dayNumber).ToString();

            motor.RotateCamera(loadedGame.cameraRotX);

            foreach (Ore go in GameObject.FindObjectsOfType<Ore>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Guard go in GameObject.FindObjectsOfType<Guard>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Handle go in GameObject.FindObjectsOfType<Handle>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Blade go in GameObject.FindObjectsOfType<Blade>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Sheet go in GameObject.FindObjectsOfType<Sheet>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Ingot go in GameObject.FindObjectsOfType<Ingot>())
            {
                Destroy(go.transform.gameObject);
            }

            foreach (Sword go in GameObject.FindObjectsOfType<Sword>())
            {
                Destroy(go.transform.gameObject);
            }

            for (int i = 0; i < loadedGame.oreCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.OreInfoList[i].OrePosX, loadedGame.OreInfoList[i].OrePosY, loadedGame.OreInfoList[i].OrePosZ);
                Vector3 rot = new Vector3(loadedGame.OreInfoList[i].OreRotY, loadedGame.OreInfoList[i].OreRotY, loadedGame.OreInfoList[i].OreRotZ);
                GameObject newOre = Instantiate(Ore, pos, Quaternion.Euler(rot));
                newOre.GetComponent<Ore>().material = (global::Ore.OreMaterial)loadedGame.OreInfoList[i].oreMat;
            }

            for (int i = 0; i < loadedGame.guardCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.GuardInfoList[i].GuardPosX, loadedGame.GuardInfoList[i].GuardPosY, loadedGame.GuardInfoList[i].GuardPosZ);
                Vector3 rot = new Vector3(loadedGame.GuardInfoList[i].GuardRotX, loadedGame.GuardInfoList[i].GuardRotY, loadedGame.GuardInfoList[i].GuardRotZ);
                GameObject newGuard = Instantiate(guard, pos, Quaternion.Euler(rot));
                newGuard.GetComponent<Guard>().material = (global::Guard.GuardMaterial)loadedGame.GuardInfoList[i].GuardMat;
                newGuard.GetComponent<Guard>().quality = loadedGame.GuardInfoList[i].GuardQuality;
            }

            for (int i = 0; i < loadedGame.handleCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.HandleInfoList[i].HandlePosX, loadedGame.HandleInfoList[i].HandlePosY, loadedGame.HandleInfoList[i].HandlePosZ);
                Vector3 rot = new Vector3(loadedGame.HandleInfoList[i].HandleRotX, loadedGame.HandleInfoList[i].HandleRotY, loadedGame.HandleInfoList[i].HandleRotZ);
                GameObject newHandle = Instantiate(handle, pos, Quaternion.Euler(rot));
                newHandle.GetComponent<Handle>().material = (global::Handle.HandleMaterial)loadedGame.HandleInfoList[i].HandleMat;
                newHandle.GetComponent<Handle>().quality = loadedGame.HandleInfoList[i].HandleQuality;
            }

            for (int i = 0; i < loadedGame.ingotCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.IngotInfoList[i].IngotPosX, loadedGame.IngotInfoList[i].IngotPosY, loadedGame.IngotInfoList[i].IngotPosZ);
                Vector3 rot = new Vector3(loadedGame.IngotInfoList[i].IngotRotX, loadedGame.IngotInfoList[i].IngotRotY, loadedGame.IngotInfoList[i].IngotRotZ);
                GameObject newIngot = Instantiate(ingot, pos, Quaternion.Euler(rot));
                newIngot.GetComponent<Ingot>().material = (global::Ingot.IngotMaterial)loadedGame.IngotInfoList[i].IngotMat;
                newIngot.GetComponent<Ingot>().ready = loadedGame.IngotInfoList[i].IngotReady;
            }

            for (int i = 0; i < loadedGame.bladeCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.BladeInfoList[i].BladePosX, loadedGame.BladeInfoList[i].BladePosY, loadedGame.BladeInfoList[i].BladePosZ);
                Vector3 rot = new Vector3(loadedGame.BladeInfoList[i].BladeRotX, loadedGame.BladeInfoList[i].BladeRotY, loadedGame.BladeInfoList[i].BladeRotZ);
                if (loadedGame.BladeInfoList[i].BladeSize == (int)global::Blade.Typeblade.small)
                {
                    GameObject newBlade = Instantiate(blade[0], pos, Quaternion.Euler(rot));
                    newBlade.GetComponent<Handle>().material = (global::Handle.HandleMaterial)loadedGame.HandleInfoList[i].HandleMat;
                    newBlade.GetComponent<Handle>().quality = loadedGame.HandleInfoList[i].HandleQuality;
                }
                else if (loadedGame.BladeInfoList[i].BladeSize == (int)global::Blade.Typeblade.medium)
                {
                    GameObject newBlade = Instantiate(blade[1], pos, Quaternion.Euler(rot));
                    newBlade.GetComponent<Handle>().material = (global::Handle.HandleMaterial)loadedGame.HandleInfoList[i].HandleMat;
                    newBlade.GetComponent<Handle>().quality = loadedGame.HandleInfoList[i].HandleQuality;
                }
                else if (loadedGame.BladeInfoList[i].BladeSize == (int)global::Blade.Typeblade.large)
                {
                    GameObject newBlade = Instantiate(blade[2], pos, Quaternion.Euler(rot));
                    newBlade.GetComponent<Handle>().material = (global::Handle.HandleMaterial)loadedGame.HandleInfoList[i].HandleMat;
                    newBlade.GetComponent<Handle>().quality = loadedGame.HandleInfoList[i].HandleQuality;
                }
            }

            for (int i = 0; i < loadedGame.sheetCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.SheetInfoList[i].SheetPosX, loadedGame.SheetInfoList[i].SheetPosY, loadedGame.SheetInfoList[i].SheetPosZ);
                Vector3 rot = new Vector3(loadedGame.SheetInfoList[i].SheetRotX, loadedGame.SheetInfoList[i].SheetRotY, loadedGame.SheetInfoList[i].SheetRotZ);
                if (loadedGame.SheetInfoList[i].SheetSize == (int)global::Sheet.TypeSheet.small)
                {
                    GameObject newSheet = Instantiate(sheet[0], pos, Quaternion.Euler(rot));
                    newSheet.GetComponent<Sheet>().material = (global::Sheet.SheetMaterial)loadedGame.SheetInfoList[i].SheetMat;
                    newSheet.GetComponent<Sheet>().quality = loadedGame.SheetInfoList[i].SheetQuality;
                }
                else if (loadedGame.SheetInfoList[i].SheetSize == (int)global::Sheet.TypeSheet.medium)
                {
                    GameObject newSheet = Instantiate(sheet[1], pos, Quaternion.Euler(rot));
                    newSheet.GetComponent<Sheet>().material = (global::Sheet.SheetMaterial)loadedGame.SheetInfoList[i].SheetMat;
                    newSheet.GetComponent<Sheet>().quality = loadedGame.SheetInfoList[i].SheetQuality;
                }
                else if (loadedGame.SheetInfoList[i].SheetSize == (int)global::Sheet.TypeSheet.large)
                {
                    GameObject newSheet = Instantiate(sheet[2], pos, Quaternion.Euler(rot));
                    newSheet.GetComponent<Sheet>().material = (global::Sheet.SheetMaterial)loadedGame.SheetInfoList[i].SheetMat;
                    newSheet.GetComponent<Sheet>().quality = loadedGame.SheetInfoList[i].SheetQuality;
                }
            }

            for (int i = 0; i < loadedGame.swordCount; i++)
            {
                Vector3 pos = new Vector3(loadedGame.SwordInfoList[i].SwordPosX, loadedGame.SwordInfoList[i].SwordPosY, loadedGame.SwordInfoList[i].SwordPosZ);
                Vector3 rot = new Vector3(loadedGame.SwordInfoList[i].SwordRotX, loadedGame.SwordInfoList[i].SwordRotY, loadedGame.SwordInfoList[i].SwordRotZ);
                if (loadedGame.SwordInfoList[i].SwordSize == (int)global::Sword.SwordType.small)
                {
                    GameObject newSword = Instantiate(sword[0], pos, Quaternion.Euler(rot));
                    newSword.GetComponent<Sword>().materialBlade = (global::Sword.MaterialBlade)loadedGame.SwordInfoList[i].SwordBladeMat;
                    newSword.GetComponent<Sword>().materialGuard = (global::Sword.MaterialGuard)loadedGame.SwordInfoList[i].SwordGuardMat;
                    newSword.GetComponent<Sword>().materialHandle = (global::Sword.MaterialHandle)loadedGame.SwordInfoList[i].SwordHandleMat;
                    newSword.GetComponent<Sword>().quality = loadedGame.SwordInfoList[i].SwordQuality;
                }
                else if (loadedGame.SwordInfoList[i].SwordSize == (int)global::Sword.SwordType.small)
                {
                    GameObject newSword = Instantiate(sword[1], pos, Quaternion.Euler(rot));
                    newSword.GetComponent<Sword>().materialBlade = (global::Sword.MaterialBlade)loadedGame.SwordInfoList[i].SwordBladeMat;
                    newSword.GetComponent<Sword>().materialGuard = (global::Sword.MaterialGuard)loadedGame.SwordInfoList[i].SwordGuardMat;
                    newSword.GetComponent<Sword>().materialHandle = (global::Sword.MaterialHandle)loadedGame.SwordInfoList[i].SwordHandleMat;
                    newSword.GetComponent<Sword>().quality = loadedGame.SwordInfoList[i].SwordQuality;
                }
                else if (loadedGame.SwordInfoList[i].SwordSize == (int)global::Sword.SwordType.small)
                {
                    GameObject newSword = Instantiate(sword[2], pos, Quaternion.Euler(rot));
                    newSword.GetComponent<Sword>().materialBlade = (global::Sword.MaterialBlade)loadedGame.SwordInfoList[i].SwordBladeMat;
                    newSword.GetComponent<Sword>().materialGuard = (global::Sword.MaterialGuard)loadedGame.SwordInfoList[i].SwordGuardMat;
                    newSword.GetComponent<Sword>().materialHandle = (global::Sword.MaterialHandle)loadedGame.SwordInfoList[i].SwordHandleMat;
                    newSword.GetComponent<Sword>().quality = loadedGame.SwordInfoList[i].SwordQuality;
                }
            }

            loadButton.SetActive(false);
            saveButton.SetActive(false);

        }
    }

}
