using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject puzzleUI;
    public Animator storyAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerNearComputer())
        {
            ShowPuzzle();
        }
    }

    bool IsPlayerNearComputer()
    {
        // Add logic to check if player is near the computer
        return true;
    }

    void ShowPuzzle()
    {
        storyAnimator.Play("StoryAnimation");
    }

    public void OnStoryAnimationEnd()
    {
        puzzleUI.SetActive(true);
    }
}
