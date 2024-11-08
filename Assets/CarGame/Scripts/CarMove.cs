using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] private float _acceleration = 0.005f;
    [SerializeField] private float _deceleration = 0.005f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float gap = 2f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        this.MoveWithRbForce();
        this.ClampPosition();
    }
    void MoveWithRbForce()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input != Vector2.zero)
        {
            rb.AddForce(input * _acceleration, ForceMode2D.Force);

            if (rb.velocity.magnitude > _maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * _maxSpeed;
            }
        }
        else
        {
            rb.AddForce(-rb.velocity * _deceleration, ForceMode2D.Force);
        }
    }
    void ClampPosition()
    {
        Vector3 minBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 maxBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x+gap, maxBounds.x-gap);
        transform.position = clampedPosition;
    }

}
