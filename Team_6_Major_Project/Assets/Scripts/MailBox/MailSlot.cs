using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailSlot : MonoBehaviour
{

    public Sword.SwordType bladeType;
    public Sword.MaterialBlade bladeMaterial;
    public Sword.MaterialGuard guardMaterial;
    public Sword.MaterialHandle handleMaterial;

    public Text docketBlade;
    public Text docketHandle;
    public Text docketGuard;

    public MailBox box;

    public int quality;

    public GameObject sword;
    public Transform badlocation;
    public Transform placelocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Iron Sword")
        {
            sword = other.gameObject;
            sword.transform.position = placelocation.position;
            bladeType = sword.GetComponent<Sword>().swordType;
            bladeMaterial = sword.GetComponent<Sword>().materialBlade;
            guardMaterial = sword.GetComponent<Sword>().materialGuard;
            handleMaterial = sword.GetComponent<Sword>().materialHandle;
            quality = sword.GetComponent<Sword>().quality;
            box.CheckItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
