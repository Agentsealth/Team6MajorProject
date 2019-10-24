using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindstoneLogic : MonoBehaviour
{
    public GameObject Parent;

    public bool isGrinding;
    public bool canGrind;
    // Start is called before the first frame update
    public GameObject handle;
    public GameObject guard;
    public GameObject options;
    public GameObject sheet;
    public int i;
    Vector3 initialPosition;
    public float endPosition;
    public MoveToPos MTP;
    private int quality;
    private int otherQuality;

    private bool isHandle;
    private bool isGuard;
    public bool playerInPos;
    public bool playerHere;
    public bool selected;

    public GameObject Sparks;
    public GameObject SparkPosition;
    public GameObject[] sparkObjs;


    public AudioSource grindingSound;
    public Tutorial tut;
    public AudioSource hitObstacle;

    void Start()
    {

        initialPosition = transform.position;
        MTP = GameObject.FindObjectOfType<MoveToPos>();
        StartCoroutine("pitchShift");
        tut = FindObjectOfType<Tutorial>();
    }

    public void FinishGrind()
    {

            isGrinding = false;
            selected = false;
            grindingSound.Stop();


            KillSparks();
            Destroy(sheet);
            if (isHandle)
            {
                GameObject craftedHandle = Instantiate(handle, initialPosition + new Vector3(1, 0.25f, 0.21f), Quaternion.identity);
                int materialIndex = (int)sheet.GetComponent<Sheet>().material;
                craftedHandle.GetComponent<Handle>().material = (Handle.HandleMaterial)(materialIndex);
                craftedHandle.GetComponent<Handle>().quality = (quality + otherQuality) / 2;
                isHandle = false;
                selected = false;

            }
            if (isGuard)
            {
                GameObject craftedGuard = Instantiate(guard, initialPosition + new Vector3(1, 0.25f, 0.21f), Quaternion.identity);
                int materialIndex = (int)sheet.GetComponent<Sheet>().material;
                craftedGuard.GetComponent<Guard>().material = (Guard.GuardMaterial)(materialIndex);
                craftedGuard.GetComponent<Guard>().quality = (quality + otherQuality) / 2;

                isGuard = false;
                selected = false;

            }
            if (tut.textPos == 20 || tut.textPos == 19)
            {
                tut.ProgressTutorial(20);
            }
            i = 0;
            canGrind = false;
            playerInPos = false;
            MTP.returnToPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (playerHere)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MTP.returnToPos();
                canGrind = false;
                isGrinding = false;
                playerInPos = false;
                playerHere = false;

            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && playerInPos)
        {
            grindingSound.pitch = Random.Range(0.75f, 1.25f);
            sheet.GetComponent<Animator>().enabled = true;
            if (isGuard)
            {
                sheet.GetComponent<Animator>().Play("GrindToGuard");

            }
            if (isHandle)
            {
                sheet.GetComponent<Animator>().Play("GrindToHandle");

            }
            isGrinding = true;
            grindingSound.Play();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && playerInPos)
        {
            sheet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
            sheet.GetComponent<Animator>().enabled = false;

            isGrinding = false;
            grindingSound.Stop();
        }

        if (sheet != null)
        {

            if (isGrinding && playerInPos)
            {
                //sheet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);
                GameObject temp = GameObject.Instantiate(Sparks, SparkPosition.transform) as GameObject;
                temp.transform.localPosition = new Vector3(0, 0, 0);
                temp.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                sheet.transform.eulerAngles = new Vector3(0, 0, 0);
                //i++;
            }
            if (!isGrinding && playerInPos)
            {
                //prevent sheet from having issues with the PickUp script
                sheet.GetComponent<Sheet>().sheetPickup.isHolding = false; 
                sheet.GetComponent<Rigidbody>().isKinematic = true;
                sheet.GetComponent<Rigidbody>().useGravity = true;

                //sheet.transform.eulerAngles = new Vector3(0, 0, 0);
                Destroy(GameObject.FindGameObjectWithTag("Sparks"));
                Destroy(GameObject.FindGameObjectWithTag("Sparks"));
            }
        }

        sparkObjs = GameObject.FindGameObjectsWithTag("Sparks");

        ExitGrinder();

        for (int o = 0; o < sparkObjs.Length - 10; o++)
        {
            Destroy(sparkObjs[o]);
        }
    }

    void KillSparks() //Destroy particles being rapidly spawned (NOTE: There's probably a better way of doing this)
    {
        for (int o = 0; o < sparkObjs.Length; o++)
        {
            Destroy(sparkObjs[o]);
        }

    }

    public void ExitGrinder() //Disables booleans to aid with player picking up and prevention of snap backing
    {
        if (sheet.GetComponent<PickUp>().isHolding)
        {
            sheet.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            canGrind = false;
            isGrinding = false;

        }
    }

    IEnumerator pitchShift() //Change pitch of Audio for variety
    {
        yield return new WaitForSeconds(1);
        StartCoroutine("pitchShift");
    }


   

    private void OnTriggerExit(Collider other) //same as exiting, implemented due to snap back issues
    {
        {
            if (other.gameObject.tag == "Iron Sheet")
            {

                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                canGrind = false;
                isGrinding = false;

            }
        }
    }

    public void ObstacleHit() //When the sheet hits a spike or ditch
    {
        sheet.GetComponent<Animator>().enabled = false;
        hitObstacle.Play();
        quality = quality - 10;
        isGrinding = false;
        sheet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
    }

    public void chooseHandle() //Player chooses to make a handle
    {
        if (tut.textPos == 19 || tut.textPos == 18)
        {
            tut.ProgressTutorial(19);
        }
        options.SetActive(false);
            isHandle = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            playerInPos = true;
  
    }

    public void chooseGuard() //player chooses to make a guard
    {
        if (tut.textPos == 19 || tut.textPos == 18)
        {
            tut.ProgressTutorial(19);
        }
        options.SetActive(false);

        isGuard = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerInPos = true;
    }

    private void OnMouseOver() //Player hovers over grindstone and hits F to put down sheet. No longer collision based.
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Sheet")
            {
                if (tut.textPos == 17 || tut.textPos == 16)
                {
                    tut.ProgressTutorial(17);
                }
                sheet = Parent.transform.GetChild(0).gameObject;
                sheet.GetComponent<Rigidbody>().useGravity = false;
                sheet.GetComponent<Animator>().enabled = true;
                sheet.GetComponent<Sheet>().sheetPickup.isHolding = false;

                sheet.GetComponent<Rigidbody>().isKinematic = true;
                sheet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
                sheet.transform.eulerAngles = new Vector3(0, 0, 0);
                canGrind = true;


                otherQuality = Parent.transform.GetChild(0).gameObject.GetComponent<Sheet>().quality;
                quality = 100;

                
            }
            else
            {
                MTP.gotoGrinder();
                if (tut.textPos == 18 || tut.textPos == 17)
                {
                    tut.ProgressTutorial(18);
                }
            }        
        }
        else
        {
            return;
        }
    }
}


