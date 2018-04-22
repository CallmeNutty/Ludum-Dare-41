using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject firstImage;

    public void NextLevel()
    {
        for(int k = 0; k < firstImage.transform.childCount; k++)
        {
            if (k != firstImage.transform.childCount - 1)
            {
                if (firstImage.transform.GetChild(k).gameObject.activeInHierarchy == true)
                {
                    firstImage.transform.GetChild(k + 1).gameObject.SetActive(true);
                    firstImage.transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    public void PreviousLevel()
    {     
        for (int k = 0; k < firstImage.transform.childCount; k++)
        {
            if (k != 0)
            {
                if (firstImage.transform.GetChild(k).gameObject.activeInHierarchy == true)
                {
                    firstImage.transform.GetChild(k - 1).gameObject.SetActive(true);
                    firstImage.transform.GetChild(k).gameObject.SetActive(false);
                }
            }
        }
    }

    public void ChangeLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
