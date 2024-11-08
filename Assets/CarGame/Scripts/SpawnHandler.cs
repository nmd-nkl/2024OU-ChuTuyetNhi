using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public int itemTypeCnt = 0;
    public float respawnTime = 2f;
    public Transform[] spawnPoints;

    void Start()
    {
        itemTypeCnt = ObjectPooler.Instance.Pools.Count;
        StartCoroutine(HandleWaves());
    }

    IEnumerator HandleWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            List<Transform> spawnPos = new List<Transform>(spawnPoints);

            for (int i = 0; i < spawnPos.Count; i++)
            {
                int randomIdx = Random.Range(0, spawnPos.Count);
                Transform spawnPoint = spawnPos[randomIdx];
                spawnPos.RemoveAt(randomIdx);

                int randomType = Random.Range(0, itemTypeCnt);
                SpawnItem(randomType, spawnPoint.position);
            }

            yield return new WaitForSeconds(respawnTime);
        }
    }

    void SpawnItem(int itemId, Vector3 spawnPos)
    {
        switch (itemId)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("coin", spawnPos, Quaternion.identity);
                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("bomb", spawnPos, Quaternion.identity);
                break;
            default:
                Debug.Log("No Item Data!");
                break;
        }
    }
}
