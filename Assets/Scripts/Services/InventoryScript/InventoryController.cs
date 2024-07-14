using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private void Awake()
    {
        // Khởi tạo InventoryManager từ prefab nếu chưa tồn tại
        InventoryManager inventoryManager = InventoryManager.Instance;

        //if (inventoryManager.inventoryMenu == null)
        //{
        //    GameObject inventoryPrefab = Resources.Load<GameObject>("InventoryCanvas");
        //    if (inventoryPrefab != null)
        //    {
        //        Debug.Log("add");
        //        GameObject inventoryObject = Instantiate(inventoryPrefab);
        //        inventoryManager.inventoryMenu = inventoryObject;
        //    }
        //}
    }

    void Update()
    {
        // Kiểm tra và xử lý việc hiển thị Inventory thông qua InventoryManager
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            if (InventoryManager.Instance.isPaused)
            {
                InventoryManager.Instance.Resume();
            }
            else
            {
                InventoryManager.Instance.Pause();
            }
        }
    }
}
