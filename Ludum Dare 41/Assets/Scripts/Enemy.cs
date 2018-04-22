using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool AISwitchedOn;
    private JuiceLibrary juiceLibrary;

    [Header("Necessery for every enemy")]
    public int activateDistance; 
    public float health;
    public int damageOnHit;
    public AudioClip enemyHit;
    public AudioClip hit;
    public Enemytype EnemyType;

    [Header("Dependant on Type")]
    [Tooltip("The amount of Constant Force to be applied to the Jock")]
    public int constantForceToApply;
    public float rateOfFire;
    public float projectileSpeed;
    public bool upsideDown;

    [SerializeField]
    private Rigidbody2D rb2d;
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
        Drawback,
        Jabelin
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerStats.hearts -= damageOnHit;

            juiceLibrary.PlaySound(hit);
            StartCoroutine(juiceLibrary.BlinkRed(player));

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Projectile")
        {
            //Find the projectile and lose hearts by it's damage amount
            Projectile projectile = coll.gameObject.GetComponent<Projectile>();
            health -= projectile.damage;
            juiceLibrary.PlaySound(enemyHit);
            //Life check
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        juiceLibrary = GameObject.FindGameObjectWithTag("GameController").GetComponent<JuiceLibrary>();
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
                    constantForce2D.force = new Vector2(constantForceToApply, 0);
                    break;
                case Enemytype.Drawback:
                    StartCoroutine(DrawbackAI());
                    break;
                case Enemytype.Jabelin:
                    if (upsideDown) { rb2d.AddForce(new Vector2(0, -30)); } else { rb2d.AddForce(new Vector2(0, 30)); };
                    break;

                //If no AI could be found
                default:
                    print("Sorry, something went wrong determining this beasts AI");
                    break;
            }          
            AISwitchedOn = true; //Prevent block from running again
        }

        //If fallen into the abyss
        if(transform.position.y < -100 || transform.position.y > 100)
        {
            //Kill
            Destroy(gameObject);
        }
    }

    private IEnumerator DrawbackAI()
    {
        while (true)
        {
            //Constantly look at the player
            firingPoint.transform.LookAt2D(player.transform.position);
            yield return new WaitForSeconds(rateOfFire);
            firingPoint.transform.LookAt2D(player.transform.position);

            //Fire every - seconds
            ExtensionMethods.Fire(projectileSpeed, projectile, firingPoint);
        }
    }
}
