using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    string SaveNamaScene;

    public void Btn_Pindah(string nama)
    {
        this.gameObject.SetActive(true);
        SaveNamaScene = nama;
    }

    public void pindah()
    {
        SceneManager.LoadScene(SaveNamaScene);
    }
}
