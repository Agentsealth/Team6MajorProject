using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindstoneSpike : MonoBehaviour
{
    public GrindstoneLogic gsLogic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //When an object hits the hitbox of the gameObject
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Iron Sheet")
        {
            gsLogic.ObstacleHit();
        }
    }
}
