using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();

    public static InventoryManager instance = null;
    public event Action InventoryCallBack;
    [SerializeField] ItemDataBase _inventoryData = null;
    // 持ち物管理
    [SerializeField] List<Item> _itemList = new List<Item>();
    public List<Item> ItemList => _itemList;
    // アイテム番号受け取り用
    int _itemNumber = 0;
    public int ItemNumber { get =>_itemNumber; set =>_itemNumber = value; }
    // アイテム管理
    //Dictionary<Item, int> ItemNumber = new Dictionary<Item, int>();
    //アイコン管理の配列
    //List<Image> Icons = new List<Image>();

    private void Awake()
    {
        // シングルトンの設定
        // １つまたは見つからない場合
        if (FindObjectsOfType<InventoryManager>().Length <= 1)// <= を　否定 >
        {
            instance = this;
        }
        else
        {
            //見つかったが、２つあった場合
            FindAnyObjectByType<InventoryManager>();
        }
    }

    /// <summary>インベントリにアイテムを追加する</summary>
    /// <param name="item">インベントリに追加するアイテム</param>
    public void AddItem(int num)
    {
        //アイテムリストの追加
        _itemList.Add(_inventoryData.ItemLists[num]);
        _inventoryData.ItemLists[num].UseItem();
        InventoryCallBack();
    }

    /// <summary>インベントリからアイテムを削除する</summary>
    /// <param name="item">インベントリから削除するアイテム</param>
    public void RemoveItem(int num)
    {
        _itemList.Remove(_inventoryData.ItemLists[num]);
        InventoryCallBack();
    }
}