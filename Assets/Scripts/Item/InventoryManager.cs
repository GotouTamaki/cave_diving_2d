using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();

    public static InventoryManager instance = null;
    public event Action InventoryCallBack;
    [SerializeField] ItemDataBase _inventoryData = null;
    // �������Ǘ�
    [SerializeField] List<Item> _itemList = new List<Item>();
    public List<Item> ItemList => _itemList;
    // �A�C�e���ԍ��󂯎��p
    int _itemNumber = 0;
    public int ItemNumber { get =>_itemNumber; set =>_itemNumber = value; }
    // �A�C�e���Ǘ�
    //Dictionary<Item, int> ItemNumber = new Dictionary<Item, int>();
    //�A�C�R���Ǘ��̔z��
    //List<Image> Icons = new List<Image>();

    private void Awake()
    {
        // �V���O���g���̐ݒ�
        // �P�܂��͌�����Ȃ��ꍇ
        if (FindObjectsOfType<InventoryManager>().Length <= 1)// <= ���@�ے� >
        {
            instance = this;
        }
        else
        {
            //�����������A�Q�������ꍇ
            FindAnyObjectByType<InventoryManager>();
        }
    }    

    /// <summary>�C���x���g���ɃA�C�e����ǉ�����</summary>
    /// <param name="item">�C���x���g���ɒǉ�����A�C�e��</param>
    public void AddItem(int num)
    {
        //�A�C�e�����X�g�̒ǉ�
        _itemList.Add(_inventoryData.ItemLists[num]);
        InventoryCallBack();
    }

    /// <summary>�C���x���g������A�C�e�����폜����</summary>
    /// <param name="item">�C���x���g������폜����A�C�e��</param>
    public void RemoveItem(int num)
    {
        _itemList.Remove(_inventoryData.ItemLists[num]);
        InventoryCallBack();
    }
}