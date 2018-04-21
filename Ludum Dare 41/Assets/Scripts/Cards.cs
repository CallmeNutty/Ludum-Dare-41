using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    [SerializeField]
    public int cardCost;
    public int damage;
    public int amountToHail;

    [SerializeField]
    private GameObject projectile;
    private GameObject player;
    //For zoom outs
    public Vector3 baseScale;

    public enum Cardtype
    {
        FireProjectileFromSide,
        FireProjectileFromTop,
        Hail
    }
    
    public Cardtype CardType;

    void OnMouseDown()
    {
        PlayCard();
    }

    void OnMouseOver()
    {
        ScaleCard();
    }

    void OnMouseExit()
    {
        //Reset to previous positions
        transform.localScale = baseScale;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ScaleCard()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    public void PlayCard()
    {
        print("Mouse Down");

        if (PlayerStats.mana - cardCost >= 0)
        {
            PlayerStats.mana -= cardCost;

            //Set spell
            switch (CardType)
            {
                case Cardtype.FireProjectileFromSide:
                    FireFromSide(projectile, damage);
                    break;
                case Cardtype.FireProjectileFromTop:
                    FireFromTop(projectile, damage);
                    break;
                case Cardtype.Hail:
                    Hail(projectile, amountToHail, damage);
                    break;
                default:
                    print("Sorry, there was a mistake with using this card");
                    break;
            }
        }
        else
        {
            print("Sorry, not enough cash");
        }
    }


    private void FireFromSide(GameObject projectile, int damage)
    {
        //Spawn projectile to the right side of the camera
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0, 0)), Quaternion.identity) as GameObject;
        //Make Object Visible and set Y to player
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, player.transform.position.y, 0);
        spawnedObject.GetComponent<Projectile>().damage = damage;

        Destroy(gameObject);
    }

    private void FireFromTop(GameObject projectile, int damage)
    {
        //Spawn projectile to the right side of the camera
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 1.05f)), Quaternion.identity) as GameObject;
        //Make Object Visible
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
        spawnedObject.GetComponent<Projectile>().damage = damage;

        Destroy(gameObject);
    }

    private void Hail(GameObject projectile, int amount, int damage)
    {
        for(int k = 0; k < amount; k++)
        {
            //Spawn projectile to a random location
            GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.45f, 0.9f), Random.Range(1.05f, 1.4f))), Quaternion.identity) as GameObject;
            //Make Object Visible
            spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
            spawnedObject.GetComponent<Projectile>().damage = damage;
        }

        Destroy(gameObject);
    }
}
