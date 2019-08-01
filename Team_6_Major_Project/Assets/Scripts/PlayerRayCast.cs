using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class PlayerRayCast : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    private float distanceToSee = 3.0f; 
    [SerializeField]
    private Transform playerHand;
    [SerializeField]
    private int objectInHand;
    RaycastHit hit;
    Ray ray;
    public GameObject hoverOver;
    public Text hoverOverText;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
        HoverOver();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastDown();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            RaycastUp();
        }
    }

    private void RaycastDown()
    {
        if(Physics.Raycast(ray,out hit, distanceToSee))
        {
            print("I'm looking at " + hit.transform.name);
            ButtonClickUI();
        }
    }

    private void RaycastUp()
    {
       if(objectInHand > 0)
        {
            
        }
    }

    private void HoverOver()
    {
        if (Physics.Raycast(ray, out hit, distanceToSee))
        {
            print("I'm hovering over at " + hit.transform.name);
            if(hit.transform.gameObject.layer == 10)
            {
                hoverOver.SetActive(true);
                hoverOverText.text = hit.transform.name;
            }
            else
            {
                hoverOver.SetActive(false);
                hoverOverText.text = "";
            }
        }
        else
        {
            hoverOver.SetActive(false);
            hoverOverText.text = "";
        }
    }

    private void ButtonClickUI()
    {
        if (hit.transform.gameObject.layer == 9)
        {
            if (hit.transform.gameObject.GetComponent<IPointClick>() != null)
            {
                hit.transform.gameObject.GetComponent<IPointClick>().OnPointerClick();
            }
        }
    }


}
