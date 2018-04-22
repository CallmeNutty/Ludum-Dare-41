using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool dropped;

    [Tooltip("Which enemy is holding this key")]
    public GameObject heldBy;
    [Tooltip("Where this key should drop \nIf this value is 0,0 it will drop where the mob died")]
    public Vector2 dropPosition;
    private JuiceLibrary juiceLibrary; 
    public AudioClip pickUp;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerStats.keys++;
            juiceLibrary.PlaySound(pickUp);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        juiceLibrary = GameObject.FindGameObjectWithTag("GameController").GetComponent<JuiceLibrary>();

        if(dropPosition == new Vector2(0, 0))
        {
            dropPosition = heldBy.transform.position;
        }
    }

    void Update()
    {
        if(heldBy == null && dropped == false)
        {
            transform.position = dropPosition;
            dropped = true;
        }
    }
}
