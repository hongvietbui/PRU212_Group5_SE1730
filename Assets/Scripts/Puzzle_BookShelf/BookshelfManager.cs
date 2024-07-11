using UnityEngine;
using System.Collections.Generic;

public class BookshelfManager : MonoBehaviour
{
    public List<GameObject> books;
    public Transform[] bookPositions;

    private GameObject selectedBook;

    private void Start()
    {
        ShuffleBooks();
        PlaceBooks();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBook();
        }
    }

    private void ShuffleBooks()
    {
        for (int i = 0; i < books.Count; i++)
        {
            GameObject temp = books[i];
            int randomIndex = Random.Range(0, books.Count);
            books[i] = books[randomIndex];
            books[randomIndex] = temp;
            Debug.Log("Shuffled book: " + temp.name);
        }
    }

    private void PlaceBooks()
    {
        for (int i = 0; i < books.Count; i++)
        {
            Vector3 position = bookPositions[i].position;
            position.z = 0; // Ensure books are placed at z = 0 in a 2D setup

            books[i].transform.position = position;
            books[i].GetComponent<Book>().originalIndex = i;
            Debug.Log("Book " + books[i].name + " placed at: " + books[i].transform.position);
        }
    }

    private void SelectBook()
    {
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedBook = hit.collider.gameObject;

            if (clickedBook != null && clickedBook.GetComponent<Book>() != null)
            {
                Debug.Log("Clicked book: " + clickedBook.name);
                if (selectedBook == null)
                {
                    selectedBook = clickedBook;
                }
                else
                {
                    SwapBooks(selectedBook, clickedBook);
                    selectedBook = null;
                    CheckForCompletion();
                }
            }
        }
    }

    private void SwapBooks(GameObject book1, GameObject book2)
    {
        int index1 = book1.GetComponent<Book>().originalIndex;
        int index2 = book2.GetComponent<Book>().originalIndex;

        // Save initial positions
        Vector3 tempPosition = book1.transform.position;
        int tempIndex = index1;

        // Swap positions
        book1.transform.position = bookPositions[index2].position;
        book2.transform.position = bookPositions[index1].position;

        // Update the books array
        books[index1] = book2;
        books[index2] = book1;

        // Update original indices
        book1.GetComponent<Book>().originalIndex = index2;
        book2.GetComponent<Book>().originalIndex = tempIndex;

        Debug.Log("Swapped " + book1.name + " with " + book2.name);

        // Debug to check positions and indices after swapping
        Debug.Log(book1.name + " is now at position: " + book1.transform.position + " with index: " + book1.GetComponent<Book>().originalIndex);
        Debug.Log(book2.name + " is now at position: " + book2.transform.position + " with index: " + book2.GetComponent<Book>().originalIndex);
    }

    private void CheckForCompletion()
    {
        string correctOrder = "fptuniversity";
        string currentOrder = "";

        for (int i = 0; i < books.Count; i++)
        {
            currentOrder += books[i].name[0];
        }

        if (currentOrder == correctOrder)
        {
            DisplayCompletionMessage();
        }
    }

    private void DisplayCompletionMessage()
    {
        Debug.Log("You have solved the puzzle!");
    }
}
