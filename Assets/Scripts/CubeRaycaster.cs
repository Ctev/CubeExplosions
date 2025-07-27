using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    // +Куб не должен подписываться на _inputReader.OnCubeClick.
    // Будет другой класс, который получает событие о нажатии, берет с нажатого объекта куб и отправляет его в событие - CubeRaycaster.
    // Других событий не будет.
    // На него подписан уже CubeSplitHander, который будет проверять шанс и вызывать спавнер и взрыватель.
    // +На кубе не должно висеть InputReader.
    // InputReader, CubeRaycaster, Спавнер и взрыватель на сцене в единственном экземпляре

    //private Cube _cube;
    private float _spawnChance;

    private static int SpawnCount = 0;

    public event Action<GameObject> Spawned;

    private void Awake()
    {
        //_cube = FindObjectOfType<Cube>();
        _spawnChance = 1 / Mathf.Pow(2, SpawnCount);
    }

    //private void OnEnable()
    //{
    //    _cube.OnClick += CubeSplitHander;
    //}

    //private void OnDisable()
    //{
    //    _cube.OnClick -= CubeSplitHander;
    //}

    public void CubeSplitHander(GameObject cube)
    {
        if (UnityEngine.Random.value <= _spawnChance)
        {
            Spawned.Invoke(cube);
            SpawnCount++;
        }

        Destroy(cube);
    }
}
