using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropPoint : MonoBehaviour
{

    public Sword.SwordType swordBladeType;
    public Sword.MaterialBlade swordBladeMaterial;
    public Sword.MaterialGuard swordGuardMaterial;
    public Sword.MaterialHandle swordHandleMaterial;

    public Ingot.IngotMaterial ingotMaterial;

    public Ore.OreMaterial oreMaterial;

    public Guard.GuardMaterial guardMaterial;

    public Handle.HandleMaterial handleMaterial;

    public Blade.Typeblade bladeType;
    public Blade.BladeMaterial bladeMaterial;

    public Sheet.TypeSheet sheetType;
    public Sheet.SheetMaterial sheetMaterial;

    public PlayerStats player;

    public GameObject item;

    public Transform badlocation;
    public Transform placelocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Sword")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            swordBladeType = item.GetComponent<Sword>().swordType;
            swordBladeMaterial = item.GetComponent<Sword>().materialBlade;
            swordGuardMaterial = item.GetComponent<Sword>().materialGuard;
            swordHandleMaterial = item.GetComponent<Sword>().materialHandle;
            player.QuestHandIn();
        }
    }

    public void Destroy()
    {
        Destroy(item);
    }
}
