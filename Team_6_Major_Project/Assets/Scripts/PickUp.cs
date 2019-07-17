using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float throwForce = 600;
    public Vector3 scale;
    public Vector3 objectPos;
    public float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    private void Start()
    {
        scale = item.transform.localScale;
        tempParent = GameObject.Find("Parent");
    }

    private void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(distance >= 3f)
        {
            isHolding = false;
        }
        if(isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.parent = tempParent.transform;
            item.transform.position = tempParent.transform.position;
            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;  
            }

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    private void OnMouseDown()
    {
        if (distance <= 3f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
            item.transform.localScale = scale;
          
        }
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }
}
