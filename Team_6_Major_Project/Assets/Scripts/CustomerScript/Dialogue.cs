using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;
    public bool special;
    public int specialIndex;

    public Sword.SwordType bladeType;
    public Sword.MaterialBlade bladeMaterial;
    public Sword.MaterialGuard guardMaterial;
    public Sword.MaterialHandle handleMaterial;

    public TextAsset[] textfile;

    [TextArea(3, 10)]
    public string[] sentences;

}
