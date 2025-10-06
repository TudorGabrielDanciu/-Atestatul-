using UnityEngine;

[CreateAssetMenu]

public class Card : ScriptableObject
{
  //Basic card values
  public int GameOver;
  public CardSprite sprite;
  public string dialogue;
  public string leftQuote;
  public string rightQuote;

  //For card sequences
  public Card nextCard;

  //Impact values

  //LEFT
  public int kChurchLeft;
  public int kPopuliceLeft;
  public int kArmyLeft;
  public int kBourgoiseLeft;

  //RIGHT
  public int kChurchRight;
  public int kPopuliceRight;
  public int kArmyRight;
  public int kBourgoiseRight;

  public void Left(){
    //Appending the valuess
    GameManager.kingdomChurch += kChurchLeft;
    GameManager.kingdomPopulice += kPopuliceLeft;
    GameManager.kingdomArmy += kArmyLeft;
    GameManager.kingdomBourgiose += kBourgoiseLeft;
  }
  public void Right(){
    //Appending the valuess
    GameManager.kingdomChurch += kChurchRight;
    GameManager.kingdomPopulice += kPopuliceRight;
    GameManager.kingdomArmy += kArmyRight;
    GameManager.kingdomBourgiose += kBourgoiseRight;
  }



}
