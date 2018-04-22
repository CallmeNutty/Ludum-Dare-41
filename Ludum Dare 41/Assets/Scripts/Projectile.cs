using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool enemyProjectile;
    public bool selfDestruct;
    public int selfDestructTime;
    public float damage;

    private Vector3 positionToCamera;
    public AudioClip hit;
    private JuiceLibrary juiceLibrary;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && enemyProjectile == true)
        {
            PlayerStats.hearts -= (int)damage;
            juiceLibrary.PlaySound(hit);
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructTime);
        Destroy(gameObject);
    }

    void Start()
    {
        if(selfDestruct == true)
        {
            StartCoroutine(SelfDestruct());
        }

        juiceLibrary = GameObject.FindGameObjectWithTag("GameController").GetComponent<JuiceLibrary>();
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
