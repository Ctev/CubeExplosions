using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    // �� ���� ������ ������� ����� FindObjectOfType. ��� ������� ��������� ��������. � ��������� ������ ���������. 

    // � ���� �� ���� ����� �� ����� ��� ���������. ����� ������ �� ����� ������� �������� ��� �� ���� ������. 

    // �������� �� ���������� ����� � ����. 

    // �� ���� ����� ������� ���������� ������� ������. � ���� ���� ���. 

    // ������ ��������� ������� ���� ������? ��� ����� �������. �� ��� ��������������� ����. 

    // �� ����� ����� ���������� ������� ������� � ���� ���� ���. � ��� � �������. 

    // �� ����� ����� ������ �������� ��������� ���������.ColorChanger.

    //private CubeSplitHander _raycaster;

    //private void Awake()
    //{
    //    _raycaster = FindObjectOfType<CubeSplitHander>();
    //}

    public void OnMouseDown()
    {
        InputReader.HandleCubeClicked(gameObject.GetComponent<Cube>());

        //_raycaster.Split(gameObject);
    }
}