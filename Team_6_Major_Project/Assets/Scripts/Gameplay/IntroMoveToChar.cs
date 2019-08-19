using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMoveToChar : MonoBehaviour
{
    // Start is called before the first frame update
    private float delayTime = 0;
    private Vector3 posA;
    private Vector3 posB;
    private Quaternion rotA = Quaternion.identity;
    private Quaternion rotB = Quaternion.identity;
    private Vector3 resetPos;
    private Quaternion resetRot;
    private PlayerController playerController;
    public GameObject MenuCamera;
    public GameObject Character;
    
    void Start()
    {
        
    }
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            MenuCamera.transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
            MenuCamera.transform.rotation = Quaternion.Lerp(rotA, rotB, Time.time - startTime);
            yield return 0.1f;
        }
    }

   void Update()
    {
        Character = GameObject.FindObjectOfType<PlayerController>().gameObject ;
    }

    public void gotoCharacter()
    {


    
        posA = MenuCamera.transform.position;
        posB = Character.transform.position;
        rotA = MenuCamera.transform.rotation;
        rotB = Character.gameObject.transform.rotation;
        StartCoroutine(WaitAndMove(delayTime));
       
    }
}
