using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>表示するアイコン</summary>
    Image _icon = null;

    /// <summary>アイテムスロットにアイテムを追加する</summary>　
    /// <param name="newitem">追加するアイテム</param>
    public void AddItemSlot(Item newitem)
    {
        _icon.sprite = newitem.Icon;
        _icon.enabled = true;
    }

    /// <summary>アイテムスロットからアイテムを削除する</summary>
    public void RemoveItem()
    {
        _icon.sprite = null;
        _icon.enabled = false;
    }
}
