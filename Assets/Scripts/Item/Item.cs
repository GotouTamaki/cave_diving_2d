using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    /// <summary>�A�C�e���̎��</summary>
    //[SerializeField] KindOfItem _kindOfItem;
    /// <summary>�A�C�e���̃A�C�R��</summary>
    [SerializeField] Sprite _icon;
    /// <summary>�A�C�e���̖��O</summary>
    [SerializeField] string _itemName;
    /// <summary>�A�C�e���̏��</summary>
    [SerializeField] string _information;
    /// <summary>�A�C�e���̌��ʑΏۂ̎��</summary>
    //[SerializeField] SubjectOfEffects _subjectOfEffects;
    /// <summary>�A�C�e���̌��ʑΏۂ̖��O</summary>
    //[SerializeField] string _objectName;
    /// <summary>�A�C�e���̌��ʂ̑傫��</summary>
    //[SerializeField] float _effectValue;
    /// <summary>�e�̃_���[�W�̕ύX���ʂ̑傫��</summary>
    [SerializeField] float _damageChangeValue;
    /// <summary>�e�̃C���^�[�o���̕ύX���ʂ̑傫��</summary>
    [SerializeField] float _intervalChangeValue;
    /// <summary>�v���C���[��HP�񕜂̌��ʂ̑傫��</summary>
    [SerializeField] float _playerHealthValue;
    /// <summary>�v���C���[�̃W�����v�񐔂̕ύX���ʂ̑傫��</summary>
    [SerializeField] float _playerJumpCountChange;

    /// <summary>�A�C�e���̎�ނ��擾�ł��܂�</summary>
    //public KindOfItem GetKindOfItem => _kindOfItem;
    /// <summary>�A�C�e���̃A�C�R�����擾�ł��܂�</summary>
    public Sprite Icon => _icon;
    /// <summary>�A�C�e���̖��O���擾�ł��܂�</summary>
    public string ItemName => _itemName;
    /// <summary>�A�C�e���̏����擾�ł��܂�</summary>
    public string Information => _information;
    /// <summary>�A�C�e���̌��ʂ̑傫�����擾�ł��܂�</summary>
    //public float EffectValue => _effectValue;
    /// <summary>�e�̃_���[�W�̕ύX���ʂ̑傫�����擾�ł��܂�</summary>
    public float DamageChangeValue => _damageChangeValue;
    /// <summary>�e�̃C���^�[�o���̕ύX���ʂ̑傫�����擾�ł��܂�</summary>
    public float IntervalChangeValue => _intervalChangeValue;
    /// <summary>�v���C���[��HP�񕜂̌��ʂ̑傫�����擾�ł��܂�</summary>
    public float PlayerHealthValue => _playerHealthValue;
    /// <summary>�v���C���[�̃W�����v�񐔂̕ύX���ʂ̑傫�����擾�ł��܂�</summary>
    public float PlayerJumpCountChange => _playerJumpCountChange;

    //public enum KindOfItem
    //{
    //    Weapon,
    //    UseItem
    //}

    //enum SubjectOfEffects
    //{
    //    Bullets,
    //    Players,
    //    Enemies,
    //}

    public void UseItem()
    {
        //string address = $"Assets/Prefabs/{_subjectOfEffects}/{_objectName}.prefab";
        //GameObject targetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(address);
        //BulletParameter subjectComponent = targetPrefab.GetComponent<BulletParameter>();
        //subjectComponent.Interval = subjectComponent.Interval / _effectValue;
    }
}
