using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class ItemBase : MonoBehaviour
{
    //　アイテムデータベース
    [SerializeField] ItemDataBase _itemDateBase;
    [SerializeField] int _itemNum = 0;
    //　アイテム数管理
    //private Dictionary<Item, int> _numOfItem = new Dictionary<Item, int>();

    //public void AddItemData(Item item)
    //{
    //    _itemDateBase.GetItemLists().Add(item);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Item()
    {      
        Item item = ScriptableObject.CreateInstance("Item") as Item;
        item = _itemDateBase.GetItemLists()[_itemNum];
        Debug.Log(item.GetItemName() + " " + item.GetInformation());      
    }
}

