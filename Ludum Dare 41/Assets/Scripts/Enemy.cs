using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool AISwitchedOn;

    [Tooltip("How close the Player has to be for the AI to activate")]
    public int activateDistance; 
    public int hearts;
    public int damageOnHit;

    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private GameObject player;

    //For Drawback
    [Tooltip("Not Necessery for every enemy")]
    [SerializeField]
    private GameObject firingPoint;
    [Tooltip("Not Necessery for every enemy")]
    [SerializeField]
    private GameObject projectile;

    //For Jock
    [Tooltip("Not Necessery for every enemy")]
    [SerializeField]
    private ConstantForce2D constantForce2D;

    public enum Enemytype
    {
        Jock,
        Drawback
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
        //If inside aggro range and AI Type has not yet been selected
        if (gameObject.transform.position.x - player.transform.position.x <= activateDistance && AISwitchedOn == false)
        {
            //Find appropriate AI
            switch (EnemyType)
            {
                case Enemytype.Jock:
                    constantForce2D.force = new Vector2(-5f, 0);
                    break;
                case Enemytype.Drawback:
                    StartCoroutine(DrawbackAI());
                    break;

                //If no AI could be found
                default:
                    print("Sorry, something went wrong determining this beasts AI");
                    break;
            }          
            AISwitchedOn = true; //Prevent block from running again
        }
    }

    private IEnumerator DrawbackAI()
    {
        while (true)
        {
            //Constantly look at the player
            firingPoint.transform.LookAt2D(player.transform.position);
            yield return new WaitForSeconds(3f);
            firingPoint.transform.LookAt2D(player.transform.position);

            //Fire every - seconds
            ExtensionMethods.Fire(2.5f, projectile, firingPoint);
        }
    }
}
