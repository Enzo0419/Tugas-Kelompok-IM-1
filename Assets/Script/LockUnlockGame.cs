using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockUnlockGame : MonoBehaviour
{
    public GameObject game2Button;

    void Start()
    {
        int isUnlocked = PlayerPrefs.GetInt("Game2Unlocked", 0);

        if (isUnlocked == 1)
        {
            game2Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            game2Button.GetComponent<Button>().interactable = false;
        }
    }

}
