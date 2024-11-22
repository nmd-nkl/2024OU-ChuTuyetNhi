using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    public static UITutorial instance;
    private void Awake() {
        instance = this;
    }
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtLv;
    //Theo ham parabol
    //Ui thang thua - lv - scrore
    //clean code
    //vi du speed de cho khac,
    //UI ko nen co data
    //Tim hieu Action
    //Plugin
    private void UpdateScore(int score) {
        txtScore.text = "Score: " + score;
    }
}
