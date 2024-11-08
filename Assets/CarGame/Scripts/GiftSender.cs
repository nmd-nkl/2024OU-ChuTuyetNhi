using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftSender : ItemSender
{
    public override void Send(PlayerReceiver receiver)
    {
        base.Send(receiver);
        ObjectPooler.Instance.Despawn(gameObject);
    }
}
