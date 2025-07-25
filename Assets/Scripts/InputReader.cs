using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnCubeClick;

    private void OnMouseDown()
    {
        OnCubeClick.Invoke();
    }
}