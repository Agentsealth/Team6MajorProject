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

            }
        }
    }

    private void RaycastUp()
    {
       if(objectInHand > 0)
        {
            
        }
    }
}
