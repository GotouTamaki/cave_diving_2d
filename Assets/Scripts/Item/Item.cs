using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    // �A�C�e���̎��
    [SerializeField] KindOfItem _kindOfItem;
    public KindOfItem GetKindOfItem => _kindOfItem;
    // �A�C�e���̃A�C�R��
    [SerializeField] Sprite _icon;
    public Sprite Icon => _icon;
    // �A�C�e���̖��O
    [SerializeField] string _itemName;
    public string ItemName => _itemName;
    // �A�C�e���̏��
    [SerializeField] string _information;
    public string Information => _information;

    public enum KindOfItem
    {
        Weapon,
        UseItem
    }
}
