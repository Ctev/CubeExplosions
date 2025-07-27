using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeRaycaster : MonoBehaviour
{
    // +��� �� ������ ������������� �� _inputReader.OnCubeClick.
    // ����� ������ �����, ������� �������� ������� � �������, ����� � �������� ������� ��� � ���������� ��� � ������� - CubeRaycaster.
    // ������ ������� �� �����.
    // �� ���� �������� ��� CubeSplitHander, ������� ����� ��������� ���� � �������� ������� � ����������.
    // +�� ���� �� ������ ������ InputReader.
    // InputReader, CubeRaycaster, ������� � ���������� �� ����� � ������������ ����������

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
