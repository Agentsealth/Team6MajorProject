using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Camera playerCamera;
    public TMPro.TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        gameObject.transform.localEulerAngles = new Vector3(0, 180, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward, playerCamera.transform.rotation * Vector3.up);
       
    }
}
