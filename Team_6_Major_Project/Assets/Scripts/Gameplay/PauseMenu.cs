using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject MainPauseMenu;
    public GameObject OptionsMenu;
    public PlayerController playerController;
    public GameObject PauseBook;

    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Debug.Log(isPaused);
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
        MainPauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void DisplayMenu()
    {
        MainPauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }


    IEnumerator MenuDelay(GameObject menuPart)
    {
        yield return new WaitForSeconds(1);
        menuPart.SetActive(false);
    }


}
