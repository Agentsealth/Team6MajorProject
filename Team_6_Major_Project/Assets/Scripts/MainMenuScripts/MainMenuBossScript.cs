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
    public GameObject Player;
    public GameObject Music;
    public GameObject OptionsMaster;

    public AudioClip audioClip;
    public AudioSource audioSource;

    public GameObject MenuCamera;
    public GameObject PlayerCamera;

    public GameObject SaveScreen;
    public Canvas playerCanvas;

    public OptionsMaster optionsMaster;
    //An Ienumerator which delays the menu
    IEnumerator MenuDelay(GameObject menuPart)
    {
        yield return new WaitForSeconds(0.75f);
        menuPart.SetActive(true);
    }
    // Start is called before the first frame update
    public void Start()
    {
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<PlayerMotor>().enabled = false;
    }
    //Functions when enables the player canvas
    public void enablePlayerCanvas()
    {
        playerCanvas.enabled = true;
    }
    //Functions which lets the player play the game
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Music.SetActive(false);
        MenuCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        SaveScreen.SetActive(false);
        Player.GetComponent<PlayerController>().enabled = true;
        Player.GetComponent<PlayerMotor>().enabled = true;
        playerCanvas.enabled = true;
        MainMenu.SetActive(true);

    }
    //Shows the saveMenu
    public void ShowSaves()
    {
        SaveScreen.SetActive(true);
        MainMenu.SetActive(false);
    }
    //Shows the options menu
    public void ShowOptions()
    {
        
        MainMenu.SetActive(false);
        audioSource.Play();
        StartCoroutine(MenuDelay(Options));
    }
    //Shows the menu 
    public void ShowMenu()
    {
        StartCoroutine(MenuDelay(MainMenu));

        audioSource.Play();
        Options.SetActive(false);
        SaveScreen.SetActive(false);
    }
    //Shows the audio options 
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
    //Shows the display options
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
    //Shows gameplay options
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
    //Quits the application
    public void QuitGame()
    {
        Application.Quit();
    }



}
