using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool hop;
    public int maxSpeed;
    private int timer;
    public int jumpCoolDown;

    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private Animator animator;
    public AudioClip hopSound;
    public AudioClip jump;
    private JuiceLibrary juiceLibrary;

    void Start()
    {
        juiceLibrary = GameObject.FindGameObjectWithTag("GameController").GetComponent<JuiceLibrary>();   
    }

    void Update()
    {
        //Left and right movement
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
            animator.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
            animator.SetBool("Walking", true);
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walking", false);
        }

        //If cooldown is over and can afford to jump
        if (Input.GetKeyDown(KeyCode.W) && timer >= jumpCoolDown && PlayerStats.mana - 1 >= 0)
        {
            rb2d.AddForce(new Vector2(0, 32), ForceMode2D.Impulse);
            juiceLibrary.PlaySound(jump);
            PlayerStats.mana -= 1;

            timer = 0;
        }
        timer++;
        
        if(transform.position.y < -30)
        {
            PlayerStats.hearts = 0;
        }

        //For walk cycle
        if(hop == true)
        {
            Hop();
            hop = false;
        }

        Camera.main.transform.position = new Vector3(transform.position.x + 4f, transform.position.y, -10);
    }

    void FixedUpdate()
    {
        Vector3 v = rb2d.velocity;
        v.x = Mathf.Clamp(v.x, -maxSpeed, maxSpeed);
        rb2d.velocity = v;
    }

    void Hop()
    {
        rb2d.AddForce(new Vector2(0, 0.5f), ForceMode2D.Impulse);
        juiceLibrary.PlaySound(hopSound);
    }
}
