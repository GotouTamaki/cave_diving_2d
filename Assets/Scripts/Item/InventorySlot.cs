using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>表示するアイコン</summary>
    [SerializeField] Image _icon = null;
    /// <summary>空のアイコンの色</summary>
    [SerializeField] Color _iconColor = Color.white;
    /// <summary>アイコンにマウスカーソルが重なった時の色</summary>
    [SerializeField] Color _iconSelectColor = Color.white;
    /// <summary>InformationTextの設定</summary>
    [SerializeField] Text _infoText = null;

    // 各種初期化
    Item _item = null;
    Color _beforeColor = Color.white;

    /// <summary>アイテムスロットにアイテムを追加する</summary>
    /// <param name="newItem">追加するアイテム</param>
    public void AddItemSlot(Item newItem)
    {
        Debug.Log("a");
        _item = newItem;
        _icon.sprite = newItem.Icon;
        // アイコンが変色してしまうため白にする
        _icon.color = Color.white;
        //_icon.enabled = true;
    }

    /// <summary>アイテムスロットからアイテムを削除する</summary>
    public void RemoveItem()
    {
        //throw new UnityException("インベントリスロットの実装漏れアリ");
        // 空のアイコンにする
        _icon.sprite = InventoryManager.instance.InventoryData.ItemLists[0].Icon;
        // 白から元に戻す
        _icon.color = _iconColor;
        //_icon.enabled = true;
    }

    /// <summary>アイコンにマウスカーソルが重なった時の処理</summary>
    public void IconPointeEnter()
    {
        // 変更前の色を保存する
        _beforeColor = _icon.color;
        _icon.color = _iconSelectColor;
    }

    /// <summary>アイコンからマウスカーソルが離れた時の処理</summary>
    public void IconPointeExit()
    {
        // 色を元に戻す
        _icon.color = _beforeColor;
    }

    /// <summary>InformationPanelに表示する処理</summary>
    public void DisplayInfo()
    {
        if(_item != null)
        {
            _infoText.text = _item.Information;
        }
        else
        {
            _infoText.text = string.Empty;
        }
    }
}
