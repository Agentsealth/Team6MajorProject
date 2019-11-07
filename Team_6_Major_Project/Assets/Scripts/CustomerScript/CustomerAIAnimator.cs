using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAIAnimator : MonoBehaviour
{
    const float smoothTime = 0.1f;
    public float speedPercent;
    public NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the agent
        agent = GetComponent<NavMeshAgent>();
        //Sets the animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the speed Percentage
        speedPercent = agent.velocity.magnitude / agent.speed;
        //Updates the animator's float speed
        animator.SetFloat("speed", speedPercent, smoothTime, Time.deltaTime);
    }
}
