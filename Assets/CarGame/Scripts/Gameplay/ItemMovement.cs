using MJGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemMovement : MonoBehaviour {
    Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update() {
        this.MoveWithRb();
    }
    private void MoveWithRb() {
        rb.velocity = Vector2.down * CarGameController.Instance.itemSpeed;
    }
}
