using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private static InventoryController _instance;
    public static InventoryController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<InventoryController>();
                    singletonObject.name = typeof(InventoryController).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

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