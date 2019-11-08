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
                        TM.DocketTut();
                        break;
                    case 1:
                        TM.CoalTut();
                        break;
                    case 2:
                        TM.CrucibleTut();
                        break;
                    case 3:
                        TM.GrillsTut();
                        break;
                    case 4:
                        TM.AnvilTut();
                        break;
                    case 5:
                        TM.GrindstoneTut();
                        break;
                    case 6:
                        TM.QuenchingTut();
                        break;
                    case 7:
                        TM.AssemblyTut();
                        break;
                    case 8:
                        TM.HolderTut();
                        break;
                    case 9:
                        TM.CustomerTut();
                        break;
                    case 10:
                        TM.MoneyTut();
                        break;
                    case 11:
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
