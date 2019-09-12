using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    public float Xspeed;
    public float Yspeed;
    public float Zspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Xspeed * Time.deltaTime, Yspeed * Time.deltaTime, Zspeed * Time.deltaTime);

    }
}
