using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int timer;
    public int jumpCoolDown;

    [SerializeField]
    private Rigidbody2D rb2d;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.1f, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.1f, 0));
        }

        if (Input.GetKeyDown(KeyCode.W) && timer >= jumpCoolDown && PlayerStats.mana - 1 >= 0)
        {
            rb2d.AddForce(new Vector2(0, 1.5f), ForceMode2D.Impulse);
            PlayerStats.mana -= 1;

            timer = 0;
        }

        timer++;

        Camera.main.transform.position = new Vector3(transform.position.x + 6.8f, Camera.main.transform.position.y, -10);
    }
}
