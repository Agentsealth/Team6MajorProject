using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMiniGame : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float BadRange = 40;
    [SerializeField]
    private float GoodRange = 30;
    [SerializeField]
    private float GreatRange = 20;
    [SerializeField]
    private float PerfectRange = 10;
    [SerializeField]
    private bool forward = true;
    [SerializeField]
    private bool stopped = false;


    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        SliderDirection();
        SliderMovement();
        Rating();
        Continue();
    }

    private void SliderMovement()
    {
        if (stopped == false)
        {
            if (forward == true)
            {
                slider.value += speed;
            }
            else
            {
                slider.value -= speed;
            }
        }
        else
        {

        }
    }
    private void SliderDirection()
    {
        if(slider.value == slider.minValue)
        {
            forward = true;
        }
        else if( slider.value == slider.maxValue)
        {
            forward = false;
        }
                            
    }

    private void Rating()
    {
        if(Input.GetMouseButtonDown(0))
        {
            stopped = true;
            if(slider.value <= BadRange/2)
            {
                text.text = "Bad";
            }
            else if(slider.value > BadRange / 2 && slider.value <= ((BadRange / 2) +(GoodRange/2)))
            {
                text.text = "Good";
            }
            else if(slider.value > ((BadRange / 2) + (GoodRange / 2)) && slider.value <= ((BadRange / 2) + (GoodRange / 2) + (GreatRange/2)))
            {
                text.text = "Great";
            }
            //else if()
            //{

            //}
            //else if()
            //{

            //}
            //else if ()
            //{

            //}
            //else if()
            //{

            //}
            //else
            //{

            //}
        }
    }

    private void Continue()
    {
        if (Input.GetMouseButtonUp(0))
        {
            stopped = false;
        }
    }
}
