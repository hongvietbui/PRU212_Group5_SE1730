using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPos : MonoBehaviour
{
    public Transform playerTransform;
    public float mapCenterY;

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            // Lấy vị trí hiện tại của camera
            Vector3 newPosition = transform.position;
            // Cập nhật vị trí X của camera theo vị trí của nhân vật
            newPosition.x = playerTransform.position.x;
            // Giữ vị trí Y của camera là tâm bản đồ theo chiều dọc
            newPosition.y = mapCenterY;
            // Cập nhật vị trí của camera
            transform.position = newPosition;
        }
    }
}