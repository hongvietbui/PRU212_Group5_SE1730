using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText; 
    public Button[] answerButtons; 
    public TextMeshProUGUI resultText; 
    public GameObject quizBackground; 
    public GameObject questionPanel; 
    public GameObject player; 
    public GameObject result; 
    public GameObject quiz; 
    public Button closeButton;
    public Item itemData;
    public UnityEvent OnGameStart;
    public UnityEvent OnPuzzelEnd;
    public GameObject Interact;
    public GameObject Square;
    public GameObject Square2;
    private string[] questions = new string[]
{
    "1. When you feel academic pressure, what should you do first?",
    "2. Which method helps improve concentration while studying?",
    "3. How to effectively manage study time?",
    "4. When you feel anxious about an upcoming exam, what should you do?",
    "5. What helps you stay optimistic when facing difficulties in studying?",
    "6. Why is proper rest important?",
    "7. What can help reduce stress immediately?",
    "8. What are the benefits of regular exercise for studying?",
    "9. How to create an effective study environment?",
    "10. When you feel overwhelmed with schoolwork, what should you do?"
};

    private string[][] answers = new string[][]
    {
    new string[] {"Rest and relax", "Keep studying non-stop", "Ignore and watch TV", "Go out with friends"},
    new string[] {"Listen to soft music", "Do multiple assignments at once", "Study continuously without a break", "Focus on one task at a time"},
    new string[] {"Create a detailed plan", "Study spontaneously", "Only study before exams", "Play games after each hour of study"},
    new string[] {"Discuss with friends", "Ignore and do something else", "Take a nap", "Practice deep breathing and meditation"},
    new string[] {"Reward yourself", "Criticize yourself", "Compare with others", "Do something else to forget"},
    new string[] {"Helps body and mind recover", "Reduces study time", "Unnecessary", "Slows down study progress"},
    new string[] {"Practice breathing exercises", "Keep working", "Listen to loud music", "Eat fast food"},
    new string[] {"Improves memory and concentration", "Reduces study time", "Wastes time", "No impact"},
    new string[] {"Keep it tidy, have adequate lighting", "Study in noisy places", "Study on the bed", "Study environment doesn't matter"},
    new string[] {"Break tasks into small steps", "Ignore everything", "Try to do everything at once", "Stop studying completely"}
    };

    private int[] correctAnswers = new int[] { 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 }; // Chỉ số của câu trả lời đúng
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        OnGameStart.Invoke();
        List<Item> items = InventoryManager.Instance.items;
        Debug.Log(items.Count);
        foreach (Item item in items)
        {
            if(item.itemName == itemData.itemName)
            {
                quiz.SetActive(false);
                Square2.gameObject.SetActive(false);
                Square.gameObject.SetActive(false);
            }
 
        }
        quizBackground.SetActive(false);
        questionPanel.SetActive(false);
        result.SetActive(false);
        foreach (var button in answerButtons)
        {
            button.onClick.AddListener(() => OnAnswerSelected(button));
        }
   
    }

    private void Update()
    {
        
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        quizBackground.SetActive(true);
        questionPanel.SetActive(true);
        ShowQuestion();
    }

    public void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex];
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[currentQuestionIndex][i];
            }
        }
        else
        {

            quizBackground.SetActive(false);
            questionPanel.SetActive(false);
            result.SetActive(true);
            
            resultText.text = "You answered " + score + " out of " + questions.Length + " questions correctly. You receive an A+ soul fragment";
            if (score >= 5)
            {
                resultText.text = "You answered " + score + " out of " + questions.Length + " questions correctly. You receive an A+ soul fragment";
                InventoryManager.Instance.AddItem(itemData);
                OnPuzzelEnd.Invoke();
                Interact.gameObject.SetActive(false);
                Square2.gameObject.SetActive(false);
                Square.gameObject.SetActive(false);
            }
            else
            {
                resultText.text = "You answered " + score + " out of " + questions.Length + " questions correctly. Try harder to get rewards";
            }
        }
    }

    public void OnAnswerSelected(Button button)
    {
        int index = System.Array.IndexOf(answerButtons, button);
        if (index == correctAnswers[currentQuestionIndex])
        {
            score++;
        }
        currentQuestionIndex++;
        ShowQuestion();
    }

    public void CloseResultText()
    {
        result.SetActive(false);
    }
}
