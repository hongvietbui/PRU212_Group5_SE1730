using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class End_PuzzleScript : MonoBehaviour
{
    public Item innerSoul;
    public GameObject player;

    public UnityEvent theThinkerEventStartByLoading;
    public UnityEvent bookEventStartByLoading;
    // Start is called before the first frame update
    void Start()
    {
        var items = InventoryManager.Instance.items;
        foreach(var item in items)
        {
            if (item.itemName == "The Thinker") {
                theThinkerEventStartByLoading.Invoke();
                continue;
            }

            if (item.itemName == "Book") {
                bookEventStartByLoading.Invoke(); 
                continue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveInnerSoul() {
        InventoryManager.Instance.AddItem(innerSoul);
        SaveLoadData.SavePlayerPosition(player.transform.position);
    }
}
