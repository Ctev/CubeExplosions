using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Cube : MonoBehaviour
{
    private InputReader _inputReader;
    private float _spawnChance;

    private static int SpawnCount = 0;

    public event Action Spawned;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _spawnChance = 1 / Mathf.Pow(2, SpawnCount);
    }
    
    private void OnEnable()
    {
        _inputReader.OnCubeClick += ChangeCube;
    }

    private void OnDisable()
    {
        _inputReader.OnCubeClick -= ChangeCube;
    }

    private void ChangeCube()
    {
        if (UnityEngine.Random.value <= _spawnChance)
        {
            Spawned.Invoke();
            SpawnCount++;
        }

        Destroy(gameObject);
    }
}