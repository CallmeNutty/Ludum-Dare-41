using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int hearts = 3;
    public static int mana = 5;

    public GameObject allHearts;

    private Image[] allHeartsUI;
    public Text manaText;

    void Start()
    {
        allHeartsUI = new Image[allHearts.transform.childCount];

        for(int k = 0; k < allHeartsUI.Length; k++)
        {
            allHeartsUI[k] = allHearts.transform.GetChild(k).GetComponent<Image>();
        }
    }

    void Update()
    {
        if(hearts <= 0)
        {
            print("ded");
        }
        
        //Iterate through all heart images
        for(int k = 0; k < allHeartsUI.Length; k++)
        {
            //Checks if current Image is less than the amount of hearts player has
            if(k >= hearts)
            {
                //Hide Heart
                allHeartsUI[k].color = ExtensionMethods.ChangeAlpha(allHeartsUI[k].color, 0);
            }
            else
            {
                //Show Heart
                allHeartsUI[k].color = ExtensionMethods.ChangeAlpha(allHeartsUI[k].color, 255);
            }
        }

        manaText.text = "Mana\n" + mana;

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.H))
        {
            hearts += 1;
        }
        else if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.M))
        {
            mana += 1;
        }

        print(hearts);
    }
}
