using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ore : MonoBehaviour
{
    public enum OreMaterial { bronze, iron, steel, coal };

    public OreMaterial material;

    public Smorge smorge;
    public PickUp orePickup;

    public int place;

    public float timeToDestroy;
    public float timeDecrease;

    public Material[] textures;


    // Start is called before the first frame update
    void Start()
    {
        TextureChange();
        orePickup = this.gameObject.GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {      
        if(material == OreMaterial.coal)
        {
            if(timeToDestroy > 0)
            {
                timeToDestroy -= timeDecrease * Time.deltaTime;
                if(timeToDestroy <= 0.01)
                {
                    smorge.Empty();
                    smorge.place = place;
                    Destroy(gameObject);
                }
            }
        }
    }
    
    void TextureChange()
    {
        if(material == OreMaterial.iron)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[0];
            this.gameObject.name = "Iron Chunk";
        }
        else if(material == OreMaterial.steel)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[1];
            this.gameObject.name = "Steel Chunk";
        }
        else if (material == OreMaterial.bronze)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[2];
            this.gameObject.name = "Bronze Chunk";
        }
        else if (material == OreMaterial.coal)
        {
            this.gameObject.GetComponent<MeshRenderer>().material = textures[3];
            this.gameObject.name = "Coal Chunk";
        }
    }
}
