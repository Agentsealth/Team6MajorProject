using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinChest : MonoBehaviour
{
    public PlayerStats PS;
    public GameObject coinLayer;
    public GameObject canvas;

    public GameObject Player;

    private bool hasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectOfType<PlayerStats>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.LookAt(Player.transform);
        var dist = Vector3.Distance(this.gameObject.transform.position, Player.transform.position);
        if(dist < 4)
        {
            if(hasPlayed == false)
            {
                canvas.GetComponent<Animator>().Play("ShowCoinCount", -1, 0);

            }
            hasPlayed = true;

        }
        if(dist > 4)
        {
            if(hasPlayed == true)
            {
                canvas.GetComponent<Animator>().Play("HideCoinCount", -1, 0);

            }
            hasPlayed = false;
        }



        coinLayer.transform.localPosition = new Vector3(coinLayer.transform.localPosition.x, (float)(-0.145f + (PS.gold / 10000f) / 10f), coinLayer.transform.localPosition.z);
        if (PS.gold > 10000)
        {
            coinLayer.transform.localPosition = new Vector3(coinLayer.transform.localPosition.x, -0.045f, coinLayer.transform.localPosition.z);
        }
        if (PS.gold <= 0)
        {
            coinLayer.transform.localPosition = new Vector3(coinLayer.transform.localPosition.x, -0.15f, coinLayer.transform.localPosition.z);
        }
    }


}
