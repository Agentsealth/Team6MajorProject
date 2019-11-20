using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPos : MonoBehaviour
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
   
    public GameObject loc1;
    public GameObject loc2;
    public GameObject loc3;
    public GameObject loc4;
    public GameObject loc5;
    public GameObject[] options;
    private GrindstoneLogic gsLogic;
    private Anvil anvilLogic;

    private GameObject Player;
    public BoxCollider shopCol;

    public PauseMenu pM;
    // Start is called before the first frame updat

    public void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerController>().gameObject;
        playerController = this.gameObject.GetComponent<PlayerController>();
        gsLogic = GameObject.FindObjectOfType<GrindstoneLogic>();
        anvilLogic = GameObject.FindObjectOfType<Anvil>();
        resetPos = transform.position;
        resetRot = transform.rotation;
    }
    //Moves the player on the rotation
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        var speed = 1;
        var step = speed * Time.deltaTime;
        while (transform.rotation != rotB)
        { // until one second passed
            transform.rotation = Quaternion.RotateTowards(rotA, rotB, (Time.time - startTime) * 1000);
            yield return 0.1f;
        }

    }
    //Moves the player on the position
    IEnumerator WaitAndMoveTo(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        var speed = 1;
        var step = speed * Time.deltaTime;
        while (transform.position != posB)
        { // until one second passed
            transform.position = Vector3.MoveTowards(posA, posB, (Time.time - startTime) * 1000); // lerp from A to B in one second
            yield return 0.1f;
        }

    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            returnToPos();
        }

    }
    //Functions which moves the player to the grinder
    public void gotoGrinder()
    {

        if (gsLogic.selected == false)
        {
            pM.enabled = false;

            gsLogic.selected = true;
            resetPos = transform.position;
            resetRot = transform.rotation;
            playerController.speed = 0;
            playerController.lookSemsitivity = 0;
            posA = transform.position;
            posB = loc1.transform.position;
            rotA = transform.rotation;
            rotB = loc1.transform.rotation;
            StartCoroutine(WaitAndMove(delayTime));
            StartCoroutine(WaitAndMoveTo(delayTime));

            options[0].SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gsLogic.playerHere = true;
        }
        else
        {
            return;
        }
    }
    //Functions whichs moves the player to the anvil
    public void gotoAnvil()
    {

        if (anvilLogic.selected == false)
        {
            anvilLogic.selected = true;
            pM.enabled = false;

            resetPos = transform.position;
            resetRot = transform.rotation;
            playerController.speed = 0;
            playerController.lookSemsitivity = 0;
            posA = transform.position;
            posB = loc2.transform.position;
            rotA = transform.rotation;
            rotB = loc2.transform.rotation;
            StartCoroutine(WaitAndMove(delayTime));
            StartCoroutine(WaitAndMoveTo(delayTime));
            anvilLogic.buttonSelected = true;
            anvilLogic.resetValue = false;
        }
        else
        {
            return;
        }
        
    }
    //Moves the player to the enchanting table
    public void gotoEnchant()
    {
        pM.enabled = false;

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        resetPos = transform.position;
        resetRot = transform.rotation;
        playerController.speed = 0;
        playerController.lookSemsitivity = 0;
        posA = transform.position;
        posB = loc3.transform.position;
        rotA = transform.rotation;
        rotB = loc3.transform.rotation;
        StartCoroutine(WaitAndMove(delayTime));
        StartCoroutine(WaitAndMoveTo(delayTime));


    }
    //Moves the player to the lathe
    public void gotoLathe()
    {
        resetPos = transform.position;
        resetRot = transform.rotation;
        playerController.speed = 0;
        playerController.lookSemsitivity = 0;
        posA = transform.position;
        posB = loc4.transform.position;
        rotA = transform.rotation;
        rotB = loc4.transform.rotation;
        StartCoroutine(WaitAndMove(delayTime));
        StartCoroutine(WaitAndMoveTo(delayTime));


    }

    public void gotoShop()
    {
        pM.enabled = false;
        shopCol.enabled = false;
        Player.GetComponent<CapsuleCollider>().enabled = false;
        resetPos = transform.position;
        resetRot = transform.rotation;
        playerController.speed = 0;
        playerController.lookSemsitivity = 0;
        posA = transform.position;
        posB = loc5.transform.position;
        rotA = transform.rotation;
        rotB = loc5.transform.rotation;
        StartCoroutine(WaitAndMove(delayTime));
        StartCoroutine(WaitAndMoveTo(delayTime));


    }
    //Moves to the player back to the original position
    public void returnToPos()
    {
        pM.enabled = true;
        shopCol.enabled = true;
        Player.GetComponent<CapsuleCollider>().enabled = true;

        StopCoroutine(WaitAndMove(delayTime));
        StopAllCoroutines();
        posB = resetPos;
        posA = transform.position;
        playerController.speed = 5;
        playerController.lookSemsitivity = 3;
        rotA = transform.rotation;
        rotB = resetRot;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(WaitAndMove(delayTime));
        StartCoroutine(WaitAndMoveTo(delayTime));

        gsLogic.playerHere = false;
        options[0].SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
