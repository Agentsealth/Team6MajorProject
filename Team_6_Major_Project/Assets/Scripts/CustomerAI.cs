using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject[] slotwayPoints;

    public int waypointIndex = 0;

    public NavMeshAgent agent;

    public float dist;

    public TestDialogueTrigger dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = this.gameObject.GetComponent<TestDialogueTrigger>();
        slotwayPoints = GameObject.FindGameObjectsWithTag("SlotWayPoint");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
        if (dist > 1)
        {
            agent.SetDestination(waypoints[waypointIndex].transform.position);

        }
        else
        {
            if (waypointIndex == 1 || waypointIndex == 2)
            {
                return;
            }
            else if(waypointIndex == 3)
            {
                dialogue.SetItemSlot();
            }
            else
            {
                waypointIndex++;
            }
        }
    }

    public void setSlotWayPoint()
    {
        if(dialogue.CustomerNumber == 1)
        {
            waypoints[3] = slotwayPoints[2];
        }
        else if(dialogue.CustomerNumber == 2)
        {
            waypoints[3] = slotwayPoints[1];
        }
        else if (dialogue.CustomerNumber == 3)
        {
            waypoints[3] = slotwayPoints[0];
        }
        else
        {
            waypoints[3] = slotwayPoints[0];
        }
    }
}
