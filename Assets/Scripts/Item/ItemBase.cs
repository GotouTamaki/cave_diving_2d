using UnityEngine;

public class ItemBase : MonoBehaviour
{
    /// <summary>アイテムの番号</summary>
    [SerializeField] int _itemNum = 0;

    /// <summary>アイテムの取得の処理</summary>
    public void ItemGet()
    {
        //InventoryManager.instance.ItemNumber = _itemNum;
        DDOLController.instance.Inventory.AddItem(_itemNum);
        Destroy(this.gameObject);
    }
}

