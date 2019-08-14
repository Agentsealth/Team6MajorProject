using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalPointTest : MonoBehaviour
{
    public Anvil anvil;
    // Start is called before the first frame update

    private void Start()
    {
        anvil = GameObject.FindObjectOfType<Anvil>().GetComponent<Anvil>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CriticalPoint")
        {
            //anvil.Invoke("AddCritPoint", 0.5f);

            Destroy(other.gameObject);
        }
    }
}
