using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuBossScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
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

}
