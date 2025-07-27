using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent (typeof(CubeRaycaster))]
//[RequireComponent (typeof(Exploder))]
public class CubeSpawner : MonoBehaviour
{
    //private int _minNewCubes;
    //private int _maxNewCubes;
    //private float _spawnChance ;  // Начальный шанс разделения (100%)
    //private float _scaleReductionFactor; // Уменьшение масштаба новых кубов
    //private float _explosionForce; // Сила взрыва
    //private float _explosionRadius; // Радиус взрыва

    //private static int SpawnCount = 0; // Статическая переменная для отслеживания поколения

    //void OnMouseDown()
    //{
    //    float spawnChance = 1 / Mathf.Pow(2, SpawnCount);  // Шанс уменьшается с каждым поколением

    //    if (Random.value <= spawnChance)
    //        Spawn();

    //    Destroy(gameObject);
    //}

    //private List<GameObject> _spawnedCubes;



    //private InputReader _inputReader;

    //private void Awake()
    //{
    //    _inputReader = GetComponent<InputReader>();
    //}

    //private void Start()
    //{
    //    _inputReader = GetComponent<InputReader>();
    //}

    //private Exploder _exploder;
    //private List<GameObject> _spawnedCubes;
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

    //public List<GameObject> SpawnedCubes => _spawnedCubes;

    private void Awake()
    {
        _cubeRaycaster = GetComponent<CubeRaycaster>();
        //_exploder = GetComponent<Exploder>();
        _spawnedCubes = new List<GameObject>();
    }

    private void OnEnable()
    {
        //_inputReader = GetComponent<InputReader>();
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
        //float scaleReductionFactor = 0.5f;

        for (int i = 0; i < spawnCubesCount; i++)
        {
            GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            spawnedCube.transform.position = cube.transform.position; // Новые кубы в позиции старого
            spawnedCube.transform.localScale = cube.transform.localScale / 2;

            // Случайный цвет

            spawnedCube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

            //spawner._minNewCubes = _minNewCubes;
            //spawner._maxNewCubes = _maxNewCubes;
            //spawner._spawnChance = _spawnChance;  // Передаем начальный шанс
            //spawner._scaleReductionFactor = _scaleReductionFactor;
            //spawner._explosionForce = _explosionForce;
            //spawner._explosionRadius = _explosionRadius;

            //cube.GetComponent<CubeSpawner>().InputReader = _inputReader;
            //cube.AddComponent<InputReader>();
            //spawnedCube.AddComponent<CubeSpawner>();
            //spawnedCube.AddComponent<Exploder>();
            spawnedCube.AddComponent<Cube>();
            spawnedCube.AddComponent<Rigidbody>();

            _spawnedCubes.Add(spawnedCube);
        }

        Exploded.Invoke(cube);
        //Explode(spawnCubes);
        //SpawnCount++; // Увеличиваем поколение
    }

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}
