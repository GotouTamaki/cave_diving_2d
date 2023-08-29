using UnityEngine;

public class ItemBase : MonoBehaviour
{
    //　アイテムの情報
    [SerializeField] Item _item = default;
    //[SerializeField] int _itemNum = 0;

    //アイテムの取得の処理
    public void ItemGet()
    {
        InventoryManager.instance.AddItem(_item);
        Destroy(this.gameObject);
    }
}

