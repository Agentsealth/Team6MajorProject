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
    public GameObject[] options;
    private GrindstoneLogic gsLogic;
    private Anvil anvilLogic;
    
    void Start()
    {
        playerController = this.gameObject.GetComponent<PlayerController>();
        gsLogic = GameObject.FindObjectOfType<GrindstoneLogic>();
        anvilLogic = GameObject.FindObjectOfType<Anvil>();
        resetPos = transform.position;
        resetRot = transform.rotation;
    }
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        var speed = 1;
        var step = speed * Time.deltaTime;
        while (transform.rotation != rotB)
        { // until one second passed
            transform.position = Vector3.MoveTowards(posA, posB, (Time.time - startTime) * 10); // lerp from A to B in one second

            transform.rotation = Quaternion.RotateTowards(rotA, rotB, (Time.time - startTime) * 250);
            yield return 0.1f;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            returnToPos();
        }

    }

    public void gotoGrinder()
    {

        if (gsLogic.selected == false)
        {
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

    public void gotoAnvil()
    {
        if (anvilLogic.selected == false)
        {
            anvilLogic.selected = true;
            resetPos = transform.position;
            resetRot = transform.rotation;
            playerController.speed = 0;
            playerController.lookSemsitivity = 0;
            posA = transform.position;
            posB = loc2.transform.position;
            rotA = transform.rotation;
            rotB = loc2.transform.rotation;
            StartCoroutine(WaitAndMove(delayTime));
            if (anvilLogic.sheetCount > 0)
            {
                options[1].SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                anvilLogic.buttonSelected = true;
                anvilLogic.resetValue = false;

            }
        }
        else
        {
            return;
        }
        
    }

    public void gotoEnchant()
    {
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

    }

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

    }
    public void returnToPos()
    {
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
        gsLogic.playerHere = false;
        options[0].SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
