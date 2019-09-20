using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float throwForce = 10;
    public Vector3 scale;
    public Vector3 objectPos;
    public float distance;
    Camera cam;
    Ray ray;
    RaycastHit hit;
    private float distanceTohit = 10.0f;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    public Vector3 direction;
    public Vector3 startpoint;

    public Vector3 itemPos;

    public GameObject playerRightArm;

    private void Start()
    {
        scale = item.transform.localScale;
        tempParent = GameObject.Find("Parent");
        cam = Camera.main;
        playerRightArm = GameObject.FindGameObjectWithTag("RightArm");
    }

    private void Update()
    {
        playerRightArm = GameObject.FindGameObjectWithTag("RightArm");

        tempParent = GameObject.Find("Parent");

        ray = cam.ScreenPointToRay(Input.mousePosition);
        startpoint = ray.origin + (ray.direction * distanceTohit);
        item = this.gameObject;
        itemPos = item.transform.position;
        distance = Vector3.Distance(itemPos, tempParent.transform.position);
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
            item.transform.localRotation = Quaternion.Euler(0, 0, 0);
           
            if (Input.GetMouseButtonDown(1))
            {
                playerRightArm.GetComponent<Animator>().Play("ThrowingObject");

                RaycastObject();
                direction = (this.transform.position - startpoint).normalized;
                item.GetComponent<Rigidbody>().AddForce(-direction * throwForce);
                isHolding = false;
                canHold = true;
            }

            if (canHold == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playerRightArm.GetComponent<Animator>().Play("DroppingObjec");

                    isHolding = false;
                    canHold = true;
                }
            }
            canHold = false;

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.parent = null;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
            canHold = true;
        }
    }

    private void RaycastObject()
    {
        if (Physics.Raycast(ray, out hit, distanceTohit))
        {
            startpoint = hit.point;
            Debug.Log(startpoint);
        }
    }

    private void OnMouseDown()
    {
        if (distance <= 3f)
        {
            if (canHold == true)
            {
                playerRightArm.GetComponent<Animator>().Play("HoldingObject", -1, 0f);
                isHolding = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().detectCollisions = true;
                item.transform.localScale = scale;
            }          
        }
    }

    //private void OnMouseUp()
    //{
    //    isHolding = false;
    //}
}
