using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject Resume;
    public GameObject Retry;
    bool isPause = false;
    bool isDead = false;

    public void Start()
    {
        Retry.SetActive(false);
    }

    public void pauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPause= true;
    }

    public void resumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f; 
        isPause= false;
    }

    public void endScreen()
    {
        Retry.SetActive(true);
        pauseGame();
        Resume.SetActive(false);
        isDead = true;
    }

    public void restartGame()
    {
        isDead = false;
        Retry.SetActive(false);
        Resume.SetActive(true);
        SceneManager.LoadScene("StartMenu");
        SceneManager.LoadScene("GameScreen");
        resumeGame();
    }

    public void switchScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    private void OnCancel()
    {
        if (isDead) { return; }
        if(isPause)
        {
            resumeGame();
            return;
        }
        pauseGame();
    }
}
