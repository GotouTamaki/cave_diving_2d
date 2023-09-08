using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>表示するアイコン</summary>
    [SerializeField] Image _icon = null;

    /// <summary>アイテムスロットにアイテムを追加する</summary>　
    /// <param name="newItem">追加するアイテム</param>
    public void AddItemSlot(Item newItem)
    {
        Debug.Log("a");
        _icon.sprite = newItem.Icon;
        _icon.enabled = true;
    }

    /// <summary>アイテムスロットからアイテムを削除する</summary>
    public void RemoveItem()
    {
        //_icon.sprite = null;
        //throw new UnityException("インベントリスロットの実装漏れアリ");
        _icon.enabled = false;
    }
}
