using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelGamePlay : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtLevel;

    private void OnEnable()
    {
        ActionGame.OnActionScore += UpdateScore;
        ActionGame.OnActionLevel += UpdateLevel;

        Init();
    }


    public void Init()
    {
        ActionGame.OnActionScore?.Invoke(GameController.Instance.score);
        ActionGame.OnActionLevel?.Invoke(GameController.Instance.level);
    }

    public void UpdateScore(int score)
    {
        txtScore.text = "Score: " + score;
    }

    public void UpdateLevel(int level)
    {
        txtLevel.text = "Level: " + level;
    }

    private void OnDisable()
    {
        ActionGame.OnActionScore -= UpdateScore;
        ActionGame.OnActionLevel -= UpdateLevel;
    }
}
