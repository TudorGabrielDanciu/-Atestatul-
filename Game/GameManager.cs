using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    //KINGDOM
    public static int kingdomChurch = 50;
    public static int kingdomPopulice = 50;
    public static int kingdomArmy = 50;
    public static int kingdomBourgiose = 50;
    public static int maxValue = 100;
    public static int minValue = 0;

    //Endings
    public enum Endings{
        CHURCH0,
        CHURCH100,
        POP0,
        POP100,
        ARMY0,
        ARMY100,
        BOUR0,
        BOUR100
    }

    //Game objects
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    //Tweeking variables
    public ResourceManager resourceManager;
    public float fMovingSpeed;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideLimit;
    public int draggingCard;
    public Color textColor;
    public Color actionBackgroundColor;
    public float fTransparencymax;
    public Vector2 defaultPositionCard;
    public float fRotationCoefficient;
    //UI
    public TMP_Text actionQuote;
    public TMP_Text characterDialogue;
    public SpriteRenderer actionBackground;
    //Card variables
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card firstCard;
    //Substituting the card
    public bool isSubstituting = false;
    public Vector3 stationaryCardRotation; //default one
    public Vector3 initRotation; //initial rotation of the card
    void Start()
    {
        kingdomChurch = 50;
        kingdomPopulice = 50;
        kingdomArmy = 50;
        kingdomBourgiose = 50;
        LoadCard(firstCard);
    }

    void UpdateDialogue(){
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor;
        if(cardGameObject.transform.position.x > 0){
            actionQuote.text = rightQuote;
        }
        else actionQuote.text = leftQuote;
    }
    
    void Update()
    {

        // Dialogue text handling
        textColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x)/ 2, 1);
        actionBackgroundColor.a = Mathf.Min(Mathf.Abs(cardGameObject.transform.position.x)/ 2, fTransparencymax);

        //Right
        if(cardGameObject.transform.position.x > fSideLimit-0.1){
            if(Input.GetMouseButtonUp(0)){
                draggingCard = 0;
                //Game Over
                if(currentCard.GameOver == 1){
                    SceneManager.LoadScene(0);
                    return;
                }
                currentCard.Right();
                if(kingdomChurch < minValue) LoadCard(resourceManager.endings[(int)Endings.CHURCH0]);
                else if(kingdomChurch > maxValue) LoadCard(resourceManager.endings[(int)Endings.CHURCH100]);
                else if(kingdomPopulice < minValue) LoadCard(resourceManager.endings[(int)Endings.POP0]);
                else if(kingdomPopulice >maxValue) LoadCard(resourceManager.endings[(int)Endings.POP100]);
                else if(kingdomArmy < minValue) LoadCard(resourceManager.endings[(int)Endings.ARMY0]);
                else if(kingdomArmy > maxValue) LoadCard(resourceManager.endings[(int)Endings.ARMY100]);
                else if(kingdomBourgiose < minValue) LoadCard(resourceManager.endings[(int)Endings.BOUR0]);
                else if(kingdomBourgiose > maxValue) LoadCard(resourceManager.endings[(int)Endings.BOUR100]);
                else NewCard();
            }
        }
        //Left
        else if(cardGameObject.transform.position.x < -fSideLimit+0.1){
            if(Input.GetMouseButtonUp(0)){
                draggingCard = 0;
                //Game Over
                if(currentCard.GameOver == 1){
                    SceneManager.LoadScene(0);
                    return;
                }
                currentCard.Left();
                if(kingdomChurch < minValue) LoadCard(resourceManager.endings[(int)Endings.CHURCH0]);
                else if(kingdomChurch > maxValue) LoadCard(resourceManager.endings[(int)Endings.CHURCH100]);
                else if(kingdomPopulice < minValue) LoadCard(resourceManager.endings[(int)Endings.POP0]);
                else if(kingdomPopulice >maxValue) LoadCard(resourceManager.endings[(int)Endings.POP100]);
                else if(kingdomArmy < minValue) LoadCard(resourceManager.endings[(int)Endings.ARMY0]);
                else if(kingdomArmy > maxValue) LoadCard(resourceManager.endings[(int)Endings.ARMY100]);
                else if(kingdomBourgiose < minValue) LoadCard(resourceManager.endings[(int)Endings.BOUR0]);
                else if(kingdomBourgiose > maxValue) LoadCard(resourceManager.endings[(int)Endings.BOUR100]);
                else NewCard();
            }
        }
        UpdateDialogue();

        

        //Movement
        if(draggingCard == 1){
            if(Input.GetMouseButtonUp(0)) draggingCard = 0;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(pos.x > 0) cardGameObject.transform.position = new Vector2(Mathf.Min(pos.x,fSideLimit),defaultPositionCard.y);
            else cardGameObject.transform.position = new Vector2(Mathf.Max(pos.x,-fSideLimit),defaultPositionCard.y);
            cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);
        }
        else if(Input.GetMouseButton(0)  && mainCardController.isMouseOver){
            draggingCard = 1;
        }
        else if (!isSubstituting){
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
            cardGameObject.transform.eulerAngles = new Vector3(0,0,0);
        }
        else if(isSubstituting){
            cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, stationaryCardRotation, fRotatingSpeed);
        }

        if(cardGameObject.transform.eulerAngles == stationaryCardRotation){
            isSubstituting = false;
        }

    }

    public void LoadCard(Card card){
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
        //Resetting the position of the card
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0,0,0);
        //Initiation of the substitution
        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initRotation;
    }

    public void NewCard(){
        //Sequencing
        if(currentCard.nextCard){
            LoadCard(currentCard.nextCard);
        }
        else{
            int rollDice = Random.Range(0, resourceManager.cards.Length);
            LoadCard(resourceManager.cards[rollDice]);
        }
    }

}

