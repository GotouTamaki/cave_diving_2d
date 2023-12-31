using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class BulletBase : MonoBehaviour
{
    /// <summary>弾のアイコン</summary>
    [SerializeField] Sprite _bulletIcon = null;
    /// <summary>弾のスピード</summary>
    [SerializeField] float _bulletSpeed = 1f;
    /// <summary>弾のライフタイム</summary>
    [SerializeField] float _lifeTime = 10f;
    /// <summary>弾のダメージ</summary>
    [SerializeField] int _damage = 1;
    /// <summary>弾のインターバル</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>弾のインターバルの最小値</summary>
    [SerializeField] float _minInterval = 0.05f;
    /// <summary>状態異常の維持時間</summary>
    [SerializeField] float _changeStateTime = 1f;

    // 各種初期化
    Rigidbody2D _rb = null;
    AudioSource _audioSource = null;

    /// <summary>弾のアイコンを取得できます</summary>
    public Sprite BulletIcon => _bulletIcon;
    /// <summary>弾のダメージを取得できます</summary>
    public int Damage { get => _damage; set => _damage = value; }
    /// <summary>弾のインターバルを取得できます</summary>
    public float Interval { get => _interval; set => _interval = value; }
    /// <summary>弾のインターバルの最小値を取得できます</summary>
    public float MinInterval { get => _minInterval; set => _minInterval = value; }
    /// <summary>状態異常の維持時間を取得できます</summary>
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }
    /// <summary>Rigidbody2Dを取得できます</summary>t;
    public Rigidbody2D BulletRb2D => _rb;


    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * _bulletSpeed;
    }

    public void Update()
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
            //Destroy(this.gameObject);
        }

        Destroy(this.gameObject);

    }
}



