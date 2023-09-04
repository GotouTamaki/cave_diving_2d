using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>�\������A�C�R��</summary>
    [SerializeField] Image _icon = null;

    /// <summary>�A�C�e���X���b�g�ɃA�C�e����ǉ�����</summary>�@
    /// <param name="newItem">�ǉ�����A�C�e��</param>
    public void AddItemSlot(Item newItem)
    {
        Debug.Log("a");
        _icon.sprite = newItem.Icon;
        _icon.enabled = true;
    }

    /// <summary>�A�C�e���X���b�g����A�C�e�����폜����</summary>
    public void RemoveItem()
    {
        _icon.sprite = null;
        _icon.enabled = false;
    }
}
