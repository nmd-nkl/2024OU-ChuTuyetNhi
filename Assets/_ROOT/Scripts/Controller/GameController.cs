using System.Collections;
using System.Collections.Generic;
using GameMiniCar;
using MJGame;
using UnityEngine;

public class GameController : SingletonComponent<GameController>
{
    public int score { get; set; } = 0;
    public int level { get; set; } = 1;
    public SpawnObject SpawnObject { get; private set; }
    public MapController MapController { get; private set; }

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        SpawnObject = GetComponent<SpawnObject>();
        if (MapController == null)
        {
            MapController = FindObjectOfType<MapController>();
        }
    }


    private bool CanResetLevel { get; set; } = false;
    
    public void AddScore()
    {
        score += 1;
        ActionGame.OnActionScore?.Invoke(score);
        if (score % 5 == 0)
        {
            NextLevel();
            CanResetLevel = true;
        }
    }

    public void CheckResetLevel()
    {
        if (CanResetLevel)
        {
            if (MapController.ItemInMap())
            {
                MapController.OnStopCoroutineItem();
            }
            else
            {
                MapController.OnStartCoroutineItem();
                CanResetLevel = false;
            }
        }
    }

    public void NextLevel()
    {
        level += 1;
        ActionGame.OnActionLevel?.Invoke(level);
    }

}
