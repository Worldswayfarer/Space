using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class SliderUi : MonoBehaviour
{
    public IntVariable PlayerHealth;
    public Slider Slider;
    public GameEvent PlayerDeath;
    public IntVariable score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSlider();
    }

    // Update is called once per frame
    public void UpdateSlider()
    {
        Slider.value = PlayerHealth.RuntimeValue;
        if (PlayerHealth.RuntimeValue <= 0)
        {
            if (score.RuntimeValue > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", score.RuntimeValue);
            }
            PlayerDeath.Raise();
        }
    }
}
