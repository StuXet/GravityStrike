using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawnManager : MonoBehaviour
{
    public static ItemsSpawnManager Instance;

    SpawnPoint[] spawnPoints;

    private void Awake()
    {
        Instance = this;
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}