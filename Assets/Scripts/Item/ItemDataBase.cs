using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] List<Item> _itemLists = new List<Item>();

    //　アイテムリストを返す
    public List<Item> GetItemLists()
    {
        return _itemLists;
    }
}
