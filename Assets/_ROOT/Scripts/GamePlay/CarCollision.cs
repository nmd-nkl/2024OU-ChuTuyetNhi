using System.Collections;
using System.Collections.Generic;
using MJGame;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ConstGame.TAG_WALL))
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ConstGame.TAG_ITEM))
        {
            var GameController = SingletonComponent<GameController>.Instance;
            GameController.MapController.RemoveItem(collision.gameObject);
            GameController.AddScore();
            GameController.CheckResetLevel();
        }
    }
}
