using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMiniCar
{


    public class SpawnObject : MonoBehaviour
    {

        [Header("Prefab")]

        public GameObject itemPrefab;
        public GameObject wallPrefab;
        public GameObject roadPrefab;

        private GameObject InstantiateObject(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            return Instantiate(prefab, position, rotation);
        }

        public void SpawnItem(ref List<GameObject> Lst, float speed = 5)
        {
            GameObject item = InstantiateObject(itemPrefab, new Vector2(Random.Range(-3, 3),  18), Quaternion.identity);
            Lst.Add(item);
            item.GetComponent<MovementBehaviour>().speed = speed;
        }

        public void SpawnRoad()
        {
            InstantiateObject(roadPrefab, new Vector3(0,  18, 0), Quaternion.identity);
        }
    }
}
