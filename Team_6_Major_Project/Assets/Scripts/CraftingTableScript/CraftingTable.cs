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
    public Handle.HandleMaterial handleMaterial;
    public Guard.GuardMaterial guardMaterial;
    public Blade.Typeblade bladeType;

    public AudioSource craftingNoise;
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
                craftingNoise.Play();
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
            GameObject small = Instantiate(sword[0], sworddrop.position, Quaternion.identity);
            small.GetComponent<SwordTempVer>().materialBlade = (SwordTempVer.MaterialBlade)bladeMaterial;
            small.GetComponent<SwordTempVer>().materialGuard = (SwordTempVer.MaterialGuard)guardMaterial;
            small.GetComponent<SwordTempVer>().materialHandle = (SwordTempVer.MaterialHandle)handleMaterial;
            AverageQuality();
            small.GetComponent<SwordTempVer>().quality = totalQuality;
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
            GameObject medium = Instantiate(sword[1], sworddrop.position, Quaternion.identity);
            medium.GetComponent<SwordTempVer>().materialBlade = (SwordTempVer.MaterialBlade)bladeMaterial;
            medium.GetComponent<SwordTempVer>().materialGuard = (SwordTempVer.MaterialGuard)guardMaterial;
            medium.GetComponent<SwordTempVer>().materialHandle = (SwordTempVer.MaterialHandle)handleMaterial;
            AverageQuality();
            medium.GetComponent<SwordTempVer>().quality = totalQuality;
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
            GameObject large = Instantiate(sword[2], sworddrop.position, Quaternion.identity);
            large.GetComponent<SwordTempVer>().materialBlade = (SwordTempVer.MaterialBlade)bladeMaterial;
            large.GetComponent<SwordTempVer>().materialGuard = (SwordTempVer.MaterialGuard)guardMaterial;
            large.GetComponent<SwordTempVer>().materialHandle = (SwordTempVer.MaterialHandle)handleMaterial;
            AverageQuality();
            large.GetComponent<SwordTempVer>().quality = totalQuality;
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

    public void AverageQuality()
    {
        totalQuality = (handleQuality + guardQuality + bladeQuality) / 3;
    }
}
