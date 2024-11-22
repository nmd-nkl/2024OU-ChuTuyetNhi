using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMiniCar
{
    public class RoadCollision : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(ConstGame.TAG_CAR))
            {
                Debug.Log("Instantiate Road");
                GameController.Instance.SpawnObject.SpawnRoad();
            }
        }
    }
}