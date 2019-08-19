using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestActive : MonoBehaviour
{
    public int timer;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            timer--;
        }

        if(timer <= 0)
        {
            this.gameObject.SetActive(false);
            timer = time;
        }
    }
}
