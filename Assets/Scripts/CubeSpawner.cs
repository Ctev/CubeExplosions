using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent (typeof(InputReader))]
public class CubeSpawner : MonoBehaviour
{
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.Spawned += Spawn;
    }

    private void OnDisable()
    {
        _inputReader.Spawned -= Spawn;
    }

    private void Spawn()
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;
        int spawnCubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount + 1);

        List<GameObject> spawnCubes = new List<GameObject>();

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.position = transform.position;
            cube.transform.localScale = transform.localScale / 2;

            cube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            cube.AddComponent<CubeSpawner>();
            cube.AddComponent<Rigidbody>();

            spawnCubes.Add(cube);
        }

        Explode(spawnCubes);
    }

    private void Explode(List<GameObject> cubes)
    {
        float explosionForce = 10;
        float explosionRadius = 5;
        Vector3 explosionPosition = transform.position;

        foreach (GameObject cube in cubes)
        {
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();

            if (cubeRigidbody != null)
                cubeRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }
}
