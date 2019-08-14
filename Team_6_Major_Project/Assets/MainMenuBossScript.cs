using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuBossScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject AudioOptions;
    public GameObject DisplayOptions;
    public GameObject GameplayOptions;
    public GameObject AudioButton;
    public GameObject DisplayButton;
    public GameObject GameplayButton;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("ssScene");
    }

    public void ShowOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void ShowMenu()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }

    public void ShowAudioOptions()
    {
        AudioButton.GetComponent<Image>().color = new Color32(255, 30, 0, 255);
        DisplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255); 
        AudioOptions.SetActive(true);
        DisplayOptions.SetActive(false);
        GameplayOptions.SetActive(false);
    }

    public void ShowDisplayOptions()
    {
        AudioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DisplayButton.GetComponent<Image>().color = new Color32(255, 30, 0, 255);
        GameplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        AudioOptions.SetActive(false);
        DisplayOptions.SetActive(true);
        GameplayOptions.SetActive(false);
    }

    public void ShowGameplayOptions()
    {
        AudioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DisplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameplayButton.GetComponent<Image>().color = new Color32(255, 30, 0, 255);

        AudioOptions.SetActive(false);
        DisplayOptions.SetActive(false);
        GameplayOptions.SetActive(true);
    }

    private void Update()
    {
       
    }

}
