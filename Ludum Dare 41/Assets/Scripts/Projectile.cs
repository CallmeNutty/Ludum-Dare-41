using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool enemyProjectile;
    public int damage;

    private Vector3 positionToCamera;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && enemyProjectile == true)
        {
            PlayerStats.hearts -= damage;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Simplfy having to write it out multiple times
        positionToCamera = Camera.main.WorldToViewportPoint(transform.position);

        //If good distance outside the camera
        if (positionToCamera.x > 1.5f || positionToCamera.x < -0.5f || positionToCamera.y > 1.5f || positionToCamera.y < -0.5f)
        {
            Destroy(gameObject);
        }
    }
}
