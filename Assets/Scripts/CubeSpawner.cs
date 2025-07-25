using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent (typeof(Cube))]
public class CubeSpawner : MonoBehaviour
{
    private Cube _cube;
    private List<GameObject> _spawnedCubes;

    public event Action Exploded;

    public List<GameObject> GetSpawnedCubes()
    {
        List<GameObject> spawnCubes = new List<GameObject>();

        foreach (GameObject spawnedCube in _spawnedCubes)
            spawnCubes.Add(spawnedCube);

        return spawnCubes;
    }

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _spawnedCubes = new List<GameObject>();
    }

    private void OnEnable()
    {
        _cube.Spawned += Spawn;
    }

    private void OnDisable()
    {
        _cube.Spawned -= Spawn;
    }

    private void Spawn()
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;
        int spawnCubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount + 1);

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.position = transform.position;
            cube.transform.localScale = transform.localScale / 2;

            cube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            cube.AddComponent<CubeSpawner>();
            cube.AddComponent<Exploder>();
            cube.AddComponent<Rigidbody>();

            _spawnedCubes.Add(cube);
        }

        Exploded.Invoke();
    }
}