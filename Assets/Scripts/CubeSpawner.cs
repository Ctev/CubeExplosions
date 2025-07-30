using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent (typeof(CubeSplitHander))]
public class CubeSpawner : MonoBehaviour
{
    private CubeSplitHander _cubeSplitHander;
    private List<GameObject> _spawnedCubes;

    public event Action Exploded;
    public event Action<Cube> ColorChanged;

    public List<GameObject> GetSpawnedCubes()
    {
        List<GameObject> spawnCubes = new List<GameObject>();

        foreach (GameObject spawnedCube in _spawnedCubes)
            spawnCubes.Add(spawnedCube);

        return spawnCubes;
    }

    private void Awake()
    {
        _cubeSplitHander = GetComponent<CubeSplitHander>();
        _spawnedCubes = new List<GameObject>();
    }

    private void OnEnable()
    {
        _cubeSplitHander.Splited += Spawn;
    }

    private void OnDisable()
    {
        _cubeSplitHander.Splited -= Spawn;
    }

    private void Spawn(Cube cube)
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;
        int spawnCubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount + 1);

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            spawnedCube.transform.position = cube.transform.position;
            spawnedCube.transform.localScale = cube.transform.localScale / 2;

            ColorChanged.Invoke(spawnedCube.GetComponent<Cube>());

            spawnedCube.AddComponent<Cube>();
            spawnedCube.AddComponent<Rigidbody>();

            _spawnedCubes.Add(spawnedCube);
        }

        Exploded.Invoke();
    }
}