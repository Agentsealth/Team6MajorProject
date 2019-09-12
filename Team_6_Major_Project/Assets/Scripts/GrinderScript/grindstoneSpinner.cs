using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grindstoneSpinner : MonoBehaviour
{
    float degrees;
    public float speed;
    private MoveToPos MTP;
    private GrindstoneLogic gsLogic;
    public GameObject Grindstone;
    public GameObject prompt;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        MTP = GameObject.FindObjectOfType<MoveToPos>();
        gsLogic = GameObject.FindObjectOfType<GrindstoneLogic>();
    }

    // Update is called once per frame
    void Update()
    {

        Grindstone.transform.Rotate(speed * Time.deltaTime, 0, 0);
        
    }

    private void OnMouseOver()
    {
        
        if (gsLogic.canGrind == true)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                MTP.gotoGrinder();

            }
        }
    }

}
