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
    RaycastHit positionHit;
    Ray ray;
    public GameObject hoverOver;
    public Text hoverOverText;
    public GameObject floatingTextPrefab;
    public Vector3 viewport;
    public Vector3 lookAt;
    public float halfXScale;
    public float halfYScale;
    public Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
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
                if (floatingTextPrefab != null)
                {
                    ShowFloatingText();
                }
            }
            else
            {
                HideFloatingText();
            }
        }
        else
        {
            HideFloatingText();
        }
    }

    void ShowFloatingText()
    {
        floatingTextPrefab.SetActive(true);
        floatingTextPrefab.transform.position = hit.transform.position + new Vector3(0, (hit.transform.localScale.y / 2) + 0.2f, 0);
        floatingTextPrefab.GetComponentInChildren<Text>().text = hit.transform.name;
    }

    void HideFloatingText()
    {
        floatingTextPrefab.SetActive(false);
        floatingTextPrefab.GetComponentInChildren<Text>().text = "";
    }

    private void ButtonClickUI()
    {
        if (hit.transform.gameObject.layer == 9)
        {
            if (hit.transform.gameObject.GetComponent<IPointClick>() != null)
            {
                hit.transform.gameObject.GetComponent<IPointClick>().OnPointerClick();
            }

            if (hit.transform.gameObject.GetComponent<QuestPointClick>() != null)
            {
                hit.transform.gameObject.GetComponent<QuestPointClick>().OnPointerClick();
            }
        }
    }


}
