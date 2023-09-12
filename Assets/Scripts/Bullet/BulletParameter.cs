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
    /// <summary>�e�̃��C�t�^�C��</summary>
    float _lifeTime;
    /// <summary>�e�̃_���[�W</summary>
    float _damage;
    /// <summary>�e�̃C���^�[�o��</summary>
    float _interval;
    /// <summary>��Ԉُ�̈ێ�����</summary>
    float _changeStateTime;

    public float Interval { get => _interval; set => _interval = value; }
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }
}
