using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;

    public Sword.SwordType bladeType;
    public Sword.MaterialBlade bladeMaterial;
    public Sword.MaterialGuard guardMaterial;
    public Sword.MaterialHandle handleMaterial;

    [TextArea(3, 10)]
    public string[] sentences;

}
