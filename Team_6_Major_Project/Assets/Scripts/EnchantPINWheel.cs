﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnchantPINWheel : MonoBehaviour
{
    private bool canSpin;
    public int RuneIndex;
    private char[] Rune;
    public Sprite[] Runes;
    public char SelectedRune;
    public Image runeImage;

    public AudioSource wheelScroll;

    public int WheelNumber;

    public bool didRun;
    void Start()
    {
        Rune = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); //sets rune array to alphabet. IE Rune[0] = A. Run[25] = Z.
        RuneIndex = 0; //ensures it starts at 0
        SelectedRune = Rune[RuneIndex]; //sets text for debug purposes


    }

    // Update is called once per frame
    void Update()
    {
        ChangeColour();


        if (canSpin) //see OnMouseOver
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) //WHEN SCROLLING UP.
            {
                this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z + 13.8461538462f); //Rotates it upward (360 / 26 = 13.8461538462
                RuneIndex++; //increase Index
                wheelScroll.Play();
                if (RuneIndex > 25) //If it exceedes the alphabet length set it to the other end.
                {
                    RuneIndex = 0;
                }
                if(RuneIndex < 0)
                {
                    RuneIndex = 25;
                }
                SelectedRune = Rune[RuneIndex]; //Set the selected rune for enchanting
                runeImage.sprite = Runes[RuneIndex];

                ChangeColour();

                return;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) //WHEN SCROLLING DOWN
            {
                this.gameObject.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z - 13.8461538462f); //Rotates it downward (360 / 26 = 13.8461538462
                RuneIndex--; //decreases index
                wheelScroll.Play();
                if (RuneIndex > 25) //If it exceedes the alphabet length set it to the other end.
                {
                    RuneIndex = 0;
                }
                if (RuneIndex < 0)
                {
                    RuneIndex = 25;
                }
                SelectedRune = Rune[RuneIndex]; //Set the selected rune for enchanting
                runeImage.sprite = Runes[RuneIndex];

                ChangeColour();

                return;
            }
        }
        //OnMouseOver();
    }

    private void OnMouseOver() //see if the players mouse is hovering over it
    {
        canSpin = true; //allow player to spin this pin
    }
    //Mosue is not hovering over the object
    private void OnMouseExit()
    {
        canSpin = false;
    }
    //Functions which changes the colour on the runes
    private void ChangeColour()
    {
        didRun = true;
        if (WheelNumber == 1)
        {
            switch (RuneIndex)
            {
                case 2:
                    runeImage.color = new Color32(0, 255, 255, 255);
                    break;
                case 4:
                    runeImage.color = new Color32(255, 0, 0, 255);
                    break;
                case 15:
                    runeImage.color = new Color32(0, 0, 255, 255);
                    break;
                case 19:
                    runeImage.color = new Color32(0, 255, 0, 255);
                    break;
                case 13:
                    runeImage.color = new Color32(255, 0, 255, 255);
                    break;
                case 1:
                    runeImage.color = new Color32(255, 255, 0, 255);
                    break;
                default:
                    runeImage.color = new Color32(255, 255, 255, 255);
                    break;
            }

        }
        //else runeImage.color = new Color32(255, 255, 255, 255);

        if (WheelNumber == 2)
        {
            switch (RuneIndex)
            {
                case 7:
                    runeImage.color = new Color32(0, 255, 255, 255);
                    break;
                case 12:
                    runeImage.color = new Color32(255, 0, 0, 255);
                    break;
                case 24:
                    runeImage.color = new Color32(0, 0, 255, 255);
                    break;
                case 14:
                    runeImage.color = new Color32(0, 255, 0, 255);
                    break;
                case 4:
                    runeImage.color = new Color32(255, 0, 255, 255);
                    break;
                case 11:
                    runeImage.color = new Color32(255, 255, 0, 255);
                    break;
                default:
                    runeImage.color = new Color32(255, 255, 255, 255);
                    break;
            }

        }
        //else runeImage.color = new Color32(255, 255, 255, 255);

        if (WheelNumber == 3)
        {
            switch (RuneIndex)
            {
                case 8:
                    runeImage.color = new Color32(0, 255, 255, 255);
                    break;
                case 1:
                    runeImage.color = new Color32(255, 0, 0, 255);
                    break;
                case 11:
                    runeImage.color = new Color32(0, 0, 255, 255);
                    break;
                case 23:
                    runeImage.color = new Color32(0, 255, 0, 255);
                    break;
                case 2:
                    runeImage.color = new Color32(255, 0, 255, 255);
                    break;
                case 4:
                    runeImage.color = new Color32(255, 255, 0, 255);
                    break;
                default:
                    runeImage.color = new Color32(255, 255, 255, 255);
                    break;
            }

        }
      //  else runeImage.color = new Color32(255, 255, 255, 255);

        if (WheelNumber == 4)
        {
            switch (RuneIndex)
            {
                case 11:
                    runeImage.color = new Color32(0, 255, 255, 255);
                    break;
                case 4:
                    runeImage.color = new Color32(255, 0, 0, 255);
                    break;
                case 14:
                    runeImage.color = new Color32(0, 0, 255, 255);
                    break;
                case 8:
                    runeImage.color = new Color32(0, 255, 0, 255);
                    break;
                case 17:
                    runeImage.color = new Color32(255, 0, 255, 255);
                    break;
                case 18:
                    runeImage.color = new Color32(255, 255, 0, 255);
                    break;
                default:
                    runeImage.color = new Color32(255, 255, 255, 255);
                    break;
            }

        }
       // else runeImage.color = new Color32(255, 255, 255, 255);

        if (WheelNumber == 5)
        {
            switch (RuneIndex)
            {
                case 11:
                    runeImage.color = new Color32(0, 255, 255, 255);
                    break;
                case 17:
                    runeImage.color = new Color32(255, 0, 0, 255);
                    break;
                case 13:
                    runeImage.color = new Color32(0, 0, 255, 255);
                    break;
                case 2:
                    runeImage.color = new Color32(0, 255, 0, 255);
                    break;
                case 14:
                    runeImage.color = new Color32(255, 0, 255, 255);
                    break;
                case 18:
                    runeImage.color = new Color32(255, 255, 0, 255);
                    break;
                default:
                    runeImage.color = new Color32(255, 255, 255, 255);
                    break;
            }

        }
        //else runeImage.color = new Color32(255, 255, 255, 255);
    }
}
