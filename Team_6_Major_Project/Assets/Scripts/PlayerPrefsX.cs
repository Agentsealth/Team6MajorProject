using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsX
{
    //Functions which sets the bool
    public static void SetBool(string name, bool booleanValue)
    {
        PlayerPrefs.SetInt(name, booleanValue ? 1 : 0);
    }
    //Functions which sets the bool
    public static bool GetBool(string name)
    {
        return PlayerPrefs.GetInt(name) == 1 ? true : false;
    }
    //Functions which gets the bool with a default value
    public static bool GetBool(string name, bool defaultValue)
    {
        if (PlayerPrefs.HasKey(name))
        {
            return GetBool(name);
        }

        return defaultValue;
    }
}
