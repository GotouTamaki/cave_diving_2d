using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemDataBase _itemDataBase;
    [SerializeField] List<GameObject> _items = new List<GameObject>();

    // �������Ǘ�
    List<Item> ItemList = new List<Item>();
    // �A�C�e���Ǘ�
    Dictionary<Item, bool> ItemNumber = new Dictionary<Item, bool>();
    //�A�C�R���Ǘ��̔z��
    List<Image> Icons = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in _items) 
        {
            //ItemNumber.Add(ItemDataBase.GetItemLists(), false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InventoryUpdate()
    {
        //���������X�g�̃N���A
        ItemList.Clear();
    }
}
