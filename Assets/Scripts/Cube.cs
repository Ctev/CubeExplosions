using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    // Не надо искать объекты через FindObjectOfType. Это слишком затратная операция. И считается плохой практикой. 

    // К тому же кубу лучше не знать про рейкастер. Лучше пускай он через событие сообщает что на него нажали. 

    // Избавься от магических чисел в коде. 

    // Не надо через события передавать игровой объект. У тебя есть куб. 

    // Почему рейкастер считает шанс спавна? Это очень странно. Не его ответственность явно. 

    // Не нужно везде передавать игровые объекты у тебя есть куб. С ним и работай. 

    // За смену цвета должен отвечать отдельный компонент.ColorChanger.

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