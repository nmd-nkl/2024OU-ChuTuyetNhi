using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMiniCar
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CarMovement : MonoBehaviour
    {
        public float speed = 10.0f;
        public Rigidbody2D m_rigidbody2D;

        private void OnValidate()
        {
            m_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {

            Vector2 input = new(Input.GetAxis("Horizontal"), 0);
            Move(input);
        }

        public void Move(Vector2 input)
        {
            m_rigidbody2D.velocity = input * speed;
        }


    }

}

