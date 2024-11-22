using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarMove : MonoBehaviour {
    [SerializeField] float carSpeed = 5f;
    [SerializeField] float gap = 2f;
    Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        this.MoveWithRb();
        this.ClampPosition();
    }
    void MoveWithRb() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = input * carSpeed;
    }
    void ClampPosition() {
        Vector3 minBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 maxBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x + gap, maxBounds.x - gap);
        transform.position = clampedPosition;
    }
}
