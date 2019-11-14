using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public int ironOre;
    public int steelOre;
    public int bronzeOre;
    public Transform drop;
    public float time;
    public float smeltTime;

    public GameObject ironIngot;

    public bool smorgeOn = false;
    public GameObject SmorgeBowl;
    public GameObject SmorgeLever;

    public GameObject Smoke2;
    public AudioSource ingotHardening;

    public GameObject Parent;
    private bool hasTuted;
    public Tutorial tut;
    // Start is called before the first frame update
    void Start()
    {
        tut = FindObjectOfType<Tutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        if(smeltTime <= 0)
        {
            smeltTime = time;
        }
        smeltIron();
        smeltSteel();
        smeltBronze();
    }

    //Checks if the mouse is hovering over the gameObject
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int cCount = Parent.transform.childCount;
            if (cCount > 0 && Parent.transform.GetChild(0).gameObject.tag == "Iron Ore" && Parent.transform.GetChild(0).gameObject.GetComponent<Ore>().material != Ore.OreMaterial.coal)
            {

                snappping(Parent.transform.GetChild(0));

            }
            else
            {
                return;
            }

        }
    }
    //Functions which snaps the gameObject to a location
    public void snappping(Transform other)
    {
        if (smorgeOn == true)
        {
            if (other.gameObject.tag == "Iron Ore")
            {
                if (tut.textPos == 8 || tut.textPos == 7)
                {
                    tut.ProgressTutorial(8);
                }
                Smoke2.GetComponent<ParticleSystem>().Stop();
                SmorgeBowl.GetComponent<Animator>().Play("BucketPourMetal", -1, 0);
                SmorgeLever.GetComponent<Animator>().Play("LeverPourMetal", -1, 0);
                if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.iron)
                {
                    ironOre++;
                }
                else if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.steel)
                {
                    steelOre++;
                }
                else if (other.gameObject.GetComponent<Ore>().material == Ore.OreMaterial.bronze)
                {
                    bronzeOre++;
                }
                Destroy(other.gameObject);
            }
        }
        else
        {
            return;
        }
    }

    //Checks if an gameobject enters the hitbox of this gameObject
    private void OnTriggerEnter(Collider other)
    {
        snappping(other.gameObject.transform);
    }
    //Functions which smelts the iron ore into iron ingots
    private void smeltIron()
    {
        if (ironOre > 0)
        {
            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject iron = Instantiate(ironIngot, drop.position, Quaternion.identity);
                ingotHardening.Play();

                iron.GetComponent<Ingot>().material = Ingot.IngotMaterial.iron;
                ironOre--;
            }
        }
    }
    //Functions which smelts the steel ore into steel ingots
    private void smeltSteel()
    {
        if (steelOre > 0)
        {

            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject steel = Instantiate(ironIngot, drop.position, Quaternion.identity);
                ingotHardening.Play();

                steel.GetComponent<Ingot>().material = Ingot.IngotMaterial.steel;
                steelOre--;
            }
        }
    }
    //Functions which smelts the bronze ore into bronze ingots
    private void smeltBronze()
    {
        if (bronzeOre > 0)
        {

            smeltTime -= 1 * Time.deltaTime;
            if (smeltTime <= 0)
            {
                GameObject bronze = Instantiate(ironIngot, drop.position, Quaternion.identity);
                ingotHardening.Play();

                bronze.GetComponent<Ingot>().material = Ingot.IngotMaterial.bronze;
                bronzeOre--;
            }
        }
    }
}
