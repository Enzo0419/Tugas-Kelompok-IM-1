using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skor : MonoBehaviour
{
    public TMP_Text skorText;

    public void ResetSkor()
    {
        PlayerPrefs.SetInt("skor", 0);
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt ("skor", 0);
        ResetSkor();
    }
    // Update is called once per frame
    void Update()
    {
        skorText.text = PlayerPrefs.GetInt("skor").ToString();
    }
}