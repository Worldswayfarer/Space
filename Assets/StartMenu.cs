using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public TMP_Text text;

    public void SwitchScreen() 
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void OnEnable()
    {
        if(PlayerPrefs.GetInt("highscore").ToString() is null)
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
        text.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
