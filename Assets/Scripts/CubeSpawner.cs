using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent (typeof(InputReader))]
public class CubeSpawner : MonoBehaviour
{
    //private int _minNewCubes;
    //private int _maxNewCubes;
    //private float _spawnChance ;  // ��������� ���� ���������� (100%)
    //private float _scaleReductionFactor; // ���������� �������� ����� �����
    //private float _explosionForce; // ���� ������
    //private float _explosionRadius; // ������ ������

    //private static int SpawnCount = 0; // ����������� ���������� ��� ������������ ���������

    //void OnMouseDown()
    //{
    //    float spawnChance = 1 / Mathf.Pow(2, SpawnCount);  // ���� ����������� � ������ ����������

    //    if (Random.value <= spawnChance)
    //        Spawn();

    //    Destroy(gameObject);
    //}

    //private List<GameObject> _spawnedCubes;

    //public event Action Exploded;

    //public List<GameObject> GetSpawnedCubes()
    //{
    //    List<GameObject> spawnCubes = new List<GameObject>();

    //    foreach (GameObject spawnedCube in _spawnedCubes)
    //        spawnCubes.Add(spawnedCube);

    //    return spawnCubes;
    //}
    
    //private InputReader _inputReader;

    //private void Awake()
    //{
    //    _inputReader = GetComponent<InputReader>();
    //}

    //private void Start()
    //{
    //    _inputReader = GetComponent<InputReader>();
    //}

    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        //_inputReader = GetComponent<InputReader>();
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
        //float scaleReductionFactor = 0.5f;

        List<GameObject> spawnCubes = new List<GameObject>();

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cube.transform.position = transform.position; // ����� ���� � ������� �������
            cube.transform.localScale = transform.localScale / 2;

            // ��������� ����

            cube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            //spawner._minNewCubes = _minNewCubes;
            //spawner._maxNewCubes = _maxNewCubes;
            //spawner._spawnChance = _spawnChance;  // �������� ��������� ����
            //spawner._scaleReductionFactor = _scaleReductionFactor;
            //spawner._explosionForce = _explosionForce;
            //spawner._explosionRadius = _explosionRadius;

            cube.AddComponent<CubeSpawner>();
            //cube.GetComponent<CubeSpawner>().InputReader = _inputReader;
            //cube.AddComponent<InputReader>();
            cube.AddComponent<Rigidbody>();

            spawnCubes.Add(cube);
        }

        //Exploded.Invoke();
        Explode(spawnCubes);
        //SpawnCount++; // ����������� ���������
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

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
