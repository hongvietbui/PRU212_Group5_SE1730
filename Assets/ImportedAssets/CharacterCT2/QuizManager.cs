using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText; // Text để hiển thị câu hỏi
    public Button[] answerButtons; // Các nút để hiển thị câu trả lời
    public TextMeshProUGUI resultText; // Text để hiển thị kết quả cuối cùng
    public GameObject questionPanel; 
    public GameObject result; 
    public Button closeButton;

    private string[] questions = new string[]
    {
        "1. Khi bạn cảm thấy áp lực học tập, bạn nên làm gì đầu tiên?",
        "2. Phương pháp nào giúp cải thiện sự tập trung khi học?",
        "3. Làm thế nào để quản lý thời gian học tập hiệu quả?",
        "4. Khi bạn cảm thấy lo lắng về kỳ thi sắp tới, bạn nên làm gì?",
        "5. Điều gì giúp bạn giữ tinh thần lạc quan khi gặp khó khăn trong học tập?",
        "6. Tại sao nghỉ ngơi đúng cách lại quan trọng?",
        "7. Cách nào giúp giảm căng thẳng ngay lập tức?",
        "8. Lợi ích của việc tập thể dục đều đặn đối với việc học tập là gì?",
        "9. Làm thế nào để tạo môi trường học tập hiệu quả?",
        "10. Khi bạn cảm thấy quá tải với bài vở, bạn nên làm gì?"
    };

    private string[][] answers = new string[][]
    {
        new string[] {"Nghỉ ngơi và thư giãn", "Tiếp tục học không ngừng", "Bỏ qua và xem TV", "Đi chơi với bạn bè"},
        new string[] {"Nghe nhạc nhẹ", "Làm nhiều bài tập cùng lúc", "Học liên tục không nghỉ", "Tập trung vào một nhiệm vụ một lúc"},
        new string[] {"Lập kế hoạch chi tiết", "Học tùy hứng", "Chỉ học trước khi thi", "Chơi game sau mỗi giờ học"},
        new string[] {"Thảo luận với bạn bè", "Bỏ qua và làm việc khác", "Ngủ một giấc", "Luyện tập thở sâu và thiền"},
        new string[] {"Tự thưởng cho bản thân", "Phê bình bản thân", "So sánh với người khác", "Làm việc khác để quên đi"},
        new string[] {"Giúp cơ thể và tinh thần phục hồi", "Làm giảm thời gian học", "Không cần thiết", "Làm chậm tiến độ học"},
        new string[] {"Thực hiện bài tập thở", "Tiếp tục làm việc", "Nghe nhạc lớn", "Ăn thức ăn nhanh"},
        new string[] {"Tăng cường trí nhớ và sự tập trung", "Giảm thời gian học", "Làm mất thời gian", "Không ảnh hưởng gì"},
        new string[] {"Sắp xếp gọn gàng, có đủ ánh sáng", "Học ở nơi ồn ào", "Học trên giường", "Không quan trọng nơi học"},
        new string[] {"Chia nhỏ công việc và làm từng bước", "Bỏ qua tất cả", "Cố gắng làm tất cả cùng lúc", "Ngừng học hoàn toàn"}
    };

    private int[] correctAnswers = new int[] { 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 }; // Chỉ số của câu trả lời đúng
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        questionPanel.SetActive(false);
        result.SetActive(false);
        foreach (var button in answerButtons)
        {
            button.onClick.AddListener(() => OnAnswerSelected(button));
        }
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
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
            questionPanel.SetActive(false);
            result.SetActive(true);
            resultText.text = "Bạn đã trả lời đúng " + score + " trên " + questions.Length + " câu.";
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
