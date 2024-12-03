using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuConfig : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Cr�ditos()
    {
        SceneManager.LoadScene("Cr�ditos");
    }

    public void TelaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Voc� saiu");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
