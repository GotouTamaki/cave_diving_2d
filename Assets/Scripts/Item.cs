using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    //　アイテムの種類
    [SerializeField] KindOfItem _kindOfItem;
    //　アイテムのアイコン
    [SerializeField] Sprite _icon;
    //　アイテムの名前
    [SerializeField] string _itemName;
    //　アイテムの情報
    [SerializeField] string _information;

    public enum KindOfItem
    {
        Weapon,
        UseItem
    }

    public KindOfItem GetKindOfItem()
    {
        return _kindOfItem;
    }

    public Sprite GetIcon()
    {
        return _icon;
    }

    public string GetItemName()
    {
        return _itemName;
    }

    public string GetInformation()
    {
        return _information;
    }

}
