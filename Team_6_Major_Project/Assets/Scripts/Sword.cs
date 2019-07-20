using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public enum SwordType { small, medium, large };
    public enum MaterialBlade { iron, silver, gold };
    public enum MaterialHandle { iron, silver, gold };
    public enum MaterialGuard { iron, silver, gold };

    public SwordType swordType;
    public MaterialBlade materialBlade;
    public MaterialHandle materialHandle;
    public MaterialGuard materialGuard;

    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
