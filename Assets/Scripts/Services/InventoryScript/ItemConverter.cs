using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ItemConverter
{
    public static ItemData ToItemData(Item item)
    {
        ItemData data = new ItemData();
        data.itemName = item.itemName;
        data.itemDes = item.itemDes;
        data.itemSpritePath = item.itemSprite != null ? AssetDatabase.GetAssetPath(item.itemSprite) : null;
        data.number = item.number;
        //data.itemPrice = item.itemPrice;
        return data;
    }

    public static Item ToItem(ItemData data)
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item.itemName = data.itemName;
        item.itemDes = data.itemDes;
        if (!string.IsNullOrEmpty(data.itemSpritePath))
        {
            item.itemSprite = AssetDatabase.LoadAssetAtPath<Sprite>(data.itemSpritePath);
        }
        item.number = data.number;
        //item.itemPrice = data.itemPrice;
        return item;
    }
}
