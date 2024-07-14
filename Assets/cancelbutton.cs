using UnityEngine;

public class CancelButton : MonoBehaviour
{
    // Example: Assign this in the Unity Editor to the object you want to hide or cancel
    public GameObject objectToHide;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Example: Check for input to cancel/hide
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Call a method to handle cancellation
            HandleCancellation();
        }
    }

  public  void HandleCancellation()
    {
        // Example: Hide the object or perform cancellation logic
        if (objectToHide != null)
        {
            objectToHide.SetActive(false); // Hide the assigned GameObject
        }
    }
}
