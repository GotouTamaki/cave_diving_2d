using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonRightController : InputBase
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�^�[�Q�b�g�̈ʒu</summary>
    [SerializeField] GameObject _target = default;
    /// <summary>�e�̎��</summary>
    [SerializeField] List<BulletBase> _bullet = new List<BulletBase>();
    /// <summary>�e�̎�ނ̔ԍ�</summary>
    [SerializeField] int _bulletType = 0;
    /// <summary>��C�̊p�x����</summary>s
    //[SerializeField] float _rotationLimit = 90f;

    // �e�평����
    float _interval = 1f;
    float _timer = 0;
    Vector2 _r = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //_interval = _bullet[_bulletType].BulletBase.Interval();
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        _r = _inputController.Player.PointCannonStick.ReadValue<Vector2>();
        // ��C�̊p�x�ύX
        this.transform.up = _target.transform.position - this.transform.position;

        // �e�̔���
        if (_timer > _interval )
        {
            if (_inputController.Player.FireRight.IsPressed())//���������Ƃ𔻒�
            {
                BulletBase bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                Debug.Log($"�E�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval}");
                BulletParameterChange(bullet);
                _interval = bullet.GetComponent<BulletBase>().Interval;
                _timer = 0f;
            }
        }

        // �e�̐؂�ւ�
        if (_inputController.Player.BulletChangeR.triggered)//���������Ƃ𔻒�
        {
            ++_bulletType;

            if (_bulletType > 4)
            {
                _bulletType = 0;
            }

            Debug.Log(_bulletType);
        }
    }

    void BulletParameterChange(BulletBase bulletBase)
    {
        foreach (Item item in DDOLController.instance.Inventory.ItemList)
        {
            bulletBase.Damage += item.DamageChangeValue;
            bulletBase.Interval -= item.IntervalChangeValue;
        }

        if (bulletBase.Interval <= bulletBase.MinInterval)
        {
            bulletBase.Interval = bulletBase.MinInterval;
            Debug.Log($"{bulletBase}�̃C���^�[�o���͂����Z���Ȃ�Ȃ��I�I");
        }
    }
}
