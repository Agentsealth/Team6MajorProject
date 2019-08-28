using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordTempVer : MonoBehaviour
{
    public enum SwordType { small, medium, large };
    public enum MaterialBlade { iron, steel, bronze };
    public enum MaterialHandle { iron, steel, bronze };
    public enum MaterialGuard { iron, steel, bronze };

    public SwordType swordType;
    public MaterialBlade materialBlade;
    public MaterialHandle materialHandle;
    public MaterialGuard materialGuard;

    public int cost;
    public int costToMake;
    public int bladeIngot;
    public int steelCost;
    public int ironCost;
    public int bronzeCost;
    public int coalCost;
    public int bladeIngotCost;
    public int guardIngotCost;
    public int handleIngotCost;
    public float curCost;
    public float speed;

    public Text auctionText;

    public Shop shop;

    public Material[] textures;

    public int quality;

    private PlayerStats playerStats;

    public GameObject AuctionParticles;
    private Collider Other;
    // Start is called before the first frame update
    void Start()
    {

        shop = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Shop>();
        auctionText = GameObject.FindGameObjectWithTag("AuctionText").GetComponent<Text>();
        coalCost = shop.coalCost;
        ironCost = shop.ironCost;
        steelCost = shop.steelCost;
        bronzeCost = shop.bronzeCost;
        TextureChangeBlade();
        TextureChangeGuard();
        TextureChangeHandle();
        //AuctionPrice();
        curCost = 1.0f;
        playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }


    // Update is called once per frame
    void Update()
    {
        /*Auduction code put in sword will need to be moved */
        /* 
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AuctionPrice();

        }
    }


    public IEnumerator RunAuction()
    {
        yield return new WaitForSeconds(0.01f);
        this.gameObject.transform.position = new Vector3(13.85f, 0.95f, -6.65f);
        this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);

        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (curCost != cost)
        {
            speed = (1 - (curCost / cost)) * 1;
            if (speed <= 0.06f)
            {
                speed = 0.06f;
            }
            curCost = Mathf.MoveTowards(curCost, cost, speed);
            var aT = auctionText.rectTransform;
            auctionText.GetComponent<Animator>().enabled = false;
            aT.localScale = new Vector3(2 - speed, 2 - speed, 2 - speed);
            auctionText.text = "Value: " + ((int)curCost).ToString();
            yield return 0.1f;

        }
        
        yield return 0.1f;
        if(curCost == cost)
        {
            StopAllCoroutines();
            auctionText.GetComponent<Animator>().enabled = true;

            auctionText.GetComponent<Animator>().Play("EndAuction", -1, 0);
            Other.enabled = true;
            Instantiate(AuctionParticles, Other.transform.position, Quaternion.Euler(0,90,0));
            playerStats.IncreaseMoney(cost);
            Destroy(this.gameObject);
            
        }
    }


    public void DoAuction()
    {
        for(float i = curCost; i < cost; i++)
        {

            speed = (1 - (curCost / cost)) * 1;
            if (speed <= 0.06f)
            {
                speed = 0.06f;
            }
            curCost = Mathf.MoveTowards(curCost, cost, speed);
            auctionText.text = "Sale: " + ((int)curCost).ToString();
            
        }
    }

    public void AuctionPrice()
    {
        /*Auduction code put in sword will need to be moved */
        SwordTypeCheck();

        costToMake = (bladeIngot * bladeIngotCost) + (1 * handleIngotCost) + (1 * guardIngotCost) + (4 * coalCost);
        cost = costToMake + (costToMake / 3) + ((quality / 10) * 2);
    }

    void SwordTypeCheck()
    {
        if (swordType == SwordType.small)
        {
            bladeIngot = 1;
        }
        else if (swordType == SwordType.medium)
        {
            bladeIngot = 2;
        }
        else if (swordType == SwordType.large)
        {
            bladeIngot = 3;
        }
    }

    void TextureChangeBlade()
    {
        if (materialBlade == MaterialBlade.iron)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[0];
            bladeIngotCost = ironCost;
        }
        else if (materialBlade == MaterialBlade.steel)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[1];
            bladeIngotCost = steelCost;
        }
        else if (materialBlade == MaterialBlade.bronze)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[2];
            bladeIngotCost = bronzeCost;
        }
    }

    void TextureChangeGuard()
    {
        if (materialGuard == MaterialGuard.iron)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[0];
            guardIngotCost = ironCost;
        }
        else if (materialGuard == MaterialGuard.steel)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[1];
            guardIngotCost = steelCost;
        }
        else if (materialGuard == MaterialGuard.bronze)
        {
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = textures[2];
            guardIngotCost = bronzeCost;
        }
    }

    void TextureChangeHandle()
    {
        if (materialHandle == MaterialHandle.iron)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[0];
            handleIngotCost = ironCost;
        }
        else if (materialHandle == MaterialHandle.steel)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[1];
            handleIngotCost = steelCost;
        }
        else if (materialHandle == MaterialHandle.bronze)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = textures[2];
            handleIngotCost = bronzeCost;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "AuctionTable")
        {
            Other = other;
            other.enabled = false;
            AuctionPrice();

            this.gameObject.GetComponent<PickUp>().isHolding = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;


            StartCoroutine("RunAuction");
        }
       


    }
}
