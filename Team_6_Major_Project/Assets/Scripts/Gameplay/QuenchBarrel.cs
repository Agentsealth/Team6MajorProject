using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchBarrel : MonoBehaviour
{
    private string objectName;
    private Furnace furnace;
    public GameObject smokeP;
    public AudioSource audioSource;
    private GameObject smokeGO;
    public GameObject Parent;
    public Transform drop;
    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.FindObjectOfType<Furnace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //On mouseOver check if input is pressed down on F for snapping gameobject on player hand
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet" ||
                   cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ingot")
            {
                Snapping(Parent.transform.GetChild(0));

            }
        }
        else
        {
            return;
        }
    }

    //Function used to snap object to positon on the barrel
    public void Snapping(Transform other)
    {
        if (other.gameObject.tag == "Iron Ingot")
        {
            if (other.gameObject.GetComponent<Ingot>().ready == true)
            {
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));

                other.position = drop.position;
                other.gameObject.GetComponent<Ingot>().ingotPickup.isHolding = false;
                StartCoroutine(CoolIngot(other.gameObject));

            }
            else
            {
                return;
            }
        }
        else if (other.gameObject.tag == "Iron Sheet")
        {
            if (other.gameObject.GetComponent<Sheet>().ready == true)
            {
                //audioSource.Play();
                smokeGO = Instantiate(smokeP, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
                other.position = drop.position;
                other.gameObject.GetComponent<Sheet>().sheetPickup.isHolding = false;
                StartCoroutine(CoolSheet(other.gameObject));
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
    //Same snapping just for on trigger hitbox 
    private void OnTriggerEnter(Collider other)
    {
        Snapping(other.gameObject.transform);
    }
    //IEnumator which cool down the sheet
    IEnumerator CoolSheet(GameObject other)
    {
        yield return new WaitForSeconds(2.5f);
        other.GetComponent<Sheet>().ready = false;
        objectName = other.GetComponent<Sheet>().objectName;

        other.name = objectName + " (Not Ready)";
        yield return new WaitForSeconds(5);


    }
    //IEnumator which cool down the ingot
    IEnumerator CoolIngot(GameObject other)
    {
        yield return new WaitForSeconds(2.5f);

        other.GetComponent<Ingot>().ready = false;
        objectName = other.GetComponent<Ingot>().objectName;

        other.name = objectName + " (Not Ready)";
        yield return new WaitForSeconds(5);
       
    }
}

