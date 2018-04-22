using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    private bool inArea;

    public enum Door
    {
        EndLevel,
        Gate
    }

    public Door doorTypes;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            inArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            inArea = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerStats.keys > 0 && inArea == true && doorTypes == Door.EndLevel)
        {
            PlayerStats.hearts = 3;
            PlayerStats.mana = 8;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerStats.keys--;
        }

        if(Input.GetKeyDown(KeyCode.E) && PlayerStats.keys > 0 && inArea == true && doorTypes == Door.Gate)
        {
            Destroy(gameObject);
        }
    }
}
