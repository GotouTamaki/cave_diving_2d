using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonRightController : InputBase
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�e�̎��</summary>
    [SerializeField] List<GameObject> _bullet = new List<GameObject>();
    /// <summary>�e�̎�ނ̔ԍ�</summary>
    [SerializeField] int _bulletType = 0;
    /// <summary>��C�̊p�x����</summary>s
    [SerializeField] float _rotationLimit = 90f;

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

        // �e�̔���
        if (_timer > _interval )
        {
            if (_inputController.Player.FireRight.IsPressed())//���������Ƃ𔻒�
            {
                GameObject bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                Debug.Log($"�E�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval()}");
                _interval = bullet.GetComponent<BulletBase>().Interval();
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

        _r = _inputController.Player.PointCannonStick.ReadValue<Vector2>();
        //Debug.Log(_r);

        // ��C�̊p�x�ύX
        if (_r.x + _r.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, _r.x + _r.y * _rotationLimit);
        }
        else if (_r.x + _r.y < 0 && _r.x + _r.y <= -1f)
        {
            transform.rotation = Quaternion.Euler(0, 0, _r.x + _r.y * -_rotationLimit);
        }
    }
}
