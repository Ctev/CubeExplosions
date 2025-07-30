using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class Exploder : MonoBehaviour
{
    private Cube _cube;
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void OnEnable()
    {
        _cubeSpawner.Exploded += Explode;
    }

    private void OnDisable()
    {
        _cubeSpawner.Exploded -= Explode;
    }

    private void Explode()
    {
        List<GameObject> spawnedCubes = _cubeSpawner.GetSpawnedCubes();

        float explosionForce = 10;
        float explosionRadius = 5;
        Vector3 explosionPosition = _cube.transform.position;

        foreach (GameObject spawnedCube in spawnedCubes)
        {
            Rigidbody SpawnedCubeRigidbody = spawnedCube.GetComponent<Rigidbody>();

            if (SpawnedCubeRigidbody != null)
                SpawnedCubeRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }
}