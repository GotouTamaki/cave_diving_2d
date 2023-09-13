using System;
using UnityEditor;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    /// <summary>アイテムの種類</summary>
    [SerializeField] KindOfItem _kindOfItem;
    /// <summary>アイテムの種類を取得できます</summary>
    public KindOfItem GetKindOfItem => _kindOfItem;
    /// <summary>アイテムのアイコン</summary>
    [SerializeField] Sprite _icon;
    /// <summary>アイテムのアイコンを取得できます</summary>
    public Sprite Icon => _icon;
    /// <summary>アイテムの名前</summary>
    [SerializeField] string _itemName;
    /// <summary>アイテムの名前を取得できます</summary>
    public string ItemName => _itemName;
    /// <summary>アイテムの情報</summary>
    [SerializeField] string _information;
    /// <summary>アイテムの情報を取得できます</summary>
    public string Information => _information;
    /// <summary>アイテムの効果対象の種類</summary>
    [SerializeField] SubjectOfEffects _subjectOfEffects;
    /// <summary>アイテムの効果対象の名前</summary>
    [SerializeField] string _objectName;
    /// <summary>アイテムの効果の大きさ</summary>
    [SerializeField] float _effectValue;
    public float EffectValue => _effectValue;

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
        //string address = $"Assets/Prefabs/{_subjectOfEffects}/{_objectName}.prefab";
        //GameObject targetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(address);
        //BulletParameter subjectComponent = targetPrefab.GetComponent<BulletParameter>();
        //subjectComponent.Interval = subjectComponent.Interval / _effectValue;
    }
}
