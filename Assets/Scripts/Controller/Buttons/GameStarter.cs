using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Forest");
        Time.timeScale = 1f;
    }


    public void QuitGame()
    {
        UnityEngine.Debug.Log("QuitGame");
        Application.Quit();
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("GameMenuScene");
        Time.timeScale = 1f;
    }


    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f; // Resume the game
        }
        else
        {
            Time.timeScale = 0f; // Pause the game
        }
    }
}