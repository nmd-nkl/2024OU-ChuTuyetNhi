using UnityEngine;

public class MapScroller : MonoBehaviour {
    public float scrollSpeed = 0.5f;
    private Renderer bgRenderer;

    void Start() {
        bgRenderer = GetComponent<Renderer>();
    }

    void Update() {
        bgRenderer.material.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
