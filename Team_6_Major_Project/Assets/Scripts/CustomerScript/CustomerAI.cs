﻿using System.Collections;
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
        //Sets the dialogue variable
        dialogue = this.gameObject.GetComponent<TestDialogueTrigger>();
        //Sets the waypoint manager
        waypointManager = GameObject.FindObjectOfType<WaypointManager>().GetComponent<WaypointManager>();
        //Finds all the slot waypoints and sets them in the array
        slotwayPoints = GameObject.FindGameObjectsWithTag("SlotWayPoint");
        //Sets the first waypoint 
        waypoints[0] = GameObject.FindGameObjectWithTag("Waypoint 0");
        //Runs the waypoint1Update function
        waypointManager.Waypoint1Update();
        //Sets the second waypoint
        waypoints[1] = waypointManager.wayPoint1;
        //Sets the waypoint 1's slot
        waypoint1Slot = waypointManager.waypointSlot1;
        //Sets the third waypoint
        waypoints[2] = GameObject.FindGameObjectWithTag("Waypoint 2");
        //Sets the fourth waypoint
        waypoints[4] = GameObject.FindGameObjectWithTag("Waypoint 3");
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the waypointIndex is equal to 5
        if (waypointIndex == 5)
        {
            //Sets the waypointIndex based on the waypointManager's waypoint Index
            waypointIndex = waypointManager.waypointIndex;
            //Gets the distance between the gameObject and the second waypoint
            dist = Vector3.Distance(gameObject.transform.position, waypoints[1].transform.position);

        }
        else
        {
            //Checks if the waypointIndex is equal to 2
            if (waypointIndex == 2)
            {
                //Gets the distance between the gameObject and the current waypoint Index waypoint
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
            }
            //Checks if the waypointIndex is equal to 0
            else if (waypointIndex == 0)
            {
                //Sets the waypointIndex based on the waypointManager's waypoint Index
                waypointIndex = waypointManager.waypointIndex;
                //Gets the distance between the gameObject and the current waypoint Index waypoint
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
            }
            else
            {
                //Gets the distance between the gameObject and the current waypoint Index waypoint
                dist = Vector3.Distance(gameObject.transform.position, waypoints[waypointIndex].transform.position);
            }

        }
        //Checks if the distance is greater than 1
        if (dist > 1)
        {
            //Checks if the waypointIndex is equal to 5
            if (waypointIndex == 5)
            {
                //Moves the AI to the second waypoint
                agent.SetDestination(waypoints[1].transform.position);
            }
            else
            {
                //Moves the AI based on the waypointIndex waypoint
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
            else if (waypointIndex == 1 || waypointIndex == 2 || waypointIndex == 5)
            {
                return;
            }
            else if (waypointIndex == 3)
            {
                dialogue.CheckItemSlot();
            }
            else if (waypointIndex == 4)
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
