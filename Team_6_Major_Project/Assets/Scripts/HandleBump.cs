using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBump : MonoBehaviour
{

    private bool isTouching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.lossyScale == new Vector3(0.5f, 0.5f, 0.5f))
        {
            Destroy(this.gameObject);
        }

        if (isTouching)
        {
            this.transform.localScale = this.transform.lossyScale - new Vector3(-0.1f, -0.1f, -0.1f);
            Destroy(this.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Gouge")
        {
            isTouching = true;
        }
    }
}
