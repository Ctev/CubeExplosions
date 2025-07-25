using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private float _spawnChance;

    private static int SpawnCount = 0;

    public event Action Spawned;

    private void Start()
    {
        _spawnChance = 1 / Mathf.Pow(2, SpawnCount);
    }

    void OnMouseDown()
    {
        if (UnityEngine.Random.value <= _spawnChance)
        {
            Spawned.Invoke();
            SpawnCount++;
        }

        Destroy(gameObject);
    }
}
