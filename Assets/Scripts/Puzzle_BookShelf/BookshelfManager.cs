using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class BookshelfManager : MonoBehaviour
{
    public Item ItemBook;
    public List<GameObject> books;
    public Transform[] bookPositions;

    public GameObject detailImagePanel;
    public Image detailImageRenderer;
    public Button closeButton;
    public TextMeshProUGUI correctBooksText;
    public GameObject congratulationsImage; // Add this for displaying congratulations image

    private GameObject selectedBook;

    private void Start()
    {
        ShuffleBooks();
        PlaceBooks();
        detailImagePanel.SetActive(false);
        congratulationsImage.SetActive(false);
        UpdateCorrectBooksText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBook();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ShowDetailImage();
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
            position.z = 0;
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

    private void ShowDetailImage()
    {
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject clickedBook = hit.collider.gameObject;

            if (clickedBook != null && clickedBook.GetComponent<Book>() != null)
            {
                if (detailImagePanel != null && detailImageRenderer != null)
                {
                    detailImagePanel.SetActive(true);
                    detailImageRenderer.sprite = clickedBook.GetComponent<Book>().detailImage;
                    detailImageRenderer.transform.SetAsLastSibling();
                }
                else
                {
                    Debug.LogWarning("Detail Image Panel or Detail Image Renderer is not assigned in the inspector.");
                }
            }
        }
        else
        {
            Debug.LogWarning("No collider found under the mouse position.");
        }
    }

    public void HideDetailImage()
    {
        detailImagePanel.SetActive(false);
    }

    private void SwapBooks(GameObject book1, GameObject book2)
    {
        int index1 = book1.GetComponent<Book>().originalIndex;
        int index2 = book2.GetComponent<Book>().originalIndex;

        Vector3 tempPosition = book1.transform.position;
        int tempIndex = index1;

        book1.transform.position = bookPositions[index2].position;
        book2.transform.position = bookPositions[index1].position;

        books[index1] = book2;
        books[index2] = book1;

        book1.GetComponent<Book>().originalIndex = index2;
        book2.GetComponent<Book>().originalIndex = tempIndex;

        Debug.Log("Swapped " + book1.name + " with " + book2.name);

        Debug.Log(book1.name + " is now at position: " + book1.transform.position + " with index: " + book1.GetComponent<Book>().originalIndex);
        Debug.Log(book2.name + " is now at position: " + book2.transform.position + " with index: " + book2.GetComponent<Book>().originalIndex);

        UpdateCorrectBooksText();
    }

    private void CheckForCompletion()
    {
        string correctOrder = "fptuniversity";
        bool isCorrect = true;

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].name[0].ToString().ToLower() != correctOrder[i].ToString().ToLower())
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            StartCoroutine(DisplayCompletionAndLoadScene());
        }
    }

    private IEnumerator DisplayCompletionAndLoadScene()
    {
        congratulationsImage.SetActive(true); // Show congratulations image
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        InventoryManager.Instance.AddItem(ItemBook); // Add the book to the inventory
        SceneManager.LoadScene("Thu vien"); // Load scene "AAA"
    }

    private void UpdateCorrectBooksText()
    {
        string correctOrder = "fptuniversity";
        int correctBooks = 0;

        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].name[0].ToString().ToLower() == correctOrder[i].ToString().ToLower())
            {
                correctBooks++;
            }
        }

        if (correctBooksText != null)
        {
            correctBooksText.text = "Correct Books: " + correctBooks;
        }
        else
        {
            Debug.LogWarning("Correct Books Text is not assigned in the inspector.");
        }
    }
}
