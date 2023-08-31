using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    InventoryManager inventoryManager = null;
    Item _item;
    Image _icon;

    private void Start()
    {
        inventoryManager = InventoryManager.instance;
    }

    public void AddItemSlot(Item newitem)
    {
        _item = newitem;
        _icon.sprite = newitem.Icon;
        _icon.enabled = true;
    }

    public void RemoveItem()
    {
        _item = null;
        _icon.sprite = null;
        _icon.enabled = false;
    }
}
