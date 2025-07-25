using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class Exploder : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
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
        List<GameObject> cubes = _cubeSpawner.GetSpawnedCubes();

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