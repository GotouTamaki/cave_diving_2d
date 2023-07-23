using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class EnemyBulletBase : MonoBehaviour
{
    /// <summary>弾のスピード</summary>
    [SerializeField] float _bulletSpeed = 1f;
    /// <summary>弾のライフタイム</summary>
    [SerializeField] float _lifeTime = 10f;
    /// <summary>弾のダメージ</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>弾のインターバル</summary>
    [SerializeField] float _interval = 1f;

    // 各種初期化
    GameObject _player = default;
    Rigidbody2D _rb = default;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * _bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            BulletPlayerHit(other.GetComponent<PlayerController>());
            // ダメージを与える処理
            other.GetComponent<PlayerController>().PlayerHp -= _damage;
            Destroy(this.gameObject);
        }
    }

    public abstract void BulletPlayerHit(PlayerController playerController);

    public float Interval()
    {
        return _interval;
    }
}
