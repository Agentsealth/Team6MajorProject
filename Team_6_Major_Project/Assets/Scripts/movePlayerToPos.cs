using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayerToPos : MonoBehaviour
{
    // Start is called before the first frame update
    public float delayTime;
    public Vector3 posA;
    public Vector3 posB;
    public Quaternion rotA = Quaternion.identity;
    public Quaternion rotB = Quaternion.identity;
    public Vector3 resetPos;
    public PlayerController playerController;
    public GameObject loc1;
    public GameObject loc2;
    public GameObject loc3;
    public GameObject loc4;
    public GameObject options;
    private sharpenDemo sD;
    void Start()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();
        sD = GameObject.FindObjectOfType<sharpenDemo>();
    }
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 2)
        { // until one second passed
            transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
            transform.rotation = Quaternion.Lerp(rotA, rotB, Time.time - startTime);
            yield return 0.5f;
        }
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.F1))
        {


        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            posA = transform.position;
            posB = loc2.transform.position;
            StartCoroutine(WaitAndMove(delayTime));

        }


        if (Input.GetKeyDown(KeyCode.F3)) 
        {
            posA = transform.position;
            posB = loc3.transform.position;
            StartCoroutine(WaitAndMove(delayTime));

        }


        if (Input.GetKeyDown(KeyCode.F5))
        {
            posB = posA;
            posA = transform.position;
            StartCoroutine(WaitAndMove(delayTime));

        }
    }

    public void gotoGrinder()
    {
       
            
            resetPos = transform.position;

            playerController.speed = 0;
            playerController.lookSemsitivity = 0;
            posA = transform.position;
            posB = loc1.transform.position;
            rotA = transform.rotation;
            rotB = loc1.gameObject.transform.rotation;
            StartCoroutine(WaitAndMove(delayTime));
            options.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

    }

    public void returnToPos()
    {
        posB = loc4.transform.position;
        posA = transform.position;
        playerController.speed = 5;
        playerController.lookSemsitivity = 3;
        rotA = transform.rotation;
        rotB = loc4.transform.rotation;

        StartCoroutine(WaitAndMove(delayTime));


    }
    void gsPosFirm()
    {
        //playerController.gameObject.transform.position = loc1.transform.position;
        //playerController.gameObject.transform.rotation = loc1.transform.rotation;

    }

    void offgsPosFirm()
    {
       // playerController.gameObject.transform.position = loc4.transform.position;
       // playerController.gameObject.transform.rotation = loc4.transform.rotation;

    }
}
