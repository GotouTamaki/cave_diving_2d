using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>�\������A�C�R��</summary>
    [SerializeField] Image _icon = null;
    [SerializeField] Color _iconColor = Color.white;
    [SerializeField] Color _iconSelectColor = Color.white;
    [SerializeField] Text _infoText = null;

    Item _item = null;
    Color _beforeColor = Color.white;

    /// <summary>�A�C�e���X���b�g�ɃA�C�e����ǉ�����</summary>
    /// <param name="newItem">�ǉ�����A�C�e��</param>
    public void AddItemSlot(Item newItem)
    {
        Debug.Log("a");
        _item = newItem;
        _icon.sprite = newItem.Icon;
        _icon.color = Color.white;
        _icon.enabled = true;
    }

    /// <summary>�A�C�e���X���b�g����A�C�e�����폜����</summary>
    public void RemoveItem()
    {
        //_icon.sprite = null;
        //throw new UnityException("�C���x���g���X���b�g�̎����R��A��");
        _icon.sprite = InventoryManager.instance.InventoryData.ItemLists[0].Icon;
        _icon.color = _iconColor;
        _icon.enabled = true;
    }

    public void IconPointeEnter()
    {
        _beforeColor = _icon.color;
        _icon.color = _iconSelectColor;
    }

    public void IconPointeExit()
    {
        _icon.color = _beforeColor;
    }

    public void DisplayInfo()
    {
        if(_item != null)
        {
            _infoText.text = _item.Information;
        }
        else
        {
            _infoText.text = string.Empty;
        }
    }
}
