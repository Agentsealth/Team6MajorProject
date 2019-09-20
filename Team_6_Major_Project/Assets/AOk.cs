using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOk : MonoBehaviour
{
    public GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerBody.GetComponent<Animator>().Play("Perfect", -1, 0);
        }
    }
}
