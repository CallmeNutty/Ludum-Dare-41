using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public bool hitMaxCards;
    public int maxCards;

    public List<GameObject> Deck; //Entire Deck of cards
    public GameObject hand; //Cards currently in hand

    [SerializeField]
    private GameObject cardArea;

    //Start is called at the beginning
    void Start()
    {
        ExtensionMethods.Shuffle(Deck);

        DrawCard(3);
    }

    // Update is called once per frame
    void Update ()
    {
        //Iterates through all cards
        for (int k = 0; k < hand.transform.childCount; k++)
        {
            //Sets position
            hand.transform.GetChild(k).transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.175f * (k + 0.5f), 0.135f));
            //Makes visible by setting z to 0
            hand.transform.GetChild(k).transform.position = new Vector3(hand.transform.GetChild(k).transform.position.x, hand.transform.GetChild(k).transform.position.y, 0);
        }

        //Hotkeys
        if (Input.GetKeyDown(KeyCode.Alpha1) && cardArea.transform.childCount > 0) { cardArea.transform.GetChild(0).GetComponent<Cards>().PlayCard(); }
        if (Input.GetKeyDown(KeyCode.Alpha2) && cardArea.transform.childCount > 1) { cardArea.transform.GetChild(1).GetComponent<Cards>().PlayCard(); }
        if (Input.GetKeyDown(KeyCode.Alpha3) && cardArea.transform.childCount > 2) { cardArea.transform.GetChild(2).GetComponent<Cards>().PlayCard(); }
        if (Input.GetKeyDown(KeyCode.Alpha4) && cardArea.transform.childCount > 3) { cardArea.transform.GetChild(3).GetComponent<Cards>().PlayCard(); }
        if (Input.GetKeyDown(KeyCode.Alpha5) && cardArea.transform.childCount > 4) { cardArea.transform.GetChild(4).GetComponent<Cards>().PlayCard(); }

        //Checks if player has hit the maximum amount of cards on their hand
        hitMaxCards = cardArea.transform.childCount == maxCards ? true : false;
    }

    //Method which draws cards specified by amount
    public void DrawCard(int amount)
    {
        for (int k = 0; k < amount; k++)
        {
            //If out of cards in the deck
            if (Deck.Count <= 0)
            {
                break;
            }

            //If space on the hand
            if (cardArea.transform.childCount < maxCards)
            {
                //Pick a random card
                GameObject card = Deck[Random.Range(0, Deck.Count)];
                Instantiate(card, cardArea.transform); //Add to game

                Deck.Remove(Deck.Find(x => x == card)); //Remove from deck
            }
        }
    }
}
