using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField]
    private float distanceToSee = 3.0f;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceToSee))
        {
            Debug.Log("Touched " + hit.collider.gameObject.name);
            Destroy(hit.collider.gameObject);
        }
    }
}
