using UnityEngine;
using System;
using System.Collections.Generic;

//[RequireComponent (typeof(CubeSplitHander))]
//[RequireComponent (typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
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
    //private CubeSplitHander _cubeSplitHander;
    private List<Cube> _spawnedCubes;
    private ColorChanger _colorChanger;

    //public event Action<Cube, List<Cube>> Spawned;

    //public List<GameObject> GetSpawnedCubes()
    //{
    //    List<GameObject> spawnCubes = new List<GameObject>();

    //    foreach (GameObject spawnedCube in _spawnedCubes)
    //        spawnCubes.Add(spawnedCube);

    //    return spawnCubes;
    //}

    //public List<GameObject> SpawnedCubes => _spawnedCubes;

    private void Awake()
    {
        //_cubeSplitHander = GetComponent<CubeSplitHander>();
        //_exploder = GetComponent<Exploder>();
        _spawnedCubes = new List<Cube>();
        _colorChanger = GetComponent<ColorChanger>();
    }

    public List<Cube> SpawnCubes(Cube cube)
    {
        int minCubesCount = 2;
        int maxCubesCount = 6;
        int spawnCubesCount = UnityEngine.Random.Range(minCubesCount, maxCubesCount + 1);
        float scaleReductionFactor = 0.5f;

        for (int i = 0; i < spawnCubesCount; i++)
        {

            //GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Cube spawnedCube = Instantiate(cube.gameObject, cube.transform.position, Quaternion.identity).AddComponent<Cube>();

            //spawnedCube.transform.position = cube.transform.position; // Новые кубы в позиции старого
            spawnedCube.gameObject.transform.localScale = cube.transform.localScale * scaleReductionFactor;

            // Случайный цвет

            // 9. GameObject spawnedCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // spawnedCube.AddComponent<Cube>(); - не усложняйте логику, создавайте из префаба.

            _colorChanger.Change(spawnedCube.gameObject.GetComponent<MeshRenderer>());
            //spawnedCube.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();

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

            //spawnedCube.AddComponent<Cube>();
            //spawnedCube.AddComponent<Rigidbody>();

            _spawnedCubes.Add(spawnedCube);
        }

        return _spawnedCubes;
        //Spawned.Invoke(cube, _spawnedCubes);
        //Explode(spawnCubes);
        //SpawnCount++; // Увеличиваем поколение
    }

    //private void Die()
    //{
    //    Destroy(gameObject);
    //}
}