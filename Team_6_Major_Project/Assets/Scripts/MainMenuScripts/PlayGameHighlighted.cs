using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PlayGameHighlighted : MonoBehaviour
{
    public GameObject HLSparks;
    //Function which checks when the mouse hoverOvers the button which produces sparks
    public void OnPointerEnter(PointerEventData eventData)
    {
        HLSparks.SetActive(true);
        HLSparks.transform.position = new Vector3(0f, 0.295f, -0.57f);
    }
    //Turns off the sparks
    private void OnMouseExit()
    {
        HLSparks.SetActive(false);
    }
}
