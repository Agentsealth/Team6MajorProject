using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatheLogic : MonoBehaviour
{

    public GameObject LatheTool;
    public MoveToPos MTP;

    public GameObject Gouge;
    public bool isLathing;
    private GameObject Other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLathing)
        {
            if (Input.GetAxis("Mouse X") < -0.7f)
            {
                Gouge.transform.position = new Vector3(Gouge.transform.position.x - 0.01f, Gouge.transform.position.y, Gouge.transform.position.z);
            }
            if (Input.GetAxis("Mouse X") > 0.7f)
            {
                Gouge.transform.position = new Vector3(Gouge.transform.position.x + 0.01f, Gouge.transform.position.y, Gouge.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Gouge.transform.position = new Vector3(Gouge.transform.position.x, Gouge.transform.position.y, Gouge.transform.position.z + 0.1f);

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                Gouge.transform.position = new Vector3(Gouge.transform.position.x, Gouge.transform.position.y, Gouge.transform.position.z - 0.1f);

            }
        }
        if(Other.transform.childCount == 0 && Other != null && isLathing)
        {
            isLathing = false;
            MTP.returnToPos();
            Other.gameObject.GetComponent<ObjectRotator>().enabled = false;
            Other.transform.position = MTP.loc4.transform.localPosition;
            Other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Stick")
        {
            Other = other.gameObject;
            other.transform.rotation = Quaternion.Euler(0, 0, 0);

            other.gameObject.GetComponent<PickUp>().isHolding = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = LatheTool.transform.position;
            other.gameObject.GetComponent<ObjectRotator>().enabled = true;
            //other.transform.localScale = new Vector3(4.633873f, 1.415059f, 0.2828704f);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isLathing = true;
            MTP.gotoLathe();
        }
    }

    private void FinishLathe()
    {
        Other.gameObject.GetComponent<ObjectRotator>().enabled = false;
        Other.transform.position = MTP.loc4.transform.position;
        Other.gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }
}
