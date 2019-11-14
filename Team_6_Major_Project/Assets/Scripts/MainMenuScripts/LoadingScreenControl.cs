using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScreenControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject loadingScreenObj;
    public GameObject MainMenu;
    public Slider slider;
    private float i;
    private bool startLoad;
    AsyncOperation async;

    public AudioSource audioSource;
    //Plays audio source starts coroutine for loading scene
    public void LoadScreenExample()
    {
        audioSource.Play();
        StartCoroutine(LoadingScreen());
    }
    //An Ienumerator for loading scene
    IEnumerator LoadingScreen()
    {
        
        startLoad = true;
        MainMenu.SetActive(false);
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync("IntegrationScene");
        async.allowSceneActivation = false;
        

        while (async.isDone == false)
        {
            if (async.progress == 0.9f)
            {
                
                startLoad = false;
                slider.value = 1;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startLoad)
        {
            i = i + 0.005f;
            slider.value = i;
        }
    }
}
