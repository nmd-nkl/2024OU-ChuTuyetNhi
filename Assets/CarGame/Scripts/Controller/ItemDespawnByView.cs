using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawnByView : MonoBehaviour {
    private Camera mainCamera;
    void Start() {
        this.mainCamera = Camera.main;
    }
    void Update() {
        if (!this.IsInView()) {
            SpawnController.DespawnItem(gameObject);
        }
    }
    private bool IsInView() {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }
}
