using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float midpoint = 2.0f;

    public AudioSource footStep;
    public AudioClip[] footStepLib;
    private bool hasStepped;
    //FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        Vector3 vector3Transform = transform.localPosition;
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            vector3Transform.y = midpoint + translateChange;
        }
        else
        {
            vector3Transform.y = midpoint;
        }
        transform.localPosition = vector3Transform;


        if(this.transform.localPosition.y <= -0.045f)
        {
            if (!hasStepped)
            {
                var StepNo = Random.Range(0, 3);
                footStep.clip = footStepLib[StepNo];
                footStep.Play();
                hasStepped = true;
            }
            
        }


        if (this.transform.localPosition.y > -0.045f)
        {
                hasStepped = false;

        }
    }
}
