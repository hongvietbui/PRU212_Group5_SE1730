using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public bool isPaused;

    public List<Item> items;
    public GameObject[] slots;

  

    public ItemButton thisButton;
    public ItemButton[] itemButtons;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            items = SaveLoadData.LoadInventory();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnApplicationQuit()
    {
        SaveLoadData.SaveInventory(items);
    }

    private void Start()
    {
        DisplayItems();
    }

    private void DisplayItems()
    {
        //We IGNORE the fact
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
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
            else//Some Remove Items
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
        if(items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    items[i].number--;
                    if(items[i].number == 0)
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
        //IF There is no ITEM inside Inventory 

        ResetButtonItems();
        DisplayItems();
    }

    public void ResetButtonItems()
    {
        for(int i = 0; i < itemButtons.Length; i++)//FOR LOOP ALL OF BUTTONS. Total Number in this game is 21 slots
        {
            if(i < items.Count)
            {
                itemButtons[i].thisItem = items[i];//Once This button contains the Item, Assign the ITEM to "thisItem";
            }
            else
            {
                itemButtons[i].thisItem = null;//Otherwise, Set the "thisItem" to NULL!
            }
        }
    } 

}
