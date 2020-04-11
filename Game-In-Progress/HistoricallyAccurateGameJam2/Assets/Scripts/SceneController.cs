using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] CanvasGroup infoLayout = null;

    int currentScene = 0;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        InfoLayoutOn();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (infoLayout.gameObject.activeSelf)
            {
                InfoLayoutOFF();
            }
            else
            {
                InfoLayoutOn();
            }
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    private void InfoLayoutOn()
    {
        Time.timeScale = 0f;
        infoLayout.gameObject.SetActive(true);
    }

    public void InfoLayoutOFF()
    {
        Time.timeScale = 1f;
        infoLayout.gameObject.SetActive(false);
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
