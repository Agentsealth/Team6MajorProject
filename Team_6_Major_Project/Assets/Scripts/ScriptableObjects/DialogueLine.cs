using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueLine : ScriptableObject
{
    [Space]

    public string Name;

    [Space]

    public bool special;

    [Space]

    [TextArea]
    public string Intro;

    [Space]

    [TextArea]
    public string Request;

    [Space]

    [TextArea]
    public string Outro;

    [Space]

    [TextArea]
    public string[] SpecialText;

    [Space]

    public Sword.SwordType bladeType;

    [Space]

    public Sword.MaterialBlade bladeMaterial;

    [Space]

    public Sword.MaterialGuard guardMaterial;

    [Space]

    public Sword.MaterialHandle handleMaterial;

    [Space]

    public int absent;
}
