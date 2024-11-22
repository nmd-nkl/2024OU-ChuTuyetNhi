using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


namespace MJGame {
    public class UIHandler : SingletonComponent<UIHandler> {
        [SerializeField] TextMeshProUGUI txtScore;
        [SerializeField] TextMeshProUGUI txtLevel;
        [SerializeField] GameObject WinGame;
        [SerializeField] GameObject LoseGame;
        private void OnEnable() {
            UpdateScore(CarGameController.Instance.score);
            UpdateLevel(CarGameController.Instance.level);
        }
        public void UpdateScore(int score) {
            txtScore.text = "Score: " + score;
        }
        public void UpdateLevel(int level) {
            txtLevel.text = "Level: " + level;
        }
        public void ShowWinGame() {
            WinGame.SetActive(true);
        }
        public void ShowLoseGame() {
            LoseGame.SetActive(true);
        }
    }
}
