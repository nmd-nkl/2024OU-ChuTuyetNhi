using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [SerializeField] float itemSpeed = 0f;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 newPosition = (Vector3)rb.position - transform.up * Time.deltaTime * itemSpeed;
        this.rb.MovePosition(newPosition);
    }
}
