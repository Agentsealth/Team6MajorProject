using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDink : MonoBehaviour
{

    public AudioSource dinkSource;
    public AudioClip[] hammerDink;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playDink()
    {
        int index = Random.Range(0, hammerDink.Length);
        dinkSource.clip = hammerDink[index];
        dinkSource.Play();

    }

}

