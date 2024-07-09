using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public Tooltips tooltip;
    private Vector2 position;

    //HELPER FUNCTION to get the items on this button
    private Item GetThisItem()
    {
        for(int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if(buttonID == i)
            {
                thisItem = InventoryManager.instance.items[i];
            }
        }

        return thisItem;
    }

    public void CloseButton()
    {
        InventoryManager.instance.RemoveItem(GetThisItem());

        //Once we press the colse button, We have to Update the current thisItem
        //thisItem = GetThisItem();
        //if (thisItem != null)
        //{
        //    //SHOW TOOLTIP
        //    tooltip.ShowTooltip();

        //    tooltip.UpdateTooltip(GetDetailText(thisItem));
        //    RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
        //    tooltip.SetPosition(position);
        //}
        //else
        //{
        //    //HIDE TOOLTIP
        //    tooltip.HideTooltip();
        //    tooltip.UpdateTooltip("");//CLEAR
        //}
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();

        if(thisItem != null)
        {
            Debug.Log("ENTER " + thisItem.itemName + " SLOT");

            tooltip.ShowTooltip();

            tooltip.UpdateTooltip(GetDetailText(thisItem));
            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Canvas").transform as RectTransform, Input.mousePosition, null, out position);
            tooltip.SetPosition(position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //if(thisItem != null)
        //{
            //Debug.Log("EXIT " + thisItem.itemName + " SLOT");

            tooltip.HideTooltip();
            tooltip.UpdateTooltip("");//CLEAR
        //}
    }

    //HELPER FUNCTION TO GET A SERIES OF WORDS/INFORMATION/SENTENCE
    private string GetDetailText(Item _item)
    {
        if(_item == null)
        {
            return "";
        }
        else
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<color=black><size=22>Item: </size></color> <color=orange><size=15>{0}</size></color>\n\n", _item.itemName);
            stringBuilder.AppendFormat("<color=black><size=22>Description:</size> <size=12><color=grey>{0   }</color></size></color>\n\n", _item.itemDes);
            return stringBuilder.ToString();
        }
    }
}
