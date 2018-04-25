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
        DrawNewCard();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStats.mana - 1 >= 0)
        {
            DrawNewCard();
        }
    }

    void DrawNewCard()
    {
        //If hand isn't full and can afford to draw
        if (playerHand.hitMaxCards == false && PlayerStats.mana - cost >= 0)
        {
            playerHand.DrawCard(1);
            PlayerStats.mana -= cost;
        }
    }
}
