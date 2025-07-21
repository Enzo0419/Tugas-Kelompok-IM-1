using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TampilSkor : MonoBehaviour
{
    public TMP_Text skorText;

    void Start()
    {
        int skor = PlayerPrefs.GetInt("skor", 0);
        skorText.text = skor.ToString();
    }
}