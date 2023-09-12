using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class BulletBase : MonoBehaviour
{    /// <summary>弾のスピード</summary>
    [SerializeField] float _bulletSpeed = 1f;
    /// <summary>弾のライフタイム</summary>
    [SerializeField] float _lifeTime = 10f;
    /// <summary>弾のダメージ</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>弾のインターバル</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>状態異常の維持時間</summary>
    [SerializeField] float _changeStateTime = 1f;
    public float Interval { get => _interval; set => _interval = value; }
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }

    // 各種初期化
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _bulletSpeed;
    }

    void Update()
    {
        _lifeTime -= Time.deltaTime;

        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void BulletEnemyHit(CharacterBase characterBase);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterBase>() != null)
        {
            BulletEnemyHit(other.GetComponent<CharacterBase>());
            // ダメージを与える処理
            other.GetComponent<CharacterBase>().CharacterHp -= _damage;
            Destroy(this.gameObject);
        }
    }

    public void Parameter()
    {

    }
}



