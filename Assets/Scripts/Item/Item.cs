using System;
using UnityEditor;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    /// <summary>�A�C�e���̎��</summary>
    [SerializeField] KindOfItem _kindOfItem;
    /// <summary>�A�C�e���̎�ނ��擾�ł��܂�</summary>
    public KindOfItem GetKindOfItem => _kindOfItem;
    /// <summary>�A�C�e���̃A�C�R��</summary>
    [SerializeField] Sprite _icon;
    /// <summary>�A�C�e���̃A�C�R�����擾�ł��܂�</summary>
    public Sprite Icon => _icon;
    /// <summary>�A�C�e���̖��O</summary>
    [SerializeField] string _itemName;
    /// <summary>�A�C�e���̖��O���擾�ł��܂�</summary>
    public string ItemName => _itemName;
    /// <summary>�A�C�e���̏��</summary>
    [SerializeField] string _information;
    /// <summary>�A�C�e���̏����擾�ł��܂�</summary>
    public string Information => _information;
    /// <summary>�A�C�e���̌��ʑΏۂ̎��</summary>
    [SerializeField] SubjectOfEffects _subjectOfEffects;
    /// <summary>�A�C�e���̌��ʑΏۂ̖��O</summary>
    [SerializeField] string _objectName;
    /// <summary>�A�C�e���̌��ʂ̑傫��</summary>
    [SerializeField] float _effects;

    public enum KindOfItem
    {
        Weapon,
        UseItem
    }

    enum SubjectOfEffects
    {
        Bullets,
        Players,
        Enemies,
    }

    public void UseItem()
    {
        string address = $"Assets/Prefabs/{_subjectOfEffects}/{_objectName}.prefab";
        GameObject targetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(address);
        BulletBase subjectComponent = targetPrefab.GetComponent<BulletBase>();
        subjectComponent.Interval = subjectComponent.Interval / _effects;
    }
}
