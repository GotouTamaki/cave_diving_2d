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
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 弾の発射
        if (_timer > _interval && other.gameObject.tag == "Player")
        {
            GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
            Debug.Log($"敵砲発射、インターバル{bullet.GetComponent<EnemyBulletBase>().Interval()}");
            _interval = bullet.GetComponent<EnemyBulletBase>().Interval();
            _timer = 0f;
        }
    }
}
