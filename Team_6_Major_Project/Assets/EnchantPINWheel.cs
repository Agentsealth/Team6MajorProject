using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantPINWheel : MonoBehaviour
{
    private bool canSpin;
    private int RuneIndex;
    private char[] Rune;
    public char SelectedRune;
    void Start()
    {
        Rune = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); //sets rune array to alphabet. IE Rune[0] = A. Run[25] = Z.
        RuneIndex = 0; //ensures it starts at 0
        SelectedRune = Rune[RuneIndex]; //sets text for debug purposes


    }

    // Update is called once per frame
    void Update()
    {
        if (canSpin) //see OnMouseOver
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) //WHEN SCROLLING UP.
            {
                this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z + 13.8461538462f); //Rotates it upward (360 / 26 = 13.8461538462
                RuneIndex++; //increase Index
                if(RuneIndex > 25) //If it exceedes the alphabet length set it to the other end.
                {
                    RuneIndex = 0;
                }
                if(RuneIndex < 0)
                {
                    RuneIndex = 25;
                }
                SelectedRune = Rune[RuneIndex]; //Set the selected rune for enchanting

                return;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) //WHEN SCROLLING DOWN
            {
                this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z - 13.8461538462f); //Rotates it downward (360 / 26 = 13.8461538462
                RuneIndex--; //decreases index
                if (RuneIndex > 25) //If it exceedes the alphabet length set it to the other end.
                {
                    RuneIndex = 0;
                }
                if (RuneIndex < 0)
                {
                    RuneIndex = 25;
                }
                SelectedRune = Rune[RuneIndex]; //Set the selected rune for enchanting
                return;
            }
        }
        //OnMouseOver();
    }

    private void OnMouseOver() //see if the players mouse is hovering over it
    {
        canSpin = true; //allow player to spin this pin
    }
    private void OnMouseExit()
    {
        canSpin = false;
    }
}
