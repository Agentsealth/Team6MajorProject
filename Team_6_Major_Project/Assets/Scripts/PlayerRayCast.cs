using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    private float distanceToSee = 3.0f; 
    [SerializeField]
    private Transform playerHand;
    [SerializeField]
    private int objectInHand;
    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
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
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        if(Physics.Raycast(ray,out hit))
        {
            print("I'm looking at " + hit.transform.name);
            ButtonClickUI();
        }
    }

    private void RaycastUp()
    {
       if(objectInHand > 0)
        {
            
        }
    }

    private void ButtonClickUI()
    {
        if (hit.transform.gameObject.layer == 9)
        {
            if (hit.transform.gameObject.GetComponent<IPointClick>() != null)
            {
                hit.transform.gameObject.GetComponent<IPointClick>().OnPointerClick();
            }
        }
    }
}
