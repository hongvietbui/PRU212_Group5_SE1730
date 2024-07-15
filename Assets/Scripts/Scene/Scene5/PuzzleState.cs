using UnityEngine;

public static class PuzzleState
{
    public static bool isPuzzleSolved = false;
    public static Vector3 savedPosition;
    public static Vector3 initialPosition; // Thêm biến này để lưu vị trí ban đầu của nhân vật

    public static void SaveInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }

    public static Vector3 GetInitialPosition()
    {
        return initialPosition;
    }
}
