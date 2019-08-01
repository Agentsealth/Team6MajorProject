using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grindstoneSpinner : MonoBehaviour
{
    float degrees;
    public float speed;
    public movePlayerToPos MPTP;
    // Start is called before the first frame update
    void Start()
    {
        MPTP = GameObject.FindObjectOfType<movePlayerToPos>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(speed * Time.deltaTime, 0, 0);

    }

    private void OnMouseOver()
    {
        Debug.Log("Help");
        if (Input.GetKeyDown(KeyCode.F))
        {
            MPTP.gotoGrinder();
        }
    }
}
