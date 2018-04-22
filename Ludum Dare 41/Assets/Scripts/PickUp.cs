using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int amount;

    private JuiceLibrary juiceLibrary;
    public AudioClip pickUpMana;
    public AudioClip pickUpHeart;

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
                    juiceLibrary.PlaySound(pickUpMana);

                    Destroy(gameObject);
                    break;
                case Pickup.health:
                    PlayerStats.hearts ++;
                    juiceLibrary.PlaySound(pickUpHeart);

                    Destroy(gameObject);
                    break;
                default:
                    print("Pick Up Type couldn't be found");
                    break;
            }
        }
    }

    void Start()
    {
        juiceLibrary = GameObject.FindGameObjectWithTag("GameController").GetComponent<JuiceLibrary>();
    }
}
