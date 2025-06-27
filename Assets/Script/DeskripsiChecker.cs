using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeskripsiChecker : MonoBehaviour
{
    public Button[] tombolDeskripsi;
    public Button tombolMulaiGame;

    private bool[] statusDibaca;

    void Start()
    {
        statusDibaca = new bool[tombolDeskripsi.Length];
        tombolMulaiGame.interactable = false;

        for (int i = 0; i < tombolDeskripsi.Length; i++)
        {
            int index = i;
            tombolDeskripsi[i].onClick.AddListener(() => DeskripsiDibaca(index));
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
    }
}
