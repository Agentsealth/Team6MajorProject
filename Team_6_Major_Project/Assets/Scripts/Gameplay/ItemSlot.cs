using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{

    public int slotNumber;

    public Sword.SwordType bladeType;
    public Sword.MaterialBlade bladeMaterial;
    public Sword.MaterialGuard guardMaterial;
    public Sword.MaterialHandle handleMaterial;

    public TestDialogueTrigger[] npc;

    public GameObject sword;
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
            npc = FindObjectsOfType<TestDialogueTrigger>();
            sword = other.gameObject;
            sword.transform.position = placelocation.position;
            SetItemSlot();
            bladeType = sword.GetComponent<Sword>().swordType;
            bladeMaterial = sword.GetComponent<Sword>().materialBlade;
            guardMaterial = sword.GetComponent<Sword>().materialGuard;
            handleMaterial = sword.GetComponent<Sword>().materialHandle;                  
        }
    }

    public void SetItemSlot()
    {
        for (int i = 0; i < npc.Length; i++)
        {
            if (slotNumber == npc[i].CustomerNumber)
            {
                npc[i].WaypointUpdate();
            }
        }
    }
}

