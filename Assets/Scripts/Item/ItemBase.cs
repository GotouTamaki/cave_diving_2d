using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class ItemBase : MonoBehaviour
{
    //�@�A�C�e���f�[�^�x�[�X
    [SerializeField] ItemDataBase _itemDateBase = default;
    [SerializeField] int _itemNum = 0;
    //�@�A�C�e�����Ǘ�
    //private Dictionary<Item, int> _numOfItem = new Dictionary<Item, int>();

    //public void AddItemData(Item item)
    //{
    //    _itemDateBase.GetItemLists().Add(item);
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�A�C�e���̎擾�̏���
    public void Item()
    {      
        Item item = ScriptableObject.CreateInstance("Item") as Item;
        item = _itemDateBase.GetItemLists()[_itemNum];
        Debug.Log(item.GetItemName() + " " + item.GetInformation());
        Destroy(this.gameObject);
    }
}

