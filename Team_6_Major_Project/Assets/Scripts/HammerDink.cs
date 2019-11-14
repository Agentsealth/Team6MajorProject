using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerDink : MonoBehaviour
{

    public AudioSource dinkSource;
    public AudioClip[] hammerDink;

    public SliderMiniGame SMG;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Plays the audioSource for the hammerDinking
    public void playDink()
    {

        if(SMG.lastDinkAmount < 20 || SMG.lastDinkAmount > 80)
        {
            dinkSource.clip = hammerDink[5];
            dinkSource.Play();
        } else
        {
            int index = Random.Range(0, 4);
            dinkSource.clip = hammerDink[index];
            dinkSource.Play();
        }
        

    }

}

