using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiver : MonoBehaviour
{
    [SerializeField] protected BoxCollider2D boxCollider2D;
    [SerializeField] protected int hp, hpLimit;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected int points = 0;
    private void Awake()
    {
        this.hp = this.hpLimit;
        this.isDead = false;
        this.points = 0;
    }
    public virtual void Deduct(int damage)
    {
        if (isDead) return;
        this.hp -= damage;
        if (this.hp < 0) hp = 0;
        this.CheckDead();
    }
    public virtual void ReceivePoint(int point) { 
        if (isDead) return;
        this.points += point;
        Debug.Log(points);
    }
    protected bool IsDead() { return this.hp <= 0; }
    protected virtual void CheckDead()
    {
        if (!IsDead()) return;
        isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {
        Debug.Log("YOU LOSE!!");
        Time.timeScale = 0;
    }
}
