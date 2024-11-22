using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionCarGame {
    public static event Action OnPlayerDied;
    public static void PlayerDied() {
        OnPlayerDied?.Invoke();
    }
    public static event Action<int> OnActionScore;
    public static void AddScore(int _score) {
        OnActionScore?.Invoke(_score);
    }
    public static event Action<int> OnActionLevel;
    public static void LevelUp(int _level) {
        OnActionLevel?.Invoke(_level);
    }
}
