using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoint1s;
    public GameObject[] Npcs;
    public GameObject wayPoint1;
    public string waypoint1_1 = "Empty";
    public string waypoint1_2 = "Empty";
    public string waypoint1_3 = "Empty";
    public int waypointSlot1;
    public int waypointIndex;


    void Start()
    {
        waypoint1s = GameObject.FindGameObjectsWithTag("Waypoint 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Waypoint1Update()
    {
        if(waypoint1_1 == "Empty" && waypoint1_3 == "Empty" && waypoint1_2 == "Empty")
        {
            wayPoint1 = waypoint1s[0];
            waypoint1_1 = "Full";
            waypointSlot1 = 1;
            waypointIndex = 1;

        }
        else if(waypoint1_2 == "Empty" && waypoint1_1 == "Full" && waypoint1_3 == "Empty")
        {
            wayPoint1 = waypoint1s[1];
            waypoint1_2 = "Full";
            waypointSlot1 = 2;
            waypointIndex = 5;

        }
        else if(waypoint1_3 == "Empty" && waypoint1_2 == "Full" && waypoint1_1 == "Full")
        {
            wayPoint1 = waypoint1s[2];
            waypoint1_3 = "Full";
            waypointSlot1 = 3;
            waypointIndex = 5;
        }
    }

    public void Waypoint1Empty()
    {
        if (waypoint1_1 == "Empty" && waypoint1_2 == "Full" && waypoint1_3 == "Empty")
        {
            waypoint1_2 = "Empty";
            waypoint1_1 = "Full";
            waypoint1_3 = "Empty";
            if(Npcs[1].GetComponent<CustomerAI>().waypointIndex != 2)
            {
                Npcs[1].GetComponent<CustomerAI>().waypoints[1] = waypoint1s[0];
                Npcs[1].GetComponent<CustomerAI>().waypointIndex = 1;
            }
            else
            {
                Npcs[2].GetComponent<CustomerAI>().waypoints[1] = waypoint1s[0];
                Npcs[2  ].GetComponent<CustomerAI>().waypointIndex = 1;
            }

        }
        if (waypoint1_1 == "Empty" && waypoint1_2 == "Full" && waypoint1_3 == "Full")
        {
            waypoint1_2 = "Full";
            waypoint1_1 = "Full";
            waypoint1_3 = "Empty";
            Npcs[1].GetComponent<CustomerAI>().waypoints[1] = waypoint1s[0];
            Npcs[1].GetComponent<CustomerAI>().waypointIndex = 1;
            Npcs[2].GetComponent<CustomerAI>().waypoints[1] = waypoint1s[1];


        }
        else if (waypoint1_1 == "Empty" && waypoint1_2 == "Full" && waypoint1_3 == "Empty")
        {
            waypoint1_2 = "Empty";
            waypoint1_1 = "Full";
            waypoint1_3 = "Empty";
            Npcs[2].GetComponent<CustomerAI>().waypoints[1] = waypoint1s[0];
            Npcs[2].GetComponent<CustomerAI>().waypointIndex = 1;
        }
    }

    public void AddNpcs()
    {
        Npcs = GameObject.FindGameObjectsWithTag("NPC");
    }
}
