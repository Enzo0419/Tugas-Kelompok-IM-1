using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSelesai : MonoBehaviour
{
    public TMP_Text Teks_Score;

    // Start is called before the first frame update
    public void Start()
    {
        if(Data.DataScore >= PlayerPrefs.GetInt("score"))
        {
            PlayerPrefs.GetInt("score", Data.DataScore);
        }

        Teks_Score.text = Data.DataScore.ToString();
    }
}
