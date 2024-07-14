using UnityEngine;

public class Book : MonoBehaviour
{
    public int originalIndex;
    public Sprite detailImage; // Add a sprite for the detail image

    private void Start()
    {
        // Use the name of the GameObject as the name of the book
        string bookName = gameObject.name;
    }
}
