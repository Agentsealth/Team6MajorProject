using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
{
    // Start is called before the first frame update
    private float delayTime;
    private Vector3 posA;
    private Vector3 posB;
    private Quaternion rotA = Quaternion.identity;
    private Quaternion rotB = Quaternion.identity;
    private Vector3 resetPos;
    private Quaternion resetRot;
    private PlayerController playerController;
    public GameObject loc1;
    public GameObject loc2;
    public GameObject loc3;
    public GameObject loc4;
    public GameObject options;
    private GrindstoneLogic gsLogic;
    void Start()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();
        gsLogic = GameObject.FindObjectOfType<GrindstoneLogic>();
    }
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 2)
        { // until one second passed
            transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
            transform.rotation = Quaternion.Lerp(rotA, rotB, Time.time - startTime);
            yield return 0.1f;
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
            resetRot = transform.rotation;
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
        gsLogic.playerHere = true;
    }

    public void gotoAnvil()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
        playerController.speed = 0;
        playerController.lookSemsitivity = 0;
        posA = transform.position;
        posB = loc2.transform.position;
        rotA = transform.rotation;
        rotB = loc2.transform.rotation;
        StartCoroutine(WaitAndMove(delayTime));
        
    }

    public void returnToPos()
    {
        posB = resetPos;
        posA = loc1.transform.position;
        playerController.speed = 5;
        playerController.lookSemsitivity = 3;
        rotA = loc1.transform.rotation;
        rotB = loc4.transform.rotation;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(WaitAndMove(delayTime));
        gsLogic.playerHere = false;
        options.SetActive(false);

    }
}
