using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sharpenDemo : MonoBehaviour
{
    public bool isGrinding;
    // Start is called before the first frame update
    GameObject otherOther = null;
    public GameObject handle;
    public int i;
    Vector3 initialPosition;
    public float endPosition;
    public movePlayerToPos MPTP;
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (i >= 100)
        {
            Destroy(otherOther);
            Instantiate(handle, initialPosition, Quaternion.identity);
            MPTP.returnToPos();
            i = 0;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isGrinding = true;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isGrinding = false;
        }
        if (otherOther != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
               
                Debug.Log("Yeet");
                //Destroy(this);
                otherOther.GetComponent<Rigidbody>().isKinematic = false;
                otherOther.transform.position = new Vector3(0,0,0);
            }

            if (isGrinding)
            {
                {
                    transform.position = new Vector3(initialPosition.x, initialPosition.y, 4.94f );
                    otherOther.transform.position = transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z + endPosition);

                    otherOther.transform.eulerAngles = new Vector3(0, 0, 0);
                    i++;
                }


            }
            if (!isGrinding)
            {
                {
                    otherOther.transform.position =  initialPosition;
                   
                    otherOther.transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }

    }

    void yes()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gsHazard")
        {
            Debug.Log("This works");
            isGrinding = false;
        }
        if (other.gameObject.tag == "Iron Sheet")
        {
            if (other.GetComponent<Sheet>().size == Sheet.TypeSheet.small)
            {
                MPTP.gotoGrinder();

                otherOther = other.gameObject;
                other.transform.position = new Vector3(0, 0, 0);
                Debug.Log("Oh [redacted] a bug");
                other.transform.parent = null;


                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                other.transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("A R E A [redacted]");
            }
        }

    }


    
}
