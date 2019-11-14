using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public enum SwordType { none, small, medium, large };
    public enum MaterialBlade { none, bronze, iron, steel };
    public enum MaterialHandle { none, bronze, iron, steel };
    public enum MaterialGuard { none, bronze, iron, steel };
    public enum EnchantType { none, chill, flame, spark, toxin, necro, bless }

    public SwordType swordType;
    public MaterialBlade materialBlade;
    public MaterialHandle materialHandle;
    public MaterialGuard materialGuard;
    public EnchantType enchantType;

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

    public GameObject AuctionParticles;
    private Collider Other;

    public GameObject AuctionMan;
    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop").GetComponentInChildren<Shop>();
        coalCost = shop.coalCost;
        ironCost = shop.ironCost;
        steelCost = shop.steelCost;
        bronzeCost = shop.bronzeCost;
        TextureChangeBlade();
        TextureChangeGuard();
        TextureChangeHandle();
        AuctionPrice();
        curCost = 1.0f;
        auctionText = GameObject.FindGameObjectWithTag("AuctionText").GetComponent<Text>();
        AuctionMan = GameObject.FindGameObjectWithTag("AuctionMan");
    }

    void Update()
    {

    }
    //Functions which does the auction price by using an equation
    public void AuctionPrice()
    {
        SwordTypeCheck();

        costToMake = (bladeIngot * bladeIngotCost) + (1 * handleIngotCost) + (1 * guardIngotCost) + (4 * coalCost);
        cost = costToMake + (costToMake / 3) + ((quality / 10) * 2);
    }
    //Functions which checks the sword type
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
    //Functions which changes the textures on the blade
    void TextureChangeBlade()
    {
        if (materialBlade == MaterialBlade.iron)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[0];
            bladeIngotCost = ironCost;
            if (swordType == SwordType.small)
            {
                this.gameObject.name = "Short Iron Sword";
            }
            else if (swordType == SwordType.medium)
            {
                this.gameObject.name = "Long Iron Sword";
            }
            else if (swordType == SwordType.large)
            {
                this.gameObject.name = "Bastard Iron Sword";
            }
        }
        else if (materialBlade == MaterialBlade.steel)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[1];
            bladeIngotCost = steelCost;
            if (swordType == SwordType.small)
            {
                this.gameObject.name = "Short Steel Sword";
            }
            else if (swordType == SwordType.medium)
            {
                this.gameObject.name = "Long Steel Sword";
            }
            else if (swordType == SwordType.large)
            {
                this.gameObject.name = "Bastard Steel Sword";
            }
        }
        else if (materialBlade == MaterialBlade.bronze)
        {
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = textures[2];
            bladeIngotCost = bronzeCost;
            if (swordType == SwordType.small)
            {
                this.gameObject.name = "Short Bronze Sword";
            }
            else if (swordType == SwordType.medium)
            {
                this.gameObject.name = "Long Bronze Sword";
            }
            else if (swordType == SwordType.large)
            {
                this.gameObject.name = "Bastard Bronze Sword";
            }
        }
    }
    //Functions which changes the textures on the guard
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
    //Functions which changes the textures on the handle
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
    //An Ienumerator which runs for the aunction for the number to speed up and then slow down as it gets closer to the number
    public IEnumerator RunAuction()
    {
        yield return new WaitForSeconds(0.01f);
        this.gameObject.transform.position = Other.transform.position;
        this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);

        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (curCost != cost)
        {
            speed = (1 - (curCost / cost)) * 1;
            if (speed <= 0.06f)
            {
                speed = 0.06f;
            }
            curCost = Mathf.MoveTowards(curCost, cost, 4 * speed);
            var aT = auctionText.rectTransform;
            auctionText.GetComponent<Animator>().enabled = false;
            aT.localScale = new Vector3(2 - speed, 2 - speed, 2 - speed);
            auctionText.text = "Value: " + ((int)curCost).ToString();
            yield return 0.1f;

        }

        yield return 0.1f;
        if (curCost == cost)
        {
            StopAllCoroutines();
            auctionText.GetComponent<Animator>().enabled = true;

            auctionText.GetComponent<Animator>().Play("EndAuction", -1, 0);
            Other.enabled = true;
            Instantiate(AuctionParticles, Other.transform.position, Quaternion.Euler(0, 90, 0));
            //playerStats.IncreaseMoney(cost);
            Destroy(this.gameObject);

        }
    }
    //Functions which runs when a gameObject hits the hitbox of the gameObject
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "AuctionTable")
        {
            Other = other;
            other.enabled = false;
            AuctionPrice();
            //AuctionMan.GetComponent<Animator>().Play("AhhYesAnAuction", -1, 0);
            this.gameObject.GetComponent<PickUp>().isHolding = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;


            StartCoroutine("RunAuction");
        }



    }
}
