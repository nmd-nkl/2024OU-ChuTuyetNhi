using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace MJGame {
    public class CarGameController : SingletonComponent<CarGameController> {
        public int score { get; private set; } = 0;
        public int level { get; private set; } = 1;
        public float itemSpeed { get; private set; } = 2;
        public float baseItemSpeed { get; private set; } = 2;
        public SpawnController spawnController;

        // Hàm vận tốc parabol y = a.x^2 + b.x + c
        public float a = 0;   
        public float b = 1; //base speed 
        public float c = 0; //bonus Speed

        private bool canResetLevel = false;
        private void Start() {
            this.Init();
        }
        private void Update() {
            this.CheckResetLevel();
        }
        private void Init() {
            canResetLevel = false;
            itemSpeed = baseItemSpeed;
            b = baseItemSpeed;
            spawnController = GetComponent<SpawnController>();
        }
        #region ActionHandler
        private void OnEnable() {
            ActionCarGame.OnPlayerDied += HandlePlayerDeath;
            ActionCarGame.OnActionScore += AddScore;
        }
        private void OnDisable() {
            ActionCarGame.OnPlayerDied -= HandlePlayerDeath;
            ActionCarGame.OnActionScore -= AddScore;
        }
        #endregion
        private void HandlePlayerDeath() {
            Debug.Log("Game Over!");
            UIHandler.Instance.ShowLoseGame();
            Time.timeScale = 0f;
        }
        private void AddScore(int _score) {
            this.score += _score;
            Debug.Log($"Score: {score}");
            UIHandler.Instance.UpdateScore(this.score);
                
            this.LevelUp();
        }
        private void LevelUp() {
            if (this.score % 3 == 0) {
                this.level++;
                this.canResetLevel = true;
                UIHandler.Instance.UpdateLevel(this.level);
            }

            this.WinCarGame();
        }
        private void WinCarGame() {
            if (this.level == 5) {
                UIHandler.Instance.ShowWinGame();
                Time.timeScale = 0f;
            }
        }
        private void ItemSpeedUp () {
            // y = ax^2 + bx + c
            this.itemSpeed = a * level * level + b * level + c;
            Debug.Log(itemSpeed);
        }

        public void CheckResetLevel() {
            if (this.canResetLevel) {
                if (spawnController.IsItemsOnMap()) {
                    spawnController.OnStopCoroutineItem();
                } else {
                    this.ItemSpeedUp();
                    spawnController.OnStartCoroutineItem();
                    this.canResetLevel = false;
                }
            }
        }
    }
}
