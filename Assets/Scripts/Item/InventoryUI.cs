using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform _inventoryBox = null;

    InventorySlot[] _inventorySlots = null;

    void Start()
    {
        _inventorySlots = _inventoryBox.GetComponentsInChildren<InventorySlot>();      
    }

    public void UIUpdate()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (i < InventoryManager.instance.ItemList.Count)
            {
                _inventorySlots[i].AddItem(InventoryManager.instance.ItemList[i]);
            }
            else
            {
                _inventorySlots[i].RemoveItem();
            }
        }
    }
}
