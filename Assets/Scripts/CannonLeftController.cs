using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonLeftController : InputBase
{
    [SerializeField] Transform _muzzle = null;
    [SerializeField] List<GameObject> _bullet = new List<GameObject>();
    [SerializeField] int _bulletType = 0;
    [SerializeField] float _rotationLimit = 90f;

    float _interval = 1f;
    float _timer;
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

        if (_timer > _interval)
        {
            if (_inputController.Player.FireLeft.IsPressed())//押したことを判定
            {
                GameObject bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                Debug.Log($"右砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval()}");
                _interval = bullet.GetComponent<BulletBase>().Interval();
                _timer = 0f;
            }
        }

        if (_inputController.Player.BulletChangeL.triggered)//押したことを判定
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
    }

    private void FixedUpdate()
    {
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
