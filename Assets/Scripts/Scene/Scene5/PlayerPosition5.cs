using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition5 : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject completionObject; // Thêm biến này để giữ tham chiếu tới GameObject cần kích hoạt

    void Start()
    {
        if (PlayerPrefs.GetInt("PuzzleSolved", 0) == 1)
        {
            if (completionObject != null)
            {
                completionObject.SetActive(true); // Kích hoạt GameObject khi puzzle đã giải quyết
            }
        }
        else
        {
            if (completionObject != null)
            {
                completionObject.SetActive(false); // Đảm bảo GameObject này bị vô hiệu hóa nếu puzzle chưa được giải quyết
            }
        }

        playerTransform.position = PuzzleState.savedPosition;
    }
}
