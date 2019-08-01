using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grindstoneSpinner : MonoBehaviour
{
    float degrees;
    public float speed;
    private MoveToPos MTP;
    
    // Start is called before the first frame update
    void Start()
    {
        MTP = GameObject.FindObjectOfType<MoveToPos>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(speed * Time.deltaTime, 0, 0);

    }

    private void OnMouseOver()
    {
        Debug.Log("Help");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MTP.gotoGrinder();
        }
    }
}
