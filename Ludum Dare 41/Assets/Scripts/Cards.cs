using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cards : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    void OnMouseUp()
    {
        ThrowBall(projectile);
        print("CLICKED CARD");
    }

    private void ThrowBall(GameObject projectile)
    {
        //Spawn projectile to the right side of the camera
        GameObject spawnedObject = Instantiate(projectile, Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.6f)), Quaternion.identity) as GameObject;
        //Make Object Visible
        spawnedObject.transform.position = new Vector3(spawnedObject.transform.position.x, spawnedObject.transform.position.y, 0);
    }
}
