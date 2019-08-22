using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropPoint : MonoBehaviour
{

    public Sword.SwordType swordBladeType;
    public Sword.MaterialBlade swordBladeMaterial;
    public Sword.MaterialGuard swordGuardMaterial;
    public Sword.MaterialHandle swordHandleMaterial;
    public int quality;

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
        CheckSword(other);
        CheckBlade(other);
        CheckGuard(other);
        CheckHandle(other);
        CheckIngot(other);
        CheckOre(other);
        CheckSheet(other);
    }

    public void CheckSword(Collider other)
    {
        if (other.gameObject.tag == "Iron Sword")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            swordBladeType = item.GetComponent<Sword>().swordType;
            swordBladeMaterial = item.GetComponent<Sword>().materialBlade;
            swordGuardMaterial = item.GetComponent<Sword>().materialGuard;
            swordHandleMaterial = item.GetComponent<Sword>().materialHandle;
            quality = item.GetComponent<Sword>().quality;
            player.QuestHandIn();
        }
    }

    public void CheckGuard(Collider other)
    {
        if (other.gameObject.tag == "Iron Guard")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            guardMaterial = item.GetComponent<Guard>().material;       
            player.QuestHandIn();
        }
    }

    public void CheckIngot(Collider other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            ingotMaterial = item.GetComponent<Ingot>().material;
            player.QuestHandIn();
        }
    }

    public void CheckOre(Collider other)
    {
        if (other.gameObject.tag == "Iron Ore")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            oreMaterial = item.GetComponent<Ore>().material;
            player.QuestHandIn();
        }
    }

    public void CheckBlade(Collider other)
    {
        if (other.gameObject.tag == "Iron Blade")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            bladeMaterial = item.GetComponent<Blade>().material;
            bladeType = item.GetComponent<Blade>().size;
            player.QuestHandIn();
        }
    }

    public void CheckHandle(Collider other)
    {
        if (other.gameObject.tag == "Iron Handle")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            handleMaterial = item.GetComponent<Handle>().material;
            player.QuestHandIn();
        }
    }

    public void CheckSheet(Collider other)
    {
        if (other.gameObject.tag == "Iron Sheet")
        {
            item = other.gameObject;
            item.transform.position = placelocation.position;
            sheetMaterial = item.GetComponent<Sheet>().material;
            sheetType = item.GetComponent<Sheet>().size;
            player.QuestHandIn();
        }
    }

    public void Destroy()
    {
        Destroy(item);
    }
}
