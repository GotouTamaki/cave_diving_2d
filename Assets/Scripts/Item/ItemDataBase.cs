using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField] List<Item> _itemLists = new List<Item>();
    public List<Item> ItemLists => _itemLists;

}
