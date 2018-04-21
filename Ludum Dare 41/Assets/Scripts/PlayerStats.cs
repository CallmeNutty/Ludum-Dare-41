using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int hearts = 3;
    public static int mana = 10;

    void Update()
    {
        if(hearts <= 0)
        {
            print("ded");
        }    
    }
}
