using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerReceiver : MonoBehaviour {
    [SerializeField] int carHP = 2;
    [SerializeField] bool isDead = false;

    private void Awake() {
        isDead = false;
    }
    public void Deduct(int damage) {
        if (isDead) return;
        carHP -= damage;
        if (carHP < 0) carHP = 0;
        this.CheckDead();
    }
    public void ReceivePoint(int point) {
        if (isDead) return;
        ActionCarGame.AddScore(point);
    }
    private bool IsDead() { return carHP <= 0; }
    private void CheckDead() {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }
    private void OnDead() {
        ActionCarGame.PlayerDied();
    }
}
