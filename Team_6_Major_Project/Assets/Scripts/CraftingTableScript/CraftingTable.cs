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
    public GameObject Parent;


    public GameObject[] sword;

    public Transform sworddrop;
    public Transform sidedrop;
    public Transform guardPos;
    public Transform handlePos;
    public Transform bastardBladePos;
    public Transform longBladePos;
    public Transform smallBladePos;

    public Blade.BladeMaterial bladeMaterial;
    public Handle.HandleMaterial handleMaterial;
    public Guard.GuardMaterial guardMaterial;
    public Blade.Typeblade bladeType;

    public AudioSource craftingNoise;
    public CraftingBook craftingBook;

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

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bladeCount > 0 && guardCount > 0 && handleCount > 0)
            {

                craftingNoise.Play();
                if (tut.textPos == 21 || tut.textPos == 20)
                {
                    tut.ProgressTutorial(21);
                }
                Craft();

            }
            else
            {
                int cCount = Parent.transform.childCount;

                if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Blade" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Guard" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Handle")
                {
                    help(Parent.transform.GetChild(0));
                }
            }
        }
    }

    public void help(Transform other)
    {
       
        if (other.gameObject.tag == "Iron Blade")
        {
            if (tut.textPos == 15 || tut.textPos == 14)
            {
                tut.ProgressTutorial(15);
            }
            if (bladeCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                bladeType = other.gameObject.GetComponent<Blade>().size;
                if (bladeType == (Blade.Typeblade)1)
                {
                    craftingBook.swordBlade[0].color = Color.green;
                    other.gameObject.GetComponent<PickUp>().isHolding = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.position = smallBladePos.position;
                    other.rotation = smallBladePos.rotation;
                }
                else if (bladeType == (Blade.Typeblade)2)
                {
                    craftingBook.swordBlade[1].color = Color.green;
                    other.gameObject.GetComponent<PickUp>().isHolding = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.position = longBladePos.position;
                    other.rotation = longBladePos.rotation;

                }
                else if (bladeType == (Blade.Typeblade)3)
                {
                    craftingBook.swordBlade[2].color = Color.green;
                    other.gameObject.GetComponent<PickUp>().isHolding = false;
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    other.position = bastardBladePos.position;
                    other.rotation = bastardBladePos.rotation;
                }
                bladeMaterial = other.gameObject.GetComponent<Blade>().material;
                bladeQuality = other.gameObject.GetComponent<Blade>().quality;
                blade = other.gameObject;
                bladeCount++;
                
            }
        }
        else if (other.gameObject.tag == "Iron Guard")
        {
            if (guardCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                other.gameObject.GetComponent<PickUp>().isHolding = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.position = guardPos.position;
                other.rotation = guardPos.rotation;
                guardMaterial = other.gameObject.GetComponent<Guard>().material;
                guardQuality = other.gameObject.GetComponent<Guard>().quality;
                guard = other.gameObject;
                for (int i = 0; i < craftingBook.swordGuard.Length; i++)
                {
                    craftingBook.swordGuard[i].color = Color.green;
                }
                guardCount++;
            }
        }
        else if (other.gameObject.tag == "Iron Handle")
        {
            if (handleCount > 1)
            {
                other.gameObject.transform.position = sidedrop.position;
            }
            else
            {
                other.gameObject.GetComponent<PickUp>().isHolding = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.position = handlePos.position;
                other.rotation = handlePos.rotation;
                handleMaterial = other.gameObject.GetComponent<Handle>().material;
                handleQuality = other.gameObject.GetComponent<Handle>().quality;
                handle = other.gameObject;
                for (int i = 0; i < craftingBook.swordHandle.Length; i++)
                {
                    craftingBook.swordHandle[i].color = Color.green;
                }
                handleCount++;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Iron Blade")
        //{
        //    if (tut.textPos == 15 || tut.textPos == 14)
        //    {
        //        tut.ProgressTutorial(15);
        //    }
        //    if (bladeCount > 1)
        //    {
        //        other.gameObject.transform.position = sidedrop.position;
        //    }
        //    else
        //    {
        //        bladeMaterial = other.gameObject.GetComponent<Blade>().material;
        //        bladeType = other.gameObject.GetComponent<Blade>().size;
        //        bladeQuality = other.gameObject.GetComponent<Blade>().quality;
        //        blade = other.gameObject;
        //        bladeCount++;
        //        if(bladeType == (Blade.Typeblade)1)
        //        {
        //            craftingBook.swordBlade[0].color = Color.green;
        //        }
        //        else if (bladeType == (Blade.Typeblade)2)
        //        {
        //            craftingBook.swordBlade[1].color = Color.green;
        //        }
        //        else if (bladeType == (Blade.Typeblade)3)
        //        {
        //            craftingBook.swordBlade[2].color = Color.green;
        //        }
        //    }
        //}
        //else if(other.gameObject.tag == "Iron Guard")
        //{
        //    if (guardCount > 1)
        //    {
        //        other.gameObject.transform.position = sidedrop.position;
        //    }
        //    else
        //    {
        //        guardMaterial = other.gameObject.GetComponent<Guard>().material;
        //        guardQuality = other.gameObject.GetComponent<Guard>().quality;
        //        guard = other.gameObject;
        //        for (int i = 0; i < craftingBook.swordGuard.Length; i++)
        //        {
        //            craftingBook.swordGuard[i].color = Color.green;
        //        }
        //        guardCount++;              
        //    }
        //}
        //else if(other.gameObject.tag == "Iron Handle")
        //{
        //    if (handleCount > 1)
        //    {
        //        other.gameObject.transform.position = sidedrop.position;
        //    }
        //    else
        //    {
        //        handleMaterial = other.gameObject.GetComponent<Handle>().material;
        //        handleQuality = other.gameObject.GetComponent<Handle>().quality;
        //        handle = other.gameObject;
        //        for (int i = 0; i < craftingBook.swordHandle.Length; i++)
        //        {
        //            craftingBook.swordHandle[i].color = Color.green;
        //        }
        //        handleCount++;
        //    }
        //}
    }

    public void Craft()
    {
        if(bladeType == Blade.Typeblade.small)
        {
            GameObject small = Instantiate(sword[0], sworddrop.position, Quaternion.identity);
            small.GetComponent<Sword>().materialBlade = (Sword.MaterialBlade)bladeMaterial;
            small.GetComponent<Sword>().materialGuard = (Sword.MaterialGuard)guardMaterial;
            small.GetComponent<Sword>().materialHandle = (Sword.MaterialHandle)handleMaterial;
            AverageQuality();
            small.GetComponent<Sword>().quality = totalQuality;
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
            medium.GetComponent<Sword>().materialBlade = (Sword.MaterialBlade)bladeMaterial;
            medium.GetComponent<Sword>().materialGuard = (Sword.MaterialGuard)guardMaterial;
            medium.GetComponent<Sword>().materialHandle = (Sword.MaterialHandle)handleMaterial;
            AverageQuality();
            medium.GetComponent<Sword>().quality = totalQuality;
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
            large.GetComponent<Sword>().materialBlade = (Sword.MaterialBlade)bladeMaterial;
            large.GetComponent<Sword>().materialGuard = (Sword.MaterialGuard)guardMaterial;
            large.GetComponent<Sword>().materialHandle = (Sword.MaterialHandle)handleMaterial;
            AverageQuality();
            large.GetComponent<Sword>().quality = totalQuality;
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

        for (int i = 0; i < craftingBook.swordGuard.Length; i++)
        {
            craftingBook.swordGuard[i].color = Color.black;
            craftingBook.swordBlade[i].color = Color.black;
            craftingBook.swordHandle[i].color = Color.black;

        }
    }

    public void AverageQuality()
    {
        totalQuality = (handleQuality + guardQuality + bladeQuality) / 3;
    }
}
