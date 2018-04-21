using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(-0.1f, 0));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0.1f, 0));
        }

        Camera.main.transform.position = new Vector3(transform.position.x + 6.8f, Camera.main.transform.position.y, -10);
    }
}
