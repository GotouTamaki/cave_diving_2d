using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //[SerializeField] ItemDataBase _itemDataBase;
    //[SerializeField] List<GameObject> _items = new List<GameObject>();

    public static InventoryManager instance = null;
    // �������Ǘ�
    [SerializeField] List<Item> _itemList = new List<Item>();
    public List<Item> ItemList => _itemList;
    // �A�C�e���Ǘ�
    //Dictionary<Item, int> ItemNumber = new Dictionary<Item, int>();
    //�A�C�R���Ǘ��̔z��
    //List<Image> Icons = new List<Image>();

    private void Awake()
    {
        // �V���O���g���̐ݒ�
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
        //�A�C�e�����X�g�̒ǉ�
        _itemList.Add(item);
    }

}
