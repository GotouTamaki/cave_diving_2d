using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonRightController : InputBase
{
    [SerializeField] Transform _muzzle = null;
    [SerializeField] List<GameObject> _bullet = new List<GameObject>();
    [SerializeField] int _bulletType = 0;

    public float _interval = 1f;
    float _timer;

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

        if (_timer > _interval )
        {
            if (_inputController.Player.FireRight.IsPressed())//押したことを判定
            {
                GameObject bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                Debug.Log($"右砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval()}");
                _interval = bullet.GetComponent<BulletBase>().Interval();
                _timer = 0f;
            }
        }

        if (_inputController.Player.BulletChangeR.triggered)//押したことを判定
        {
            ++_bulletType;
 
            if (_bulletType > 4)
            {
                _bulletType = 0;
            }

            Debug.Log(_bulletType);
        }


    }
}
