using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : MonoBehaviour
{
    private Camera mainCamera;
    void Start() {
        this.mainCamera = Camera.main;
    }
    void Update() {
        if (!this.isInView()) {
            this.DespawnObj();
        }
    }
    bool isInView() {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
    public virtual void DespawnObj() {
        GameObject item = transform.gameObject;

        ObjectPooler.Instance.Despawn(item);
    }
}
