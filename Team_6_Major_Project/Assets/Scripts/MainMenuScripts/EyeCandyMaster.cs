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
    private int speed;
    private float delayTime = 0;

    public AudioClip MenuSwitch;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;


    // Start is called before the first frame update
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (GrindStone.transform.localRotation != rotB)
        { // until one second passed
            GrindStone.transform.rotation = Quaternion.RotateTowards(rotA, rotB, (Time.time - startTime) * speed);
            MenuSwitch = GrindStone.GetComponent<AudioSource>().clip;
            
            yield return 1f;
        }
    }

    //Plays Particles system for Good vibes
    public void PlayGameCandy()
    {
        StopAllCoroutines();
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, 0.295f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(96.860f,-7.941f,0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(95, 0, 0f);
        speed = 50;

        audioSource1.Play();
        StartCoroutine(WaitAndMove(delayTime));

    }
    //Plays particles system for good vibes for options menu
    public void OptionsCandy()
    {
        StopAllCoroutines();
        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.099f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(89.235f, -7.941f, 0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(90f, 0, 0f);
        speed = 50;

        audioSource1.Play();
        StartCoroutine(WaitAndMove(delayTime));

    }
    //Plays particle systems for good vibes for exiting
    public void ExitCandy()
    {
        StopAllCoroutines();

        HLSparks.SetActive(true);
        HLSparks.transform.localPosition = new Vector3(0f, -0.482f, -0.57f);
        //GrindStone.transform.localRotation = Quaternion.Euler(81.752f, -7.941f, 0f);
        rotA = GrindStone.transform.localRotation;
        rotB = Quaternion.Euler(85f, 0, 0f);
        speed = 50;

        audioSource1.Play();
        StartCoroutine(WaitAndMove(delayTime));

 
    }
    //Functions which spins the grinder on main menu
    public void SpinGrinder()
    {
        float temp = GrindStone.transform.localRotation.x + 720;
        StopAllCoroutines();
        GrindStone.GetComponent<Animator>().Play("optionSpin", -1,0);
    }
    //Destroyes the particles
    public void KillCandy()
    {
        HLSparks.transform.localPosition = new Vector3(0f, 95f, 0f);
    }

}
