using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PindahScene : MonoBehaviour
{
    public void Masuk()
    {
        SceneManager.LoadScene("Peta");
    }

    public void Keluar()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Game()
    {
        SceneManager.LoadScene("Game0");
    }

    public void SelectGame()
    {
        SceneManager.LoadScene("PilihGame");
    }
}
