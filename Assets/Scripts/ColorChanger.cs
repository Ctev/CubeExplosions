using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeSpawner))]
public class ColorChanger : MonoBehaviour
{
    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _cubeSpawner = GetComponent<CubeSpawner>();
    }

    private void OnEnable()
    {
        _cubeSpawner.ColorChanged += Change;
    }

    private void OnDisable()
    {
        _cubeSpawner.ColorChanged -= Change;
    }

    private void Change(Cube cube)
    {
        cube.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}