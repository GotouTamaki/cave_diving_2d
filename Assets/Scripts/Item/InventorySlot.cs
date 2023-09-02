using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>�\������A�C�R��</summary>
    Image _icon = null;

    /// <summary>�A�C�e���X���b�g�ɃA�C�e����ǉ�����</summary>�@
    /// <param name="newitem">�ǉ�����A�C�e��</param>
    public void AddItemSlot(Item newitem)
    {
        _icon.sprite = newitem.Icon;
        _icon.enabled = true;
    }

    /// <summary>�A�C�e���X���b�g����A�C�e�����폜����</summary>
    public void RemoveItem()
    {
        _icon.sprite = null;
        _icon.enabled = false;
    }
}
