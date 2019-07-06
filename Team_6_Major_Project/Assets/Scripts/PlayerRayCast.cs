using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField]
    private float distanceToSee = 3.0f;
    [SerializeField]
    private Transform playerHand;
    [SerializeField]
    private int objectInHand;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastDown();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            RaycastUp();
        }
    }

    private void RaycastDown()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward* distanceToSee, Color.red);
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            Debug.Log("Touched " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Iron Ore")
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hit.collider.gameObject.transform.position = playerHand.position;
                hit.collider.gameObject.transform.parent = playerHand.transform;
                objectInHand++;
            }
        }
    }

    private void RaycastUp()
    {
       if(objectInHand >0)
        {
            hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            playerHand.GetChild(0).gameObject.transform.localScale = new Vector3(1,1,1);
            playerHand.GetChild(0).gameObject.transform.parent = null;
            objectInHand--;
        }
    }
}
