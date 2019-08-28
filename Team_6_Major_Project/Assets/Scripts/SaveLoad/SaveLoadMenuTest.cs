using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMenuTest : MonoBehaviour
{
    public string description = "";
    private string saveGameName = "My Saved Game";
    public GameObject player;
    public GameObject playerCamera;
    public PlayerMotor motor;
    public List<ItemSaveData> itemData;
    public int saveOreBool;
    [Header("Loading")]
    public GameObject Ore;
    public int loadOreBool;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        motor = player.GetComponent<PlayerMotor>();
        playerCamera = GameObject.FindWithTag("MainCamera");

    }

    void OnGUI()
    {
        saveGameName = GUI.TextArea(new Rect(20, 0, 50, 100), saveGameName);
        description = GUI.TextArea(new Rect(20, 100, 50, 100), description);

        if (GUI.Button(new Rect(20, 200, 50, 100), "Save"))
        {
            GameData newSaveGame = new GameData();
            newSaveGame.saveGameName = saveGameName;
            newSaveGame.Description = description;
            newSaveGame.playerPosX = player.transform.position.x;
            newSaveGame.playerPosY = player.transform.position.y;
            newSaveGame.playerPosZ = player.transform.position.z;

            newSaveGame.playerRotX = player.transform.rotation.eulerAngles.x;
            newSaveGame.playerRotY = player.transform.rotation.eulerAngles.y;
            newSaveGame.playerRotZ = player.transform.rotation.eulerAngles.z;

            newSaveGame.cameraRotX = playerCamera.transform.rotation.eulerAngles.x;

            foreach(ItemSaveData go in GameObject.FindObjectsOfType<ItemSaveData>())
            {
                itemData.Add(go);
            }

            //itemData = GameObject.FindObjectsOfType<ItemSaveData>();
            for (int i = 0; i < itemData.Count; i++)
            {
                if(itemData[i].oreItem == 1)
                {
                    Debug.Log(newSaveGame.oreItem);
                    newSaveGame.oreItem = new List<int>();
                    //newSaveGame.oreItem = itemData[i].oreItem;

                    newSaveGame.itemPosX[i] = itemData[i].itemPosX;
                    newSaveGame.itemPosY[i] = itemData[i].itemPosY;
                    newSaveGame.itemPosZ[i]= itemData[i].itemPosZ;

                    newSaveGame.itemRotX[i] = itemData[i].itemRotX;
                    newSaveGame.itemRotY[i] = itemData[i].itemRotY;
                    newSaveGame.itemRotZ[i] = itemData[i].itemRotZ;

                    newSaveGame.oreMat[i] = itemData[i].oreMat;
                }
                newSaveGame.itemCount = itemData.Count;
            }

            SaveLoad.Save(newSaveGame);
        }

        if (GUI.Button(new Rect(20, 300, 50, 100), "Load"))
        {
            GameData loadedGame = SaveLoad.Load(saveGameName);
            if (loadedGame != null)
            {
                description = loadedGame.Description;
                player.transform.SetPositionAndRotation(new Vector3(loadedGame.playerPosX, loadedGame.playerPosY, loadedGame.playerPosZ), 
                    Quaternion.Euler(loadedGame.playerRotX,loadedGame.playerRotY, loadedGame.playerRotZ));

                motor.RotateCamera(loadedGame.cameraRotX);

                for (int i = 0; i < loadedGame.itemCount; i++)
                {
                    if (loadedGame.oreItem[i] == 1 )
                    {
                        GameObject ore = Instantiate(Ore, new Vector3(loadedGame.itemPosX[i], loadedGame.itemPosY[i], loadedGame.itemPosZ[i]),
                            Quaternion.Euler(loadedGame.itemRotX[i], loadedGame.itemRotY[i], loadedGame.itemRotZ[i]));
                        ore.GetComponent<Ore>().material = (Ore.OreMaterial)loadedGame.oreMat[i];
                    }
                }
            }
        }
    }
}
