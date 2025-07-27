using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent (typeof(CubeRaycaster))]
public class CubeSpawner : MonoBehaviour
{
    private CubeRaycaster _cubeRaycaster;
    private List<GameObject> _spawnedCubes;

    public event Action<GameObject> Exploded;

    public List<GameObject> GetSpawnedCubes()
    {
        List<GameObject> spawnCubes = new List<GameObject>();

        foreach (GameObject spawnedCube in _spawnedCubes)
            spawnCubes.Add(spawnedCube);

        return spawnCubes;
    }

    private void Awake()
    {
        _cubeRaycaster = GetComponent<CubeRaycaster>();
        _spawnedCubes = new List<GameObject>();
    }

    private void OnEnable()
    {
        _cubeRaycaster.Spawned += Spawn;
    }

    private void OnDisable()
    {
        _cubeRaycaster.Spawned -= Spawn;
    }

    private void Spawn(GameObject cube)
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;
        int spawnCubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount + 1);

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            spawnedCube.transform.position = cube.transform.position;
            spawnedCube.transform.localScale = cube.transform.localScale / 2;

            spawnedCube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            spawnedCube.AddComponent<Cube>();
            spawnedCube.AddComponent<Rigidbody>();

            _spawnedCubes.Add(spawnedCube);
        }

        Exploded.Invoke(cube);
    }
}
