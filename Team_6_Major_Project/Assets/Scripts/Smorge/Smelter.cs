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

    private void OnTriggerEnter(Collider other)
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
