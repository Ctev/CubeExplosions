using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action OnClick;
    
    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}