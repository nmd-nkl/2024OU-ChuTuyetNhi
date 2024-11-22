using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    #region singleton
    public static ObjectPooler Instance;
    private void Awake() {
        Instance = this;
    }
    #endregion
    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
        public Sprite sprite;
    }
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> Pools;
    [SerializeField] Transform Holder;
    private void Start() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in Pools) {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab, Holder);

                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Tag not exit: " + tag);
            return null;
        }

        GameObject objToSpawn = poolDictionary[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        return objToSpawn;
    }

    public void Despawn(GameObject obj) {
        if (!poolDictionary.ContainsKey(obj.tag)) {
            Debug.LogWarning("Tag not exit: " + obj.tag);
            return;
        }

        obj.SetActive(false);
        poolDictionary[obj.tag].Enqueue(obj);
    }
}
