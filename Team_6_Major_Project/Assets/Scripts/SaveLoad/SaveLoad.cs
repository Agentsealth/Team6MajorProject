using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    public static void Save(GameData saveGame)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("C:/Users/s181545/Desktop/" + saveGame.saveGameName + ".sav");
        bf.Serialize(file, saveGame);
        file.Close();
        Debug.Log("Saved Game: " + saveGame.saveGameName);

    }

    public static GameData Load(string gameToLoad)
    {
        if(File.Exists("C:/Users/s181545/Desktop/" + gameToLoad + ".sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("C:/Users/s181545/Desktop/" + gameToLoad + ".sav", FileMode.Open);
            GameData loadedGame = (GameData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loaded Game" + loadedGame.saveGameName);
            return loadedGame;
        }
        else
        {
            Debug.Log("File doesn't exist");
            return null;
        }
    }

}
