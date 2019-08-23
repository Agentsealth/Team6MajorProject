using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMaster : MonoBehaviour
{

    public Slider MasterVolumeSlider;

    private float GammaCorrection;
    // Start is called before the first frame update
    void Start()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = MasterVolumeSlider.value;
    }


    public void ApplyChanges()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeSlider.value);
        PlayerPrefs.Save();
    }

 
}
