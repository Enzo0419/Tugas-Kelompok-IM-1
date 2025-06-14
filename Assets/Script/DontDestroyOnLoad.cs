using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad instance;

    void Awake()
    {
        // Cek apakah sudah ada instance lain
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Pertahankan game object ini
        }
        else
        {
            Destroy(gameObject); // Hapus duplikat jika sudah ada
        }
    }
}