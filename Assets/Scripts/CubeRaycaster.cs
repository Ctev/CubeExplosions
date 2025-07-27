using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    private float _spawnChance;

    private static int SpawnCount = 0;

    public event Action<GameObject> Spawned;

    private void Awake()
    {
        _spawnChance = 1 / Mathf.Pow(2, SpawnCount);
    }

    public void CubeSplitHander(GameObject cube)
    {
        if (UnityEngine.Random.value <= _spawnChance)
        {
            Spawned.Invoke(cube);
            SpawnCount++;
        }

        Destroy(cube);
    }
}