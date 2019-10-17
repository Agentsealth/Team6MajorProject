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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Sword") //checks if a sword has been put on the table
        {
            sword = other.gameObject;
            other.gameObject.GetComponent<PickUp>().isHolding = false; //player stops holding the sword forcibly
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.2f, this.gameObject.transform.position.z); //moves sword to position
            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true; //makes sword kinematic

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //sword = null;
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            MTP.gotoEnchant();
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
            }
            if (EnchantString == "FLAME")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.flame;

            }
            if (EnchantString == "SPARK")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.spark;

            }
            if (EnchantString == "TOXIN")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.toxin;

            }
            if (EnchantString == "NECRO")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.necro;

            }
            if (EnchantString == "BLESS")
            {
                sword.GetComponent<Sword>().enchantType = Sword.EnchantType.bless;

            }
        }
    }
}
