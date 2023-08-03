using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletBase;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>マズルの位置</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>弾の種類</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>大砲の角度制限</summary>
    [SerializeField] float _rotationLimit = 90f;

    // 各種初期化
    float _interval = 1f;
    float _timer = 0;
    GameObject _lookingObject = null;
    bool _look = false;
    //Vector2 _r = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_lookingObject != null)
        {
            this.transform.up = _lookingObject.transform.position - this.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _lookingObject = other.gameObject;

        // 弾の発射
        if (_timer > _interval && other.gameObject.tag == "Player")
        {
            GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
            Debug.Log($"敵砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval()}");
            _interval = bullet.GetComponent<BulletBase>().Interval();
            _timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lookingObject = null;
    }
}
