using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    int currentScene = 0;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadNextScene();
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
