using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform _inventoryBox = null;
    
    InventorySlot[] _inventorySlots = null;
    InventoryManager _inventoryManager = null;

    void Start()
    {
        // �q�I�u�W�F�N�g�̃C���x���g���X���b�g��S�Ď擾����
        _inventorySlots = _inventoryBox.GetComponentsInChildren<InventorySlot>();
        _inventoryManager = InventoryManager.instance;
        _inventoryManager.InventoryCallBack += UIUpdate;
    }

    /// <summary>UI�̍X�V</summary>
    public void UIUpdate()
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
