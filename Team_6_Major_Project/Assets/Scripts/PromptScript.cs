using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour
{
    public GameObject player;

    public GameObject prompt;

    public GameObject Outline;

    public bool canShow;
    // Start is called before the first frame update
    void Start()
    {
        canShow = true;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        prompt.transform.LookAt(player.transform);
        /* 
         float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
         if (dist < 3f)
         {
             prompt.SetActive(true);
             prompt.transform.localScale = new Vector3(0.0003f * dist, 0.0003f * dist, 0.0003f * dist);
         }

         else prompt.SetActive(false);
         */
    }

    private void OnMouseOver()
    {
        float dist = Vector3.Distance(this.gameObject.transform.position, player.transform.position);

        if (dist < 3f && canShow)
        {
            Outline.SetActive(true);
            prompt.SetActive(true);
        }
            
    }
    private void OnMouseExit()
    {
        Outline.SetActive(false);
        prompt.SetActive(false);
    }

}