using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private CubeRaycaster _raycaster;

    private void Awake()
    {
        _raycaster = FindObjectOfType<CubeRaycaster>();
    }
    
    public void OnMouseDown()
    {
        _raycaster.CubeSplitHander(gameObject);
    }
}