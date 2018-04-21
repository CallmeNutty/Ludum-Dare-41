using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cards : MonoBehaviour
{
    [SerializeField]
    public int cardCost;

    [SerializeField]
    private GameObject projectile;

    public enum Cardtype
    {
        FireProjectileFromSide,
        FireProjectileFromTop
    }

    public Cardtype CardType;

    void OnMouseUp()
    {
        if (PlayerStats.mana - cardCost >= 0)
        {
            PlayerStats.mana -= cardCost;

            //Set spell
            switch (CardType)
            {
                case Cardtype.FireProjectileFromSide:
                    FireFromSide(projectile, 1);
                    break;
                case Cardtype.FireProjectileFromTop:
                    FireFromTop(projectile, 1);
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
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0.4f)), Quaternion.identity) as GameObject;
        //Make Object Visible
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
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
}
