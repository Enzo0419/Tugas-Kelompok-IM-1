using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TombolDeskripsiUI
{
    public Button tombol;
}

public class DeskripsiChecker : MonoBehaviour
{
    public TombolDeskripsiUI[] tombolDeskripsi;
    public Button tombolMulaiGame;
    public GameObject iconGembokMulai;
    public TMP_Text teksMulai;

    private bool[] statusDibaca;

    void Start()
    {
        statusDibaca = new bool[tombolDeskripsi.Length];
        tombolMulaiGame.interactable = false;
        UpdateMulaiGameUI();

        for (int i = 0; i < tombolDeskripsi.Length; i++)
        {
            int index = i;
            tombolDeskripsi[i].tombol.onClick.AddListener(() => DeskripsiDibaca(index));
        }
    }

    void DeskripsiDibaca(int index)
    {
        statusDibaca[index] = true;
        CekSemuaSudahDibaca();
    }

    void CekSemuaSudahDibaca()
    {
        foreach (bool sudah in statusDibaca)
        {
            if (!sudah) return;
        }

        tombolMulaiGame.interactable = true;
        UpdateMulaiGameUI();
    }

    void UpdateMulaiGameUI()
    {
        bool aktif = tombolMulaiGame.interactable;

        if (iconGembokMulai != null)
            iconGembokMulai.SetActive(!aktif);

        if (teksMulai != null)
            teksMulai.gameObject.SetActive(aktif);
    }
}