using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    public GameObject[] waypoints;

    public int waypointIndex = 0;

    public NavMeshAgent agent;

    public float dist;

    public TestDialogueTrigger dialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = this.gameObject.GetComponent<TestDialogueTrigger>();
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
            else
            {
                waypointIndex++;
            }
        }
    }
}
