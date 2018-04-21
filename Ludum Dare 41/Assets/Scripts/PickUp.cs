using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int amount;

    public enum Pickup
    {
        mana,
        health
    }
    public Pickup PickUpType;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            switch (PickUpType)
            {
                case Pickup.mana:
                    PlayerStats.mana += amount;
                    Destroy(gameObject);
                    break;
                case Pickup.health:
                    PlayerStats.hearts ++;
                    Destroy(gameObject);
                    break;
                default:
                    print("Pick Up Type couldn't be found");
                    break;
            }
        }
    }
}
