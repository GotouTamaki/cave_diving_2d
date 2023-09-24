using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    /// <summary>アイテムの種類</summary>
    [SerializeField] KindOfItem _kindOfItem;
    /// <summary>アイテムのアイコン</summary>
    [SerializeField] Sprite _icon;
    /// <summary>アイテムの名前</summary>
    [SerializeField] string _itemName;
    /// <summary>アイテムの情報</summary>
    [SerializeField] string _information;
    /// <summary>アイテムの効果対象の種類</summary>
    //[SerializeField] SubjectOfEffects _subjectOfEffects;
    /// <summary>アイテムの効果対象の名前</summary>
    //[SerializeField] string _objectName;
    /// <summary>アイテムの効果の大きさ</summary>
    //[SerializeField] float _effectValue;
    /// <summary>弾のダメージの変更効果の大きさ</summary>
    [SerializeField] int _damageChangeValue;
    /// <summary>弾のインターバルの変更効果の大きさ</summary>
    [SerializeField] float _intervalChangeValue;
    /// <summary>プレイヤーのHP回復の効果の大きさ</summary>
    [SerializeField] float _playerHealthValue;
    /// <summary>プレイヤーのジャンプ回数の変更効果の大きさ</summary>
    [SerializeField] int _playerJumpCountChange;

    /// <summary>アイテムの種類を取得できます</summary>
    public KindOfItem GetKindOfItem => _kindOfItem;
    /// <summary>アイテムのアイコンを取得できます</summary>
    public Sprite Icon => _icon;
    /// <summary>アイテムの名前を取得できます</summary>
    public string ItemName => _itemName;
    /// <summary>アイテムの情報を取得できます</summary>
    public string Information => _information;
    /// <summary>アイテムの効果の大きさを取得できます</summary>
    //public float EffectValue => _effectValue;
    /// <summary>弾のダメージの変更効果の大きさを取得できます</summary>
    public int DamageChangeValue => _damageChangeValue;
    /// <summary>弾のインターバルの変更効果の大きさを取得できます</summary>
    public float IntervalChangeValue => _intervalChangeValue;
    /// <summary>プレイヤーのHP回復の効果の大きさを取得できます</summary>
    public float PlayerHealthValue => _playerHealthValue;
    /// <summary>プレイヤーのジャンプ回数の変更効果の大きさを取得できます</summary>
    public int PlayerJumpCountChange => _playerJumpCountChange;

    public enum KindOfItem
    {
        EnhancedItems,
        KeyItems,
    }

    //enum SubjectOfEffects
    //{
    //    Bullets,
    //    Players,
    //    Enemies,
    //}

    //public void UseItem()
    //{
    //string address = $"Assets/Prefabs/{_subjectOfEffects}/{_objectName}.prefab";
    //GameObject targetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(address);
    //BulletParameter subjectComponent = targetPrefab.GetComponent<BulletParameter>();
    //subjectComponent.Interval = subjectComponent.Interval / _effectValue;
    //}
}
