using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform _inventoryBox = null;

    InventorySlot[] _inventorySlots = null;
    InventoryManager inventoryManager = null;

    void Start()
    {
        _inventorySlots = _inventoryBox.GetComponentsInChildren<InventorySlot>();
        inventoryManager = InventoryManager.instance;
        UIUpdate();
        inventoryManager.InventoryCallBack += UIUpdate;
    }

    void UIUpdate()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (i < InventoryManager.instance.ItemList.Count)
            {
                _inventorySlots[i].AddItemSlot(InventoryManager.instance.ItemList[i]);
            }
            else
            {
                _inventorySlots[i].RemoveItem();
            }
        }
    }
}
