using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    private Vector3 positionToCamera;

    // Update is called once per frame
    void Update ()
    {
         positionToCamera = Camera.main.WorldToViewportPoint(transform.position);

        if (positionToCamera.x > 1.5f || positionToCamera.x < -0.5f || positionToCamera.y > 1.5f || positionToCamera.y < -0.5f)
        {
            Destroy(gameObject);
        }
	}
}
