using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemDataBase _itemDataBase;
    [SerializeField] List<GameObject> _items = new List<GameObject>();

    // 持ち物管理
    List<Item> ItemList = new List<Item>();
    // アイテム管理
    Dictionary<Item, bool> ItemNumber = new Dictionary<Item, bool>();
    //アイコン管理の配列
    List<Image> Icons = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in _items) 
        {
            //ItemNumber.Add(ItemDataBase.GetItemLists()[item], 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventoryUpdate()
    {
        //持ち物リストのクリア
        ItemList.Clear();
    }
}
