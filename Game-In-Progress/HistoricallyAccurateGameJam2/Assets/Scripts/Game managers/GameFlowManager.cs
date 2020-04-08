using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameFlowManager : ScriptableObject
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public static void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene == 3)
        {
            SceneManager.LoadScene("Start Menu");
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
