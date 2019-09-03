using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    

    public GameObject MainPauseMenu;
    public GameObject OptionsMenu;
    public PlayerController playerController;
    public GameObject PauseBook;
    public GameObject AudioSettings;
    public GameObject DisplaySettings;
    public bool isPaused;

    private OptionsMaster optM;
    
    public Slider MasterVolSlider;
    public Toggle FullscreenToggle;
    public GameObject FSToggleTick;

    public GameObject PlayerCamera;
    public GameObject MenuCamera;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Debug.Log(isPaused);
    }

    private void Awake()
    {
        optM = GameObject.FindObjectOfType<OptionsMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                MainPauseMenu.SetActive(true);
                PauseBook.GetComponent<Animator>().Play("BookUp", -1, 0f);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerController.lookSemsitivity = 0;
                isPaused = true;
                return;
            }
            if (isPaused == true)
            {
                PauseBook.GetComponent<Animator>().Play("BookDown", -1, 0f);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerController.lookSemsitivity = 3;
                isPaused = false;
                return;
            }
        }
    }
    public void DisplayOptions()
    {
        PauseBook.GetComponent<Animator>().Play("BookFlipBack", -1, 0f);
    }

    public void DisplayMenu()
    {
        PauseBook.GetComponent<Animator>().Play("BookFlipFront", -1, 0f);

    }


    IEnumerator MenuDelay(GameObject menuPart)
    {
        yield return new WaitForSeconds(1);
        menuPart.SetActive(false);
    }


    public void Unpause()
    {
        PauseBook.GetComponent<Animator>().Play("BookDown", -1, 0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.lookSemsitivity = 3;
        isPaused = false;
        return;
    }


    public void ShowAudioOptions()
    {
        DisplaySettings.SetActive(false);
        AudioSettings.SetActive(true);
        MasterVolSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        
    }


    public void ShowDisplayOptions()
    {
        
        DisplaySettings.SetActive(true);
        AudioSettings.SetActive(false);
        FullscreenToggle.isOn = PlayerPrefsX.GetBool("FullScreenMode");
        
    }

    public void SaveAudioOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolSlider.value);

        PlayerPrefs.Save();
        
    }
    public void ToggleFullscreen()
    {
        Debug.Log("0");
    

        if(FullscreenToggle.isOn == false)
        {
            Debug.Log("1");

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            FullscreenToggle.isOn = true;
            PlayerPrefsX.SetBool("FullScreenMode", true);

            
        }
        if(FullscreenToggle.isOn == true)
        {
            Debug.Log("2");
            Screen.fullScreenMode = FullScreenMode.Windowed;

            FullscreenToggle.isOn = false;
            PlayerPrefsX.SetBool("FullScreenMode", false);
            
        }
    }

    public void BackToMenu()
    {
        PlayerCamera.SetActive(false);
        MenuCamera.SetActive(true);
    }
}
