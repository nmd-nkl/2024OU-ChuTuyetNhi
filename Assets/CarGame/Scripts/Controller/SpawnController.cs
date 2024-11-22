using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    [SerializeField] float respawnTime = 2f;
    [SerializeField] Transform[] spawnPoints;
    public static List<GameObject> spawnedObjs = new List<GameObject>();
    private int itemTypeCount = 0;
    private Coroutine coroutineItem;

    private void Start() {
        this.itemTypeCount = ObjectPooler.Instance.Pools.Count;
        OnStartCoroutineItem();
    }

    public void OnStartCoroutineItem() {
        OnStartCoroutine(ref coroutineItem, IERandomSpawnItem());
    }

    public void OnStopCoroutineItem() {
        OnStopCoroutine(ref coroutineItem);
    }

    IEnumerator IERandomSpawnItem() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);

            List<Transform> spawnPos = new List<Transform>(spawnPoints);

            for (int i = 0; i < spawnPos.Count; i++) {
                //Random position
                int randomIdx = Random.Range(0, spawnPos.Count);
                Transform spawnPoint = spawnPos[randomIdx];
                spawnPos.RemoveAt(randomIdx);
                //Random Item Type
                int randomType = Random.Range(0, itemTypeCount);
                GameObject spawnedObj = this.SpawnItemByType(randomType, spawnPoint.position);
                if (spawnedObj != null) {
                    spawnedObjs.Add(spawnedObj);
                }
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }
    private void OnStartCoroutine(ref Coroutine coroutine, IEnumerator ienumerator) {
        if (coroutine != null) {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ienumerator);
    }
    private void OnStopCoroutine(ref Coroutine coroutine) {
        if (coroutine != null) {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    GameObject SpawnItemByType(int itemId, Vector3 spawnPos) {
        switch (itemId) {
            case 0:
                return ObjectPooler.Instance.SpawnFromPool(ConstCarGame.TAG_COIN, spawnPos, Quaternion.identity);  
            case 1:
                return ObjectPooler.Instance.SpawnFromPool(ConstCarGame.TAG_BOMB, spawnPos, Quaternion.identity);
            default:
                Debug.Log("No Item Data!");
                return null;
        }
    }
    public static void DespawnItem(GameObject gameObject) {
        ObjectPooler.Instance.Despawn(gameObject);
        spawnedObjs.Remove(gameObject);
    }

    public bool IsItemsOnMap() {
        return spawnedObjs.Count > 0;
    }
}
