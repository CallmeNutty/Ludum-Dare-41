using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public int cost;

    [SerializeField]
    private PlayerHand playerHand;

    void OnMouseUp()
    {
        //If hand isn't full and can afford to draw
        if (playerHand.hitMaxCards == false && PlayerStats.mana - cost >= 0)
        {
            if (playerHand.Deck.Count > 0)
            {
                playerHand.DrawCard(1);
                PlayerStats.mana -= cost;
            }
        }
        else
        {
            print("Sorry hand's full or You don't have enough mana");
        }
    }
}
