using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScreenControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject loadingScreenObj;
    public GameObject loadingMan;
    public Slider slider;

    AsyncOperation async;
    public void LoadScreenExample()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync("ssScene");
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
