using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smorge : MonoBehaviour
{
    public Furnace furance;
    public Furnace furance2;
    public Smelter smelter;
    public static string oreplace1 = "empty";
    public static string oreplace2 = "empty";
    public static string oreplace3 = "empty";
    public static string oreplace4 = "empty";
    public static string oreplace5 = "empty";
    public static string oreplace6 = "empty";
    public int place;
    public Transform[] oreplace;
    public float time;
    public float timeDecrease;
    public float timeIncrease;
    public string objectName;
    public bool smorgeOn = false;

    public Material coalMat;
    public GameObject Smoke;
    public GameObject Smoke2;
    public GameObject fireParent;
    public GameObject Parent;

    public AudioSource flameburst;
    public AudioSource flamecrackling;
    public AudioSource PlaceDown;

    public Transform badplace;
    private bool hasTuted = false;
    public Tutorial tut;
    public GameObject player;

    private bool hadCoal;
    // Start is called before the first frame update
    void Start()
    {

        time = 0;
        objectName = this.gameObject.name;
        tut = FindObjectOfType<Tutorial>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (dist < 3 && tut.textPos == 5 || dist < 3 && tut.textPos == 4)
        {
            tut.ProgressTutorial(5);
        }

        if (time > 0)
        {
            coalMat.SetInt("Vector1_D9D22E34", 1);
            Smoke2.GetComponent<ParticleSystem>().Play();
            smorgeOn = true;
            furance.smorgeOn = smorgeOn;
            furance2.smorgeOn = smorgeOn;
            fireParent.SetActive(true);
            smelter.smorgeOn = smorgeOn;
            if (smorgeOn == true)
            {
                this.gameObject.name = objectName + " (Ready)";
                if (tut.textPos == 7 || tut.textPos == 6)
                {
                    tut.ProgressTutorial(7);
                }

            }
            time -= timeDecrease * Time.deltaTime;
        }
        else
        {
            Smoke2.GetComponent<ParticleSystem>().Stop();

            fireParent.SetActive(false);
            flamecrackling.Stop();
            coalMat.SetInt("Vector1_D9D22E34", 0);

            smorgeOn = false;
            furance.smorgeOn = smorgeOn;
            furance2.smorgeOn = smorgeOn;

            smelter.smorgeOn = smorgeOn;

            if (hadCoal == true)
            {
                StartCoroutine("StartStopSmoke");
            }

            if (smorgeOn == false)
            {
                this.gameObject.name = objectName + " (Not Ready)";
            }
        }
    }
    //An Ienumerator which delays the stopping of the smoke particle in the particle system
    IEnumerator StartStopSmoke()
    {
        hadCoal = false;
        Smoke.GetComponent<ParticleSystem>().Stop();
        Smoke.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        Smoke.GetComponent<ParticleSystem>().Stop();

    }
    //Checks if the mouse is hovering over the gameobject
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ore" && Parent.transform.GetChild(0).gameObject.GetComponent<Ore>().material == Ore.OreMaterial.coal)
            {

                snapping(Parent.transform.GetChild(0));

            }
            else
            {
                return;
            }

        }
    }
    //Snaps the gameObject to a position
    public void snapping(Transform other)
    {
        if (other.gameObject.tag == "Iron Ore")
        {
            if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.coal)
            {
                PlaceDown.Play();
                hadCoal = true;
                if (time == 0)
                {
                    flameburst.Play();
                    flamecrackling.Play();

                }
                other.gameObject.GetComponent<Ore>().orePickup.isHolding = false;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Ore>().smorge = this;
                other.gameObject.GetComponent<Ore>().timeToDestroy = timeIncrease;
                other.gameObject.GetComponent<Ore>().timeDecrease = timeDecrease;
                time += timeIncrease;
                if (oreplace1 == "empty")
                {
                    snappingCoal(other, 0);
                }
                else if (oreplace2 == "empty")
                {
                    snappingCoal(other, 1);
                }
                else if (oreplace3 == "empty")
                {
                    snappingCoal(other, 2);
                }
                else if (oreplace4 == "empty")
                {
                    snappingCoal(other, 3);
                }
                else if (oreplace5 == "empty")
                {
                    snappingCoal(other, 4);
                }
                else if (oreplace6 == "empty")
                {
                    snappingCoal(other, 5);
                }
            }
            else
            {
                other.transform.position = badplace.transform.position;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                return;
            }
        }
        else
        {
            return;
        }
    }
    //Checks the gameObject hits the hitbox if this gameObject
    public void OnTriggerEnter(Collider other)
    {
        snapping(other.gameObject.transform);
    }
    //Snaps the coal to a position
    public void snappingCoal(Transform other, int index)
    {
        other.transform.position = oreplace[index].transform.position;
        other.gameObject.GetComponent<Ore>().place = index + 1;
        if(index == 0)
        {
            oreplace1 = "full";
        }
        else if(index == 1)
        {
            oreplace2 = "full";
        }
        else if (index == 2)
        {
            oreplace3 = "full";
        }
        else if (index == 3)
        {
            oreplace4 = "full";
        }
        else if (index == 4)
        {
            oreplace5 = "full";
        }
        else if (index == 5)
        {
            oreplace6 = "full";
        }

    }
    //Functions which runs when the coals runs out and a place is empty
    public void Empty()
    {
        if (place == 1)
        {
            oreplace1 = "empty";
        }
        else if (place == 2)
        {
            oreplace2 = "empty";
        }
        else if (place == 3)
        {
            oreplace3 = "empty";
        }
        else if (place == 4)
        {
            oreplace4 = "empty";
        }
        else if (place == 5)
        {
            oreplace5 = "empty";
        }
        else if (place == 6)
        {
            oreplace6 = "empty";
        }
    }
}
