using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemSender : MonoBehaviour
{
    [SerializeField] protected int damage = 0;
    [SerializeField] protected int point = 1;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerReceiver receiver = collision.GetComponentInChildren<PlayerReceiver>();
        if (receiver != null)
        {
            this.Send(receiver);
        }
        ObjectPooler.Instance.Despawn(gameObject);
    }

    public virtual void Send(PlayerReceiver receiver)
    {
        receiver.Deduct(this.damage);
        receiver.ReceivePoint(this.point);
    }
}
