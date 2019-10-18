using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    public Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position;
    }

    private void FixedUpdate()
    {
        tempPosition.x += horizontalSpeed;
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude;
        transform.position = tempPosition;
        transform.Rotate(new Vector3(1,0,0), 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
