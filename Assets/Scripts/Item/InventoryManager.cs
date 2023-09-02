using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();

    public static InventoryManager instance = null;
    public event Action InventoryCallBack;
    // 持ち物管理
    [SerializeField] List<Item> _itemList = new List<Item>();
    public List<Item> ItemList => _itemList;
    // アイテム管理
    //Dictionary<Item, int> ItemNumber = new Dictionary<Item, int>();
    //アイコン管理の配列
    //List<Image> Icons = new List<Image>();

    private void Awake()
    {
        // シングルトンの設定
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    /// <summary>インベントリにアイテムを追加する</summary>
    /// <param name="item">インベントリに追加するアイテム</param>
    public void AddItem(Item item)
    {
        //アイテムリストの追加
        _itemList.Add(item);
        //InventorySlot.AddItemSlot(item);
    }

    /// <summary>インベントリからアイテムを削除する</summary>
    /// <param name="item">削除するアイテム</param>
    public void RemoveItem(Item item)
    {
        _itemList.Remove(item);
    }

}