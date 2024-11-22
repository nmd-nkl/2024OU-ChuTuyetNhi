using System;
using System.Collections;
using System.Collections.Generic;
using GameMiniCar;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> LstItemSpawn = new();
    public DataObjectMovement ItemData;
    public DataObjectMovement WallData;
    public DataObjectMovement RoadData;
    public SpawnObject SpawnObject { get; private set; }
    public Coroutine coroutineItem;
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (SpawnObject == null)
        {
            SpawnObject = FindObjectOfType<SpawnObject>();
        }
        OnStartCoroutineItem();
    }


    #region  Speed

    public void SetSpeedItem(float speed)
    {
        ItemData.speed = speed;
    }

    #endregion

    #region Coroutine
    public void OnStartCoroutineItem()
    {
        OnStartCoroutine(ref coroutineItem, IESpawnItem());
    }

    public void OnStopCoroutineItem()
    {
        OnStopCoroutine(ref coroutineItem);
    }

    IEnumerator IESpawnItem()
    {
        SpawnObject.SpawnItem(ref LstItemSpawn, ItemData.speed);
        yield return new WaitForSeconds(ItemData.time);
        OnStartCoroutine(ref coroutineItem, IESpawnItem());
    }

    #endregion

    #region RemoveObject

    public void RemoveItem(GameObject gameObject)
    {
        RemoveObject(LstItemSpawn, gameObject);
    }

    #endregion

    #region ObjectInMap

    public bool ItemInMap()
    {
        return ObjectInMap(LstItemSpawn) > 0;
    }
    #endregion


    #region Base


    /// <summary>
    /// Ham de remove object trong list
    /// </summary>
    /// <param name="Lst"></param>
    /// <param name="gameObject"></param>
    private void RemoveObject(List<GameObject> Lst, GameObject gameObject)
    {
        Lst.Remove(gameObject);
        Destroy(gameObject);
    }


    /// <summary>
    /// Ham de check so luong object trong list
    /// </summary>
    /// <param name="LstItemSpawn"></param>
    /// <returns></returns>
    private int ObjectInMap(List<GameObject> LstItemSpawn)
    {
        return LstItemSpawn.Count;
    }


    /// <summary>
    /// Ham de start coroutine
    /// </summary>
    /// <param name="coroutine">ref tham chieu</param>
    /// <param name="ienumerator"></param>
    private void OnStartCoroutine(ref Coroutine coroutine, IEnumerator ienumerator)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(ienumerator);
    }


    /// <summary>
    /// Ham de stop coroutine
    /// </summary>
    /// <param name="coroutine">ref tham chieu</param>
    private void OnStopCoroutine(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
    #endregion
}


[Serializable]
public class DataObjectMovement
{
    public float speed = 5;
    public float time = 2;
}
