using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private CubeRaycaster _raycaster;

    //public event Action OnClick;
    private void Awake()
    {
        _raycaster = FindObjectOfType<CubeRaycaster>();
    }
    
    public void OnMouseDown()
    {
        //OnClick.Invoke();

        _raycaster.CubeSplitHander(gameObject);
    }
}