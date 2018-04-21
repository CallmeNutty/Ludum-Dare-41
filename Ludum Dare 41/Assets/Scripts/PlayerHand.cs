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
            hand.transform.GetChild(k).transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.175f * (k + 0.5f), 0.15f));
            //Makes visible by setting z to 0
            hand.transform.GetChild(k).transform.position = new Vector3(hand.transform.GetChild(k).transform.position.x, hand.transform.GetChild(k).transform.position.y, 0);
        }

        hitMaxCards = cardArea.transform.childCount <= maxCards ? false : true;
    }

    //Method which draws cards specified by amount
    public void DrawCard(int amount)
    {
        for (int k = 0; k < amount; k++)
        {
            if (Deck.Count <= 0)
            {
                print("Sorry, no cards left");
                break;
            }

            if (cardArea.transform.childCount < maxCards)
            {
                GameObject card = Deck[Random.Range(0, Deck.Count)];
                Instantiate(card, cardArea.transform);

                Deck.Remove(Deck.Find(x => x == card)); //Remove from deck
            }
        }
    }
}
