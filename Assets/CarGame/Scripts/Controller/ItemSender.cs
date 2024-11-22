using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemSender : MonoBehaviour {
    [SerializeField] int damage = 0;
    [SerializeField] int point = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        PlayerReceiver receiver = collision.GetComponentInChildren<PlayerReceiver>();
        if (receiver != null) {
            this.Send(receiver);
        }
        SpawnController.DespawnItem(gameObject);
    }

    public void Send(PlayerReceiver receiver) {
        receiver.Deduct(this.damage);
        receiver.ReceivePoint(this.point);
    }
}
