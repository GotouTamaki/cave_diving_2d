using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "ItemIndex", menuName = "CreateItemIndex")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField]
    private List<Item> _itemLists = new List<Item>();

    //�@�A�C�e�����X�g��Ԃ�
    public List<Item> GetItemLists()
    {
        return _itemLists;
    }
}
