using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLeftController : InputBase
{
    /// <summary>マズルの位置</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>ターゲットの位置</summary>
    [SerializeField] GameObject _target = default;
    /// <summary>弾の種類</summary>
    [SerializeField] List<GameObject> _bullet = new List<GameObject>();
    /// <summary>弾の種類の番号</summary>
    [SerializeField] int _bulletType = 0;
    /// <summary>大砲の角度制限</summary>s
    //[SerializeField] float _rotationLimit = 90f;

    // 各種初期化
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
        // 大砲の角度変更
        this.transform.up = _target.transform.position - this.transform.position;

        // 弾の発射
        if (_timer > _interval)
        {
            if (_inputController.Player.FireLeft.IsPressed())//押したことを判定
            {
                GameObject bullet = Instantiate(_bullet[_bulletType], _muzzle.position, this.transform.rotation);
                Debug.Log($"左砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval}");
                _interval = bullet.GetComponent<BulletBase>().Interval;
                _timer = 0f;
            }
        }

        // 弾の切り替え
        if (_inputController.Player.BulletChangeL.triggered)//押したことを判定
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
