using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ObsMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D m_rigidbody2D;

    private void OnValidate()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Init(float speed)
    {
        this.speed = speed;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        m_rigidbody2D.velocity = Vector2.down * speed;
    }
}
