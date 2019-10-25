using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject[] slotwayPoints;

    public WaypointManager waypointManager;

    public int waypointIndex = 0;
    public int waypoint1Slot;

    public NavMeshAgent agent;

    public float dist;

    public TestDialogueTrigger dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = this.gameObject.GetComponent<TestDialogueTrigger>();
        waypointManager = GameObject.FindObjectOfType<WaypointManager>().GetComponent<WaypointManager>();
        slotwayPoints = GameObject.FindGameObjectsWithTag("SlotWayPoint");
        waypoints[0] = GameObject.FindGameObjectWithTag("Waypoint 0");
        waypointManager.Waypoint1Update();
        //Change this
        waypoints[1] = waypointManager.wayPoint1;
        waypoint1Slot = waypointManager.waypointSlot1;
        waypoints[2] = GameObject.FindGameObjectWithTag("Waypoint 2");
        waypoints[4] = GameObject.FindGameObjectWithTag("Waypoint 3");
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex == 5)
        {
            waypointIndex = waypointManager.waypointIndex;
            dist = Vector3.Distance(gameObject.transform.position, waypoints[1].transform.position);

        }
        else
        {
            if (waypointIndex == 2)
            {
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);

            }
            else if (waypointIndex == 0)
            {
                waypointIndex = waypointManager.waypointIndex;
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
            }
            else
            {
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
            }

        }

        if (dist > 1)
        {
            if (waypointIndex == 5)
            {
                agent.SetDestination(waypoints[1].transform.position);
            }
            else
            {
                agent.SetDestination(waypoints[waypointIndex].transform.position);
            }
            

        }
        else
        {
            if(waypointIndex == 0)
            {
                agent.SetDestination(waypoints[waypointIndex].transform.position);
                if (waypointIndex == 5)
                {
                    agent.SetDestination(waypoints[1].transform.position);
                }
                return;
            }
            if (waypointIndex == 1)
            {
                return;
            }
            else if (waypointIndex == 5)
            {
                return;
            }
            else if(waypointIndex == 2)
            {
                return;
            }
            else if(waypointIndex == 3)
            {
                dialogue.CheckItemSlot();
            }
            else if(waypointIndex == 4)
            {
                Destroy(gameObject);
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
            waypoints[3] = slotwayPoints[0];
        }
        else if(dialogue.CustomerNumber == 2)
        {
            waypoints[3] = slotwayPoints[1];
        }
        else if (dialogue.CustomerNumber == 3)
        {
            waypoints[3] = slotwayPoints[2];
        }
        else
        {
            return;
        }
    }
}
