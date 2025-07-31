using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent(typeof(CubeSpawner))]
public class Exploder : MonoBehaviour
{
    //private CubeSpawner _cubeSpawner;

    //private void Awake()
    //{
    //    _cubeSpawner = GetComponent<CubeSpawner>();
    //}

    //private void OnEnable()
    //{
    //    _cubeSpawner.Spawned += Explode;
    //}

    //private void OnDisable()
    //{
    //    _cubeSpawner.Spawned -= Explode;
    //}

    public void Explode(Cube mainCube, List<Cube> spawnedCubes)
    {
        float explosionForce = 10;
        float explosionRadius = 5;
        Vector3 explosionPosition = mainCube.transform.position;

        foreach (Cube spawnedCube in spawnedCubes)
            if (spawnedCube.gameObject.TryGetComponent(out Rigidbody spawnedCubeRigidbody))
                spawnedCubeRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
    }
}
