using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    // アイテムの種類
    [SerializeField] KindOfItem _kindOfItem;
    public KindOfItem GetKindOfItem => _kindOfItem;
    // アイテムのアイコン
    [SerializeField] Sprite _icon;
    public Sprite Icon => _icon;
    // アイテムの名前
    [SerializeField] string _itemName;
    public string ItemName => _itemName;
    // アイテムの情報
    [SerializeField] string _information;
    public string Information => _information;

    public enum KindOfItem
    {
        Weapon,
        UseItem
    }
}
