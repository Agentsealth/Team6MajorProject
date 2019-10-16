using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public int slotNumber;

    public Sword.SwordType bladeType;
    public Sword.MaterialBlade bladeMaterial;
    public Sword.MaterialGuard guardMaterial;
    public Sword.MaterialHandle handleMaterial;

    public Text docketBlade;
    public Text docketHandle;
    public Text docketGuard;

    public int quality;

    public TestDialogueTrigger[] npc;

    public GameObject sword;
    public Transform badlocation;
    public Transform placelocation;

    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        tut = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Sword")
        {
            if (tut.textPos == 22 || tut.textPos == 21)
            {
                tut.ProgressTutorial(22);
            }
            npc = FindObjectsOfType<TestDialogueTrigger>();
            sword = other.gameObject;
            sword.transform.position = placelocation.position;
            sword.transform.rotation = placelocation.rotation;
            sword.GetComponent<PickUp>().shopHold = true;
            SetItemSlot();
            bladeType = sword.GetComponent<Sword>().swordType;
            bladeMaterial = sword.GetComponent<Sword>().materialBlade;
            guardMaterial = sword.GetComponent<Sword>().materialGuard;
            handleMaterial = sword.GetComponent<Sword>().materialHandle;
            quality = sword.GetComponent<Sword>().quality;
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

