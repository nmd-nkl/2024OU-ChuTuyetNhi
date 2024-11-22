using System.Collections;
using System.Collections.Generic;
using MJGame;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ConstGame.TAG_ITEM))
        {
            var GameController = SingletonComponent<GameController>.Instance;
            GameController.MapController.RemoveItem(collision.gameObject);
            GameController.CheckResetLevel();
        }

        if (collision.gameObject.CompareTag(ConstGame.TAG_ROAD))
        {
            Destroy(collision.gameObject);
        }
    }
}
