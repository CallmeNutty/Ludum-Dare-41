using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cards : MonoBehaviour
{
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
        switch (CardType)
        {
            case Cardtype.FireProjectileFromSide:
                FireFromSide(projectile);
                break;
            case Cardtype.FireProjectileFromTop:
                FireFromTop(projectile);
                break;
            default:
                print("Sorry, there was a mistake with using this card");
                break;
        }
    }

    private void FireFromSide(GameObject projectile)
    {
        //Spawn projectile to the right side of the camera
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0.6f)), Quaternion.identity) as GameObject;
        //Make Object Visible
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
        Destroy(gameObject);
    }

    private void FireFromTop(GameObject projectile)
    {
        //Spawn projectile to the right side of the camera
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 1.05f)), Quaternion.identity) as GameObject;
        //Make Object Visible
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
        Destroy(gameObject);
    }
}
