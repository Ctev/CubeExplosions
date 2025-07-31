using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeSpawner), typeof(Exploder))]
public class CubeSplitHander : MonoBehaviour
{
    // +Куб не должен подписываться на _inputReader.OnCubeClick.
    // Будет другой класс, который получает событие о нажатии, берет с нажатого объекта куб и отправляет его в событие - CubeRaycaster.
    // Других событий не будет.
    // На него подписан уже CubeSplitHander, который будет проверять шанс и вызывать спавнер и взрыватель.
    // +На кубе не должно висеть InputReader.
    // InputReader, CubeRaycaster, Спавнер и взрыватель на сцене в единственном экземпляре

    // Почему рейкастер считает шанс спавна? Это очень странно. Не его ответственность явно. 
    private CubeSpawner _cubeSpawner;
    private Exploder _exploder;
    private float _spawnChance;
    private int _spawnChanceCount;

    private static int SpawnCount = 0;

    //public event Action<Cube> Splited;
    //public event Action Splited;
    
    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
        _exploder = GetComponent<Exploder>();
        _spawnChanceCount = 1;
        _spawnChance = _spawnChanceCount / Mathf.Pow(2, SpawnCount);
    }

    private void OnEnable()
    {
        InputReader.OnCubeClicked += Split;
    }

    private void OnDisable()
    {
        InputReader.OnCubeClicked -= Split;
    }

    public void Split(Cube cube)
    {
        if (Random.value <= _spawnChance)
        {
            _exploder.Explode(cube, _cubeSpawner.SpawnCubes(cube));
            //Splited.Invoke(cube);
            SpawnCount++;
        }

        Destroy(cube.gameObject);
    }
}