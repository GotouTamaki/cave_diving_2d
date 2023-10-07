using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();
    //public static InventoryManager instance = null;
    public Action InventoryCallBack;
    [SerializeField] ItemDataBase _inventoryData = null;
    /// <summary>持ち物管理用List</summary>
    [SerializeField] List<Item> _itemList = new List<Item>();
    [SerializeField] ItemGetUI _itemGetUI = null;
    /// <summary>キーアイテムのカウント</summary>
    int _clearCount = 0;

    /// <summary>持ち物管理用Listを取得できます</summary>
    public List<Item> ItemList => _itemList;
    public ItemDataBase InventoryData => _inventoryData;
    public int ClearCount => _clearCount;
    // アイテム管理
    //Dictionary<Item, int> ItemNumber = new Dictionary<Item, int>();
    //アイコン管理の配列
    //List<Image> Icons = new List<Image>();

    //private void Awake()
    //{
    //    // シングルトンの設定
    //    // １つまたは見つからない場合
    //    if (FindObjectsOfType<InventoryManager>().Length <= 1)// <= を　否定 >
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        //見つかったが、２つあった場合
    //        instance = FindAnyObjectByType<InventoryManager>();
    //    }
    //}

    void OnEnable()
    {
        SceneManager.sceneLoaded += InventoryReset;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= InventoryReset;
    }

    void InventoryReset(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TitleScene")
        {
            _itemList.Clear();
            _clearCount = 0;
            RemoveItem(0);
        }
    }

    /// <summary>インベントリにアイテムを追加する</summary>
    /// <param name="item">インベントリに追加するアイテム</param>
    public void AddItem(int num)
    {
        //アイテムリストの追加
        _itemList.Add(_inventoryData.ItemLists[num]);
        _itemGetUI.OutputLog(_inventoryData.ItemLists[num]);

        if (_inventoryData.ItemLists[num].GetKindOfItem == Item.KindOfItem.KeyItems)
        {
            _clearCount++;
            Debug.Log($"ClearCount:{_clearCount}");
        }
        //_inventoryData.ItemLists[num].UseItem();
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