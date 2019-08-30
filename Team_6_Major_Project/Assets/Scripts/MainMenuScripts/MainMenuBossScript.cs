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

    public GameObject Music;
    public GameObject OptionsMaster;

    public AudioClip audioClip;
    public AudioSource audioSource;



    // Start is called before the first frame update

    IEnumerator MenuDelay(GameObject menuPart)
    {
        yield return new WaitForSeconds(0.75f);
        menuPart.SetActive(true);
    }
    public void PlayGame()
    {
        DontDestroyOnLoad(Music);
        DontDestroyOnLoad(OptionsMaster);
        SceneManager.LoadScene("ssScene");
    }

    public void ShowOptions()
    {
        MainMenu.SetActive(false);
        audioSource.Play();
        StartCoroutine(MenuDelay(Options));
    }

    public void ShowMenu()
    {
        StartCoroutine(MenuDelay(MainMenu));

        audioSource.Play();
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

        audioSource.Play();

    }

    public void ShowDisplayOptions()
    {
        AudioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DisplayButton.GetComponent<Image>().color = new Color32(255, 30, 0, 255);
        GameplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        AudioOptions.SetActive(false);
        DisplayOptions.SetActive(true);
        GameplayOptions.SetActive(false);

        audioSource.Play();

    }

    public void ShowGameplayOptions()
    {
        AudioButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DisplayButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameplayButton.GetComponent<Image>().color = new Color32(255, 30, 0, 255);

        AudioOptions.SetActive(false);
        DisplayOptions.SetActive(false);
        GameplayOptions.SetActive(true);

        audioSource.Play();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
