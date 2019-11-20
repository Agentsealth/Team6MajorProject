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

    public Transform swordDrop;
    public Transform sideDrop;
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

    void OnMouseOver()
    {
        //When mouse is hovering over the gameobject and player presses F
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Checks if bladeCount and guardCount and handleCount is greater than 0
            if (bladeCount > 0 && guardCount > 0 && handleCount > 0)
            {
                //Plays audioSource
                craftingNoise.Play();
                //Checks if the textIndex for the tutorial is either 20 or 21
                if (tut.textPos == 21 || tut.textPos == 20)
                {
                    //Runs the function Progress tutorial in the tutorial script to index 21
                    tut.ProgressTutorial(21);
                }
                //Runs the craft function
                Craft();

            }
            else
            {
                //Sets the int value of cCount based of the player's hand child count
                int cCount = Parent.transform.childCount;
                //Checks if cCount is greater than 0 checks if the player's hand child's tag is either a Iron Blade or Iron Guard or Iron Handle
                if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Blade" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Guard" ||
                    cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Handle")
                {
                    //Snapping of the gameobjec to a position on the anvil
                    Snapping(Parent.transform.GetChild(0));
                }
            }
        }
    }

    public void Snapping(Transform other)
    {
        //Checks if the gameObject tag is an Iron Blade
        if (other.gameObject.tag == "Iron Blade")
        {
            //Checks if the textIndex for the tutorial is either 14 or 15
            if (tut.textPos == 15 || tut.textPos == 14)
            {
                //Runs the function Progress tutorial in the tutorial script to index 15
                tut.ProgressTutorial(15);
            }
            //Checks if the blade Count count is more than 1
            if (bladeCount > 1)
            {
                //Sets the gameobjects position to a position which is decided beforehand which is in sideDrop
                other.gameObject.transform.position = sideDrop.position;
            }
            else
            {
                //Sets the blade type to the gameobject's size
                bladeType = other.gameObject.GetComponent<Blade>().size;
                //Checks if the bladeType is equal to 1
                if (bladeType == (Blade.Typeblade)1)
                {
                    bladeCrafting(0, other);
                }
                else if (bladeType == (Blade.Typeblade)2)
                {
                    bladeCrafting(1, other);


                }
                else if (bladeType == (Blade.Typeblade)3)
                {
                    bladeCrafting(2, other);

                }          
            }
        }
        //Checks if the gameObject tag is an Iron Guard
        else if (other.gameObject.tag == "Iron Guard")
        {
            //Checks if the guard Count count is more than 1
            if (guardCount > 1)
            {
                //Sets the gameobjects position to a position which is decided beforehand which is in sideDrop
                other.gameObject.transform.position = sideDrop.position;
            }
            else
            {
                //Runs the reset kinematic function
                resettingKinematics(other);
                //Sets the gameObject's positon to the guardPosition
                other.position = guardPos.position;
                //Sets the gameObject's rotation to the guardPositon's rotation
                other.rotation = guardPos.rotation;
                //Sets the guardMaterial to the gameObjects material
                guardMaterial = other.gameObject.GetComponent<Guard>().material;
                //Sets the guardQuality to the gameObject's quality
                guardQuality = other.gameObject.GetComponent<Guard>().quality;
                //Sets guard as the gameobject
                guard = other.gameObject;
                //A for loop which goes through the craftingBooks's swordGuard Image length
                for (int i = 0; i < craftingBook.swordGuard.Length; i++)
                {
                    //Sets a swordGuard Image on the crafting book to green
                    craftingBook.swordGuard[i].color = Color.green;
                }
                //Increase the guardCount by 1
                guardCount++;
            }
        }
        //Checks if the gameObject tag is an Iron Handle
        else if (other.gameObject.tag == "Iron Handle")
        {
            //Checks if the handle Count count is more than 1
            if (handleCount > 1)
            {
                //Sets the gameobjects position to a position which is decided beforehand which is in sideDrop
                other.gameObject.transform.position = sideDrop.position;
            }
            else
            {
                //Runs the reset kinematic function
                resettingKinematics(other);
                //Sets the gameObject's positon to the handlePosition
                other.position = handlePos.position;
                //Sets the gameObject's rotation to the handlePositon's rotation
                other.rotation = handlePos.rotation;
                //Sets the handleMaterial to the gameObjects material
                handleMaterial = other.gameObject.GetComponent<Handle>().material;
                //Sets the handleQuality to the gameObject's quality
                handleQuality = other.gameObject.GetComponent<Handle>().quality;
                //Sets handle as the gameobject
                handle = other.gameObject;
                //A for loop which goes through the craftingBooks's swordHandle Image length
                for (int i = 0; i < craftingBook.swordHandle.Length; i++)
                {
                    //Sets a swordHandle Image on the crafting book to green
                    craftingBook.swordHandle[i].color = Color.green;
                }
                //Increase the handleCount by 1
                handleCount++;
            }
        }
    }
      
    public void Craft()
    {
        //Checks if the bladetype is equal to the small blade
        if(bladeType == Blade.Typeblade.small)
        {
            //Runs the sword crafting function for small sword
            swordCrafting(0);
        }
        //Checks if the bladetype is equal to the medium blade
        else if (bladeType == Blade.Typeblade.medium)
        {
            //Runs the sword crafting function for medium sword
            swordCrafting(1);
        }
        //Checks if the bladetype is equal to the large blade
        else if (bladeType == Blade.Typeblade.large)
        {
            //Runs the sword crafting function for large sword
            swordCrafting(2);
        }

        //A for loop which goes through the craftingBooks's swordGuard Image length
        for (int i = 0; i < craftingBook.swordGuard.Length; i++)
        {
            //Sets a swordGuard Image on the crafting book to black
            craftingBook.swordGuard[i].color = Color.black;
            //Sets a swordBlade Image on the crafting book to black
            craftingBook.swordBlade[i].color = Color.black;
            //Sets a swordHandle Image on the crafting book to black
            craftingBook.swordHandle[i].color = Color.black;

        }
    }

    void bladeCrafting(int index, Transform other)
    {
        //Sets a swordBlade Image on the crafting book to green
        craftingBook.swordBlade[index].color = Color.green;
        //Runs the reset kinematic function
        resettingKinematics(other);
        if (index == 0)
        {
            //Sets the gameObject's positon to the smallBladePosition
            other.position = smallBladePos.position;
            //Sets the gameObhect's rotation to the smallBladePositon's rotation
            other.rotation = smallBladePos.rotation;
        }
        else if(index == 1)
        {
            //Sets the gameObject's positon to the longBladePosition
            other.position = longBladePos.position;
            //Sets the gameObject's rotation to the longBladePositon's rotation
            other.rotation = longBladePos.rotation;
        }
        else if(index == 2)
        {
            //Sets the gameObject's positon to the bastardBladePosition
            other.position = bastardBladePos.position;
            //Sets the gameObhect's rotation to the bastardBladePositon's rotation
            other.rotation = bastardBladePos.rotation;
        }
        //Sets the bladeMaterial to the gameObjects material
        bladeMaterial = other.gameObject.GetComponent<Blade>().material;
        //Sets the baladeQuality to the gameObject's quality
        bladeQuality = other.gameObject.GetComponent<Blade>().quality;
        //Sets blade as the gameobject
        blade = other.gameObject;
        //Increase the bladeCount by 1
        bladeCount++;
    }

    void swordCrafting(int index)
    {
        //Creates a small sword prefab at a drop position
        GameObject swordPrefab = Instantiate(sword[index], swordDrop.position, Quaternion.identity);
        //Sets the material blade based on the bladeMaterial
        swordPrefab.GetComponent<Sword>().materialBlade = (Sword.MaterialBlade)bladeMaterial;
        //Sets the material guard based on the guardMaterial
        swordPrefab.GetComponent<Sword>().materialGuard = (Sword.MaterialGuard)guardMaterial;
        //Sets the material handle based on the handleMaterial
        swordPrefab.GetComponent<Sword>().materialHandle = (Sword.MaterialHandle)handleMaterial;
        //Runs the average quality function
        AverageQuality();
        //Sets the sword quality to the total quality which is calculated in the function average quality
        swordPrefab.GetComponent<Sword>().quality = totalQuality;
        //Destroy the blade
        Destroy(blade);
        //Destroy the handle
        Destroy(handle);
        //Destroy the guard
        Destroy(guard);
        //Resets the handleQuality to 0
        handleQuality = 0;
        //Resets the guardQuality to 0
        guardQuality = 0;
        //Resets the bladeQuality to 0
        bladeQuality = 0;
        //Resets the handleCount to 0
        handleCount = 0;
        //Resets the guardCount to 0
        guardCount = 0;
        //Resets the bladeCount to 0
        bladeCount = 0;
    }

    void resettingKinematics(Transform other)
    {
        //Sets the gameObject's isHolding to false
        other.gameObject.GetComponent<PickUp>().isHolding = false;
        //Sets the gameObject's rigidbody iskinematic to true
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void AverageQuality()
    {
        //Averages the quality between guard + handle + blade qualities
        totalQuality = (handleQuality + guardQuality + bladeQuality) / 3;
    }
}
