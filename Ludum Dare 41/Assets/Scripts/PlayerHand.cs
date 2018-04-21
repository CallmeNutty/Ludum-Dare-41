using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public GameObject[] deck;
    public GameObject hand;
	
	// Update is called once per frame
	void Update ()
    {
        for (int k = 0; k < hand.transform.childCount; k++)
        {
            hand.transform.GetChild(k).transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.2f * (k + 1), 0.15f));
            hand.transform.GetChild(k).transform.position = new Vector3(hand.transform.GetChild(k).transform.position.x, hand.transform.GetChild(k).transform.position.y, 0);
        }
	}
}
