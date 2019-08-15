using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class EyeCandyMaster : MonoBehaviour
{

    public GameObject HLSparks;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void PlayGameCandy()
    {
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, 0.295f, -0.57f);
    }

    public void OptionsCandy()
    {
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.099f, -0.57f);
    }

    public void ExitCandy()
    {
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.482f, -0.57f);
    }

    public void KillCandy()
    {
        HLSparks.transform.localPosition = new Vector3(0f, 100f, 0f);
    }

}
