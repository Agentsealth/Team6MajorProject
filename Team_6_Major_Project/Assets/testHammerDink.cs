using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHammerDink : MonoBehaviour
{

    public GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        hammer = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hammer.GetComponent<Animator>().Play("hammerDink", -1, 0);
            hammer.transform.position = new Vector3(hammer.transform.position.x + 0.05f, hammer.transform.position.y, hammer.transform.position.z);
        }
    }
}
