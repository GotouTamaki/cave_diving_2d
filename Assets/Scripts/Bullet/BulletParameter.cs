using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Bullet", menuName = "CreateBullet")]
public class BulletParameter : ScriptableObject
{
    BulletValue[] bulletValues = null;
}

[System.Serializable]
public class BulletValue
{
    float _bulletSpeed;
    /// <summary>弾のライフタイム</summary>
    float _lifeTime;
    /// <summary>弾のダメージ</summary>
    float _damage;
    /// <summary>弾のインターバル</summary>
    float _interval;
    /// <summary>状態異常の維持時間</summary>
    float _changeStateTime;

    public float Interval { get => _interval; set => _interval = value; }
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }
}
