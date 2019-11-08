using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public Canvas playerCanvas;
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

    public GameObject Player;
    public GrindstoneLogic gsLogic;
    public Anvil anvil;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        anvil = FindObjectOfType<Anvil>();
        gsLogic = FindObjectOfType<GrindstoneLogic>();
    }

    private void Awake()
    {
        optM = GameObject.FindObjectOfType<OptionsMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gsLogic.canGrind == false && anvil.isHammering == false) 
        {
            //BackToMenu();

            if (gsLogic.canGrind == false && anvil.isHammering == false)
            {
                gsLogic.selected = false;
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
                else if (isPaused == true)
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
    }

    //Plays the animations which is used to display options
    public void DisplayOptions()
    {
        PauseBook.GetComponent<Animator>().Play("BookFlipBack", -1, 0f);
    }
    //Plays the animations which is used to display menu
    public void DisplayMenu()
    {
        PauseBook.GetComponent<Animator>().Play("BookFlipFront", -1, 0f);

    }

    //IEnumerator which delays the main menu
    IEnumerator MenuDelay(GameObject menuPart)
    {
        yield return new WaitForSeconds(1);
        menuPart.SetActive(false);
    }

    //Function which unpauses the Main menu and resume gameplay
    public void Unpause()
    {
        PauseBook.GetComponent<Animator>().Play("BookDown", -1, 0f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerController.lookSemsitivity = 3;
        isPaused = false;
        return;
    }

    //Shows audio options
    public void ShowAudioOptions()
    {
        DisplaySettings.SetActive(false);
        AudioSettings.SetActive(true);
        MasterVolSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        
    }

    //Shows display options
    public void ShowDisplayOptions()
    {
        
        DisplaySettings.SetActive(true);
        AudioSettings.SetActive(false);
        FullscreenToggle.isOn = PlayerPrefsX.GetBool("FullScreenMode");
        
    }
    //Saves audio options
    public void SaveAudioOptions()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterVolSlider.value);

        PlayerPrefs.Save();
        
    }
    //Shows fullScreen options
    public void ToggleFullscreen()
    {
    

        if(FullscreenToggle.isOn == false)
        {

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;

            FullscreenToggle.isOn = true;
            PlayerPrefsX.SetBool("FullScreenMode", true);

            
        }
        if(FullscreenToggle.isOn == true)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;

            FullscreenToggle.isOn = false;
            PlayerPrefsX.SetBool("FullScreenMode", false);
            
        }
    }
    //Sents the options back to main menu
    public void BackToMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine("showcursor");
        PlayerCamera.SetActive(false);
        MenuCamera.SetActive(true);
        playerCanvas.enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        Player.GetComponent<PlayerMotor>().enabled = false;
        
    }
    //Shows cursor
    IEnumerator showcursor()
    {
        yield return new WaitForSeconds(0.5f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
