using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;


public class CardController : MonoBehaviour
{
    public bool isMouseOver = false;

    private void OnMouseOver(){
      isMouseOver = true;
    } 
    private void OnMouseExit(){
      isMouseOver = false;
    }
}

public enum CardSprite
{
    DEATH,
    GENERAL,
    PRIEST,
    KNIGHT,
    PEASANT,
    PRINCESS,
    WITCH,
    KING
}

