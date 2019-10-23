using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDropRespawn : MonoBehaviour
{
    public GameObject dropslot;
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
        if (other.gameObject.tag == "Iron Ore" || other.gameObject.tag == "Iron Ingot"
            || other.gameObject.tag == "Iron Sheet" || other.gameObject.tag == "Iron Blade"
            || other.gameObject.tag == "Iron Handle" || other.gameObject.tag == "Iron Guard"
            || other.gameObject.tag == "Iron Sword")
        {
            other.transform.position = dropslot.transform.position;
        }
    }
}
