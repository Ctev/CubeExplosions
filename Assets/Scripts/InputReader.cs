using System;

public static class InputReader
{
    public static event Action<Cube> OnCubeClicked;

    public static void HandleCubeClicked(Cube cube)
    {
        OnCubeClicked.Invoke(cube);
    }
}