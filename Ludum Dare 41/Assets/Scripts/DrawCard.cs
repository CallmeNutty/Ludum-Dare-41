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
        if (playerHand.hitMaxCards == false)
        {
            playerHand.DrawCard(1);
            PlayerStats.mana -= cost;
        }
        else
        {
            print("Sorry hand's full");
        }
    }
}
