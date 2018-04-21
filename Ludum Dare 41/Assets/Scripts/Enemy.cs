using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool AISwitchedOn;

    //How close the Player has to be for the AI to activate
    public int activateDistance; 
    public int hearts;
    public int damageOnHit;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private ConstantForce2D constantForce2D;

    public enum Enemytype
    {
        Jock
    }

    public Enemytype EnemyType;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerStats.hearts -= damageOnHit;
            Destroy(gameObject);
        }

        if(coll.gameObject.tag == "Projectile")
        {
            Projectile projectile = coll.gameObject.GetComponent<Projectile>();
            hearts -= projectile.damage;
            if(hearts <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (gameObject.transform.position.x - Player.transform.position.x <= activateDistance && AISwitchedOn == false)
        {
            //Find appropriate AI
            switch (EnemyType)
            {
                case Enemytype.Jock:
                    constantForce2D.force = new Vector2(-5f, 0);
                    break;
                //If no AI could be found
                default:
                    print("Sorry, something went wrong determining this beasts AI");
                    break;
            }

            AISwitchedOn = true;
        }
    }
}
