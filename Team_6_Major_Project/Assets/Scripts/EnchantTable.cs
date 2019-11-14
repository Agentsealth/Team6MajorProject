using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnchantTable : MonoBehaviour
{
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;
    public GameObject Wheel4;
    public GameObject Wheel5;
    public string EnchantString;
    private GameObject sword;
    public Text text;

    public MoveToPos MTP;

    public GameObject Parent;

    public GameObject outline;

    public AudioSource enchSound;

    public int PinNumber;
    // Start is called before the first frame update
    void Start()
    {
        Parent = GameObject.Find("Parent");
        MTP = FindObjectOfType<MoveToPos>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Sword") //checks if a sword has been put on the table
        {
           /* sword = other.gameObject;
            other.gameObject.GetComponent<PickUp>().isHolding = false; //player stops holding the sword forcibly
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.2f, this.gameObject.transform.position.z); //moves sword to position
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //makes sword kinematic
            */
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //sword = null;
    }

    private void OnMouseExit()
    {
        //outline.SetActive(false);
    }

    private void OnMouseOver()
    {
        //outline.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sword")
            {
                sword = Parent.transform.GetChild(0).gameObject;
                sword.GetComponent<PickUp>().isHolding = false; //player stops holding the sword forcibly
                sword.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.2f, this.gameObject.transform.position.z);
            }
            else if (sword != null)
            {
                MTP.gotoEnchant();
            }
        }

    }
    public void Enchant()
    {

        if (sword != null) //ensure the sword is still in there.
        {

            //Creates a string from wheel numbers.
            EnchantString = "" + Wheel1.GetComponent<EnchantPINWheel>().SelectedRune + Wheel2.GetComponent<EnchantPINWheel>().SelectedRune +
                Wheel3.GetComponent<EnchantPINWheel>().SelectedRune + Wheel4.GetComponent<EnchantPINWheel>().SelectedRune + Wheel5.GetComponent<EnchantPINWheel>().SelectedRune;
            text.text = EnchantString; //sets prior to a thing in world for debug
            if (EnchantString == "CHILL") //list of checks for possible enchantments and applies appropriate enchant to sword
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.chill;
                enchSound.Play();
            }
            if (EnchantString == "EMBER")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.flame;
                enchSound.Play();
            }
            if (EnchantString == "PYLON")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.spark;
                enchSound.Play();
            }
            if (EnchantString == "TOXIC")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.toxin;
                enchSound.Play();
            }
            if (EnchantString == "NECRO")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.necro;
                enchSound.Play();
            }
            if (EnchantString == "BLESS")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.bless;
                enchSound.Play();
            }
        }
    }
}
