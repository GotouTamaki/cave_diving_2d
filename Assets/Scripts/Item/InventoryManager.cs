using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();

    public static InventoryManager instance = null;
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

    public void AddItem(Item item)
    {
        //アイテムリストの追加
        _itemList.Add(item);
    }

}
