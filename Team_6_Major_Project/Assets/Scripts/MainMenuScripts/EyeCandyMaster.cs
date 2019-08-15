using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class EyeCandyMaster : MonoBehaviour
{

    public GameObject HLSparks;
    public GameObject GrindStone;

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;

    private Quaternion rotA;
    private Quaternion rotB;
    private float delayTime = 0;
    // Start is called before the first frame update
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        Debug.Log("Kek");
        while (Time.time - startTime <= 1)
        { // until one second passed
            GrindStone.transform.rotation = Quaternion.RotateTowards(rotA, rotB, (Time.time - startTime) * 50);
            yield return 0.1f;
        }
    }



    public void PlayGameCandy()
    {
        StopAllCoroutines();
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, 0.295f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(96.860f,-7.941f,0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(96.860f, 0, 0f);
        StartCoroutine(WaitAndMove(delayTime));
    }

    public void OptionsCandy()
    {
        StopAllCoroutines();
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.099f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(89.235f, -7.941f, 0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(90f, 0, 0f);
        StartCoroutine(WaitAndMove(delayTime));

    }

    public void ExitCandy()
    {
        StopAllCoroutines();

        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.482f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(81.752f, -7.941f, 0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(85f, -0, 0f);
        StartCoroutine(WaitAndMove(delayTime));


    }

    public void KillCandy()
    {
        HLSparks.transform.localPosition = new Vector3(0f, 95f, 0f);
    }

}
