using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    /// <summary>�\������A�C�R��</summary>
    [SerializeField] Image _icon = null;
    /// <summary>��̃A�C�R���̐F</summary>
    [SerializeField] Color _iconColor = Color.white;
    /// <summary>�A�C�R���Ƀ}�E�X�J�[�\�����d�Ȃ������̐F</summary>
    [SerializeField] Color _iconSelectColor = Color.white;
    /// <summary>InformationText�̐ݒ�</summary>
    [SerializeField] Text _infoText = null;

    // �e�평����
    Item _item = null;
    Color _beforeColor = Color.white;

    void OnEnable()
    {
        // ���j���[�\������
        if (_item != null)  // �A�C�e��������Δ���
        {
            _icon.color = Color.white;
        }
        else  // �������_iconColor��
        {
            _icon.color = _iconColor;
        }
    }

    /// <summary>�A�C�e���X���b�g�ɃA�C�e����ǉ�����</summary>
    /// <param name="newItem">�ǉ�����A�C�e��</param>
    public void AddItemSlot(Item newItem)
    {
        Debug.Log("a");
        _item = newItem;
        _icon.sprite = newItem.Icon;
        // �A�C�R�����ϐF���Ă��܂����ߔ��ɂ���
        _icon.color = Color.white;
    }

    /// <summary>�A�C�e���X���b�g����A�C�e�����폜����</summary>
    public void RemoveItem()
    {
        //throw new UnityException("�C���x���g���X���b�g�̎����R��A��");
        _item = null;
        // ��̃A�C�R���ɂ���
        _icon.sprite = DDOLController.instance.Inventory.InventoryData.ItemLists[0].Icon;
        // �����猳�ɖ߂�
        _icon.color = _iconColor;
    }

    /// <summary>�A�C�R���Ƀ}�E�X�J�[�\�����d�Ȃ������̏���</summary>
    public void IconPointeEnter()
    {
        // �ύX�O�̐F��ۑ�����
        _beforeColor = _icon.color;
        _icon.color = _iconSelectColor;
    }

    /// <summary>�A�C�R������}�E�X�J�[�\�������ꂽ���̏���</summary>
    public void IconPointeExit()
    {
        // �F�����ɖ߂�
        _icon.color = _beforeColor;
    }

    /// <summary>InformationPanel�ɕ\�����鏈��</summary>
    public void DisplayInfo()
    {
        if(_item != null)   // �A�C�e���������
        {
            _infoText.text = $"{_item.ItemName}\n{_item.Information}";  // �A�C�e���̐�����\������
        }
        else
        {
            _infoText.text = "�����";  // ������Ε\�����Ȃ�
            Debug.Log(_item);
        }
    }
}
