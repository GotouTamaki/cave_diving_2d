using UnityEngine;

public class ItemBase : MonoBehaviour
{
    /// <summary>�A�C�e���̔ԍ�</summary>
    [SerializeField] int _itemNum = 0;

    /// <summary>�A�C�e���̎擾�̏���</summary>
    public void ItemGet()
    {
        //InventoryManager.instance.ItemNumber = _itemNum;
        InventoryManager.instance.AddItem(_itemNum);
        Destroy(this.gameObject);
    }
}

