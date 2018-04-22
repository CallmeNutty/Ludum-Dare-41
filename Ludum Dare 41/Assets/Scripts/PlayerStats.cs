using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int hearts = 3;
    public static int mana = 8;
    public static int keys;

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
        if (hearts <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            hearts = 3;
            mana = 5;
            keys = 0;
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
    }
}
