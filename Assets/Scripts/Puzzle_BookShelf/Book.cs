using UnityEngine;

public class Book : MonoBehaviour
{
    public int originalIndex;

    private void Start()
    {
        // Sử dụng tên của GameObject làm tên sách
        string bookName = gameObject.name;
    }
}
