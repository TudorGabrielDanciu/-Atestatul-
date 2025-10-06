using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Card
    public GameManager gameManager;
    public GameObject card;
    //UI Icons
    public Image kingdomChurchBack;
    public Image kingdomPopuliceBack;
    public Image kingdomArmyBack;
    public Image kingdomBourgioseBack;
    public Image kingdomChurchFilled;
    public Image kingdomPopuliceFilled;
    public Image kingdomArmyFilled;
    public Image kingdomBourgioseFilled;
    //UI impact icon
    public Image kingdomChurchImpact;
    public Image kingdomPopuliceImpact;
    public Image kingdomArmyImpact;
    public Image kingdomBourgioseImpact;
    void Update()
    {
        //Ui Icons
        kingdomChurchBack.fillAmount = 1.0f - (float) GameManager.kingdomChurch / GameManager.maxValue;
        kingdomPopuliceBack.fillAmount = 1.0f - (float) GameManager.kingdomPopulice / GameManager.maxValue;
        kingdomArmyBack.fillAmount = 1.0f - (float) GameManager.kingdomArmy / GameManager.maxValue;
        kingdomBourgioseBack.fillAmount = 1.0f - (float) GameManager.kingdomBourgiose / GameManager.maxValue;
        kingdomChurchFilled.fillAmount = (float) GameManager.kingdomChurch / GameManager.maxValue;
        kingdomPopuliceFilled.fillAmount = (float) GameManager.kingdomPopulice / GameManager.maxValue;
        kingdomArmyFilled.fillAmount = (float) GameManager.kingdomArmy / GameManager.maxValue;
        kingdomBourgioseFilled.fillAmount = (float) GameManager.kingdomBourgiose / GameManager.maxValue;
        //UI Impact icon
        //Right
        if(card.transform.position.x > 1){
            if(gameManager.currentCard.kChurchRight != 0)
                kingdomChurchImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kPopuliceRight != 0)
                kingdomPopuliceImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kArmyRight != 0)
                kingdomArmyImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kBourgoiseRight != 0)
                kingdomBourgioseImpact.transform.localScale = new Vector3(0.25f,0.25f,0);  
        }
        //Left
        else if(card.transform.position.x < -1){
            if(gameManager.currentCard.kChurchLeft != 0)
                kingdomChurchImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kPopuliceLeft != 0)
                kingdomPopuliceImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kArmyLeft != 0)
                kingdomArmyImpact.transform.localScale = new Vector3(0.25f,0.25f,0);
            if(gameManager.currentCard.kBourgoiseLeft != 0)
                kingdomBourgioseImpact.transform.localScale = new Vector3(0.25f,0.25f,0);  
        }
        else{
            kingdomChurchImpact.transform.localScale = new Vector3(0,0,0);
            kingdomPopuliceImpact.transform.localScale = new Vector3(0,0,0);
            kingdomArmyImpact.transform.localScale = new Vector3(0,0,0);
            kingdomBourgioseImpact.transform.localScale = new Vector3(0,0,0);  
        }
    }
}
