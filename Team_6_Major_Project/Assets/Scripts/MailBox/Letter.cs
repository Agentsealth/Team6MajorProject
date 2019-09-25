using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Letter
{ 
    [TextArea(3, 10)]
    public string[] npcName;

    //public bool order;
    public int specialIndex;

    public Sword.SwordType[] bladeType;
    public Sword.MaterialBlade[] bladeMaterial;
    public Sword.MaterialGuard[] guardMaterial;
    public Sword.MaterialHandle[] handleMaterial;

    public TextAsset[] letterFile;
    //public TextAsset[] namefile;

    public string[] sentences;
 
}
