using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMaster : MonoBehaviour
{

    public Slider MasterVolumeSlider;

    public Dropdown resoulutionDropdown;

    Resolution[] resolutions;

    public int qualityIndexV;

    public bool fullScreen;

    public int resoulationIndexV;

    private float GammaCorrection;
    // Start is called before the first frame update
    void Start()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");

        resolutions = Screen.resolutions;
        resoulutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int lw = -1;
        int lh = -1;

        int currentResolutionIndex = 0;
        //Adds the different resoultions used on unity into the drop down menu
        for (int i = 0; i < resolutions.Length; i++)
        {
            //if (resolutions[i].refreshRate != 59)
            //{
            //    continue;
            //}
            if (lw != resolutions[i].width || lh != resolutions[i].height)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                lw = resolutions[i].width;
                lh = resolutions[i].height;

                if (lw == Screen.width && lh == Screen.height)
                {
                    currentResolutionIndex = i;
                }
            }          

        }

        //Add options to the dropdown menu
        resoulutionDropdown.ClearOptions();
        resoulutionDropdown.AddOptions(options);
        resoulutionDropdown.value = currentResolutionIndex;
        //resoulutionDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = MasterVolumeSlider.value;
    }

    public void SetQuality(int qualityIndex)
    {
        qualityIndexV = qualityIndex;
        //sets the quality
        QualitySettings.SetQualityLevel(qualityIndexV);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        fullScreen = isFullscreen;
        //sets the fullscreen
        Screen.fullScreen = fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        resoulationIndexV = resolutionIndex;
        //sets the screen resoultions
        Resolution resoultion = resolutions[resoulationIndexV];
        Screen.SetResolution(resoultion.width, resoultion.height, Screen.fullScreen);
    }

    public void ApplyChanges()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolumeSlider.value);
        PlayerPrefs.SetInt("Quality", qualityIndexV);
        if (fullScreen == true)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
        PlayerPrefs.SetInt("Resoultion", resoulationIndexV);
        PlayerPrefs.Save();
    }

    public void updateOptions()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
        if(PlayerPrefs.GetInt("FullScreen") == 1)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
}
