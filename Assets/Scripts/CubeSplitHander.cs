using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeSplitHander : MonoBehaviour
{
    private Cube _cube;
    private float _spawnChance;
    private int _spawnChanceCount;

    private static int SpawnCount = 0;

    public event Action<Cube> Splited;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _spawnChanceCount = 1;
        _spawnChance = _spawnChanceCount / Mathf.Pow(2, SpawnCount);
    }

    private void OnEnable()
    {
        _cube.OnClick += Split;
    }

    private void OnDisable()
    {
        _cube.OnClick -= Split;
    }

    public void Split()
    {
        if (UnityEngine.Random.value <= _spawnChance)
        {
            Splited.Invoke(_cube);
            SpawnCount++;
        }

        Destroy(_cube);
    }
}