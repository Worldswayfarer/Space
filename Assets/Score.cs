using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public IntVariable ScoreValue;
    private TMP_InputField text;

    void Awake()
    {
        text = GetComponent<TMP_InputField>();
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = ScoreValue.RuntimeValue.ToString();
    }
}
