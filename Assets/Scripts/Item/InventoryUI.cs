using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform _inventoryBox = null;

    InventorySlot[] _inventorySlots = null;
    InventoryManager _inventoryManager = null;

    void Awake()
    {
        // �q�I�u�W�F�N�g�̃C���x���g���X���b�g��S�Ď擾����
        _inventorySlots = _inventoryBox.GetComponentsInChildren<InventorySlot>();
        _inventoryManager = transform.parent.parent.parent.parent.GetComponent<InventoryManager>();
    }

    void OnEnable()
    {
        if (_inventoryManager.InventoryCallBack == null)
        {
            _inventoryManager.InventoryCallBack += UIUpdate;
        }
    }

    void OnDisable()
    {
        if (_inventoryManager.InventoryCallBack == null)
        {
            _inventoryManager.InventoryCallBack -= UIUpdate;
        }
    }


    /// <summary>UI�̍X�V</summary>
    public void UIUpdate()
    {
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            if (i < DDOLController.instance.Inventory.ItemList.Count)
            {
                _inventorySlots[i].AddItemSlot(DDOLController.instance.Inventory.ItemList[i]);
            }
            else
            {
                _inventorySlots[i].RemoveItem();
            }
        }
    }
}
