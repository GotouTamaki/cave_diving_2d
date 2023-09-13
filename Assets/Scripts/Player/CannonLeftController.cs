using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLeftController : InputBase
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�^�[�Q�b�g�̈ʒu</summary>
    [SerializeField] GameObject _target = default;
    /// <summary>�e�̎��</summary>
    [SerializeField] List<BulletBase> _bullet = new List<BulletBase>();
    /// <summary>�e�̎�ނ̔ԍ�</summary>
    [SerializeField] int _bulletType = 0;
    /// <summary>��C�̊p�x����</summary>
    //[SerializeField] float _rotationLimit = 90f;

    // �e�평����
    float _interval = 1f;
    float _timer = 0;
    Vector2 _r = Vector2.zero;

    void Start()
    {
        _timer = _interval;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        _r = _inputController.Player.PointCannonStick.ReadValue<Vector2>();
        // ��C�̊p�x�ύX
        this.transform.up = _target.transform.position - this.transform.position;

        // �e�̔���
        if (_timer > _interval)
        {
            if (_inputController.Player.FireLeft.IsPressed())// ���������Ƃ𔻒�
            {
                BulletBase bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                //TODO CannonController�ɂ���BulletParameter�̒l�������ɑ���ł���悤�ɂ���
                Parameter(bullet);
                Debug.Log($"���C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval}");
                _interval = bullet.Interval;
                _timer = 0f;
            }
        }

        // �e�̐؂�ւ�
        if (_inputController.Player.BulletChangeL.triggered)// ���������Ƃ𔻒�
        {
            ++_bulletType;

            if (_bulletType > 4)
            {
                _bulletType = 0;
            }

            Debug.Log(_bulletType);
        }
    }

    void Parameter(BulletBase bulletBase)
    {
        foreach (Item item in InventoryManager.instance.ItemList)
        {
            bulletBase.Damage += item.EffectValue;
            bulletBase.Interval /= item.EffectValue;
        }
    }
}
