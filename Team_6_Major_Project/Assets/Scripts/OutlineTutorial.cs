using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineTutorial : MonoBehaviour
{

    public GameObject playerBook;
    public TutorialMaster TM;
    private float dist;
    public int objectIndex;

    public GameObject outline;
    // Start is called before the first frame update
    void Start()
    {
        playerBook = GameObject.FindGameObjectWithTag("PlayerMenu");
        TM = FindObjectOfType<TutorialMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.gameObject.transform.position, playerBook.transform.position);
    }

    private void OnMouseOver()
    {

            if (dist < 3)
            {
                TM.outTut = this;

                switch (objectIndex)
                {
                    case 0:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.DocketTut();
                        break;
                    case 1:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.CoalTut();
                        break;
                    case 2:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.CrucibleTut();
                        break;
                    case 3:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.GrillsTut();
                        break;
                    case 4:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.AnvilTut();
                        break;
                    case 5:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.GrindstoneTut();
                        break;
                    case 6:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.QuenchingTut();
                        break;
                    case 7:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.AssemblyTut();
                        break;
                    case 8:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.HolderTut();
                        break;
                    case 9:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.CustomerTut();
                        break;
                    case 10:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.MoneyTut();
                        break;
                    case 11:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.ShopTut();
                        break;
                    case 12:
                    objectIndex = 100;
                    TM.OpenPopup();
                    TM.EnchTut();
                        break;

                }
            Destroy(outline);
                return;
            }
        
    }

}
