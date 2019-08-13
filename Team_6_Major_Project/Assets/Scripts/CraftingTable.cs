using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public int bladeCount;
    public int handleCount;
    public int guardCount;

    public int bladeQuality;
    public int handleQuality;
    public int guardQuality;
    public int totalQuality;

    public GameObject blade;
    public GameObject handle;
    public GameObject guard;

    public GameObject[] sword;

    public Transform sworddrop;
    public Transform sidedrop;

    public Blade.BladeMaterial bladeMaterial;
    public Handle.Material handleMaterial;
    public Guard.Material guardMaterial;
    public Blade.Typeblade bladeType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (bladeCount > 0 && guardCount > 0 && handleCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Craft();
            }
        }
        else
        {
            return;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Blade")
        {
            if (bladeCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                bladeMaterial = other.gameObject.GetComponent<Blade>().material;
                bladeType = other.gameObject.GetComponent<Blade>().size;
                bladeQuality = other.gameObject.GetComponent<Blade>().quality;
                blade = other.gameObject;
                bladeCount++;
            }
        }
        else if(other.gameObject.tag == "Iron Guard")
        {
            if (guardCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                guardMaterial = other.gameObject.GetComponent<Guard>().material;
                guardQuality = other.gameObject.GetComponent<Guard>().quality;
                guard = other.gameObject;
                guardCount++;
            }
        }
        else if(other.gameObject.tag == "Iron Handle")
        {
            if (handleCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                handleMaterial = other.gameObject.GetComponent<Handle>().material;
                handleQuality = other.gameObject.GetComponent<Handle>().quality;
                handle = other.gameObject;
                handleCount++;
            }
        }
    }

    public void Craft()
    {
        if(bladeType == Blade.Typeblade.small)
        {
            Instantiate(sword[0], sworddrop.position, Quaternion.identity);
            Destroy(blade);
            Destroy(handle);
            Destroy(guard);
            handleQuality = 0;
            guardQuality = 0;
            bladeQuality = 0;
            handleCount = 0;
            guardCount = 0;
            bladeCount = 0;
        }
        else if (bladeType == Blade.Typeblade.medium)
        {
            Instantiate(sword[1], sworddrop.position, Quaternion.identity);
            Destroy(blade);
            Destroy(handle);
            Destroy(guard);
            handleQuality = 0;
            guardQuality = 0;
            bladeQuality = 0;
            handleCount = 0;
            guardCount = 0;
            bladeCount = 0;
        }
        else if (bladeType == Blade.Typeblade.large)
        {
            Instantiate(sword[2], sworddrop.position, Quaternion.identity);
            Destroy(blade);
            Destroy(handle);
            Destroy(guard);
            handleQuality = 0;
            guardQuality = 0;
            bladeQuality = 0;
            handleCount = 0;
            guardCount = 0;
            bladeCount = 0;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Iron Sword")
        {
            other.gameObject.GetComponent<Sword>().materialBlade = (Sword.MaterialBlade)bladeMaterial;
            other.gameObject.GetComponent<Sword>().materialGuard = (Sword.MaterialGuard)guardMaterial;
            other.gameObject.GetComponent<Sword>().materialHandle = (Sword.MaterialHandle)handleMaterial;
            totalQuality = (handleQuality + guardQuality + bladeQuality) / 3;
        }
    }
}
