using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject inventoryMenu;

    public List<Item> items;
    public GameObject[] slots;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();//OPTIONAL

    public ItemButton thisButton;//Keep Track of which Item Button We are mouse Hovering
    public ItemButton[] itemButtons;//ALL of ITEM BUTTONS in this game [Used for reset]

    public static InventoryManager instance;

    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("sing");
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject singleton = Instantiate(Resources.Load<GameObject>("InventoryCanvas"));
                    instance = singleton.GetComponent<InventoryManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            items = SaveLoadData.LoadInventory();

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        if (inventoryMenu != null)
        {
            inventoryMenu.SetActive(false);
        }
        DisplayItems();
    }


    public void Resume()
    {
        if (inventoryMenu != null)
        {
            inventoryMenu.SetActive(false);
        }
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Pause()
    {
        if (inventoryMenu != null)
        {
            inventoryMenu.SetActive(true);
        }
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    private void OnApplicationQuit()
    {
        SaveLoadData.SaveInventory(items);
    }

    private void DisplayItems()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = items[i].number.ToString();

                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //UPDATE slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //UPDATE slots Count Text
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //UPDATE CLOSE/THROW button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        bool itemExists = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (_item.itemName.Equals(items[i].itemName))
            {
                items[i].number++;
                itemExists = true;
                break;
            }
        }
        if (!itemExists)
        {
            items.Add(_item);
        }

        DisplayItems();
    }

    public void RemoveItem(Item _item)
    {
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (_item == items[i])
                {
                    items[i].number--;
                    if (items[i].number == 0)
                    {
                        items.Remove(_item);
                    }
                }
            }
        }
        else
        {
            Debug.Log("THERE IS NO " + _item + " in my Bags");
        }

        ResetButtonItems();
        DisplayItems();
    }

    public void ResetButtonItems()
    {
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (i < items.Count)
            {
                itemButtons[i].thisItem = items[i];
            }
            else
            {
                itemButtons[i].thisItem = null;
            }
        }
    }
}
