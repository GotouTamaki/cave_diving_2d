using UnityEngine;

public class ItemBase : MonoBehaviour
{
    //�@�A�C�e���̏��
    [SerializeField] Item _item = default;
    //[SerializeField] int _itemNum = 0;

    //�A�C�e���̎擾�̏���
    public void ItemGet()
    {
        InventoryManager.instance.AddItem(_item);
        Destroy(this.gameObject);
    }
}

