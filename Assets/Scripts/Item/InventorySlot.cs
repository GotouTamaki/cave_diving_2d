using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item _item = null;
    Image _icon = null;

    public void AddItem(Item newitem)
    {
        _item = newitem;
        _icon = newitem.Icon;
    }

    public void RemoveItem()
    {
        _item = null;
        _icon = null;
    }
}
