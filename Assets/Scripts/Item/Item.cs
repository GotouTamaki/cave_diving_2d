using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    // �A�C�e���̎��
    [SerializeField] KindOfItem _kindOfItem;
    // �A�C�e���̃A�C�R��
    [SerializeField] Sprite _icon;
    // �A�C�e���̖��O
    [SerializeField] string _itemName;
    // �A�C�e���̏��
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
