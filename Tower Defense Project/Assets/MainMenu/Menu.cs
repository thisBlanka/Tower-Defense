using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
