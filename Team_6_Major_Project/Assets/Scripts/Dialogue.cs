using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string npcName;

    public Blade.Typeblade bladeType;
    public Blade.Material bladeMaterial;
    public Guard.Material guardMaterial;
    public Handle.Material handleMaterial;

    [TextArea(3, 10)]
    public string[] sentences;

}
