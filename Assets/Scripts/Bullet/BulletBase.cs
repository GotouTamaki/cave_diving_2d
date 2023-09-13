using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public abstract class BulletBase : MonoBehaviour
{
    /// <summary>�e�̃X�s�[�h</summary>
    [SerializeField] float _bulletSpeed = 1f;
    /// <summary>�e�̃��C�t�^�C��</summary>
    [SerializeField] float _lifeTime = 10f;
    /// <summary>�e�̃_���[�W</summary>
    [SerializeField] float _damage = 1f;
    /// <summary>�e�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>��Ԉُ�̈ێ�����</summary>
    [SerializeField] float _changeStateTime = 1f;
    public float Damage { get => _damage; set => _damage = value; }
    public float Interval { get => _interval; set => _interval = value; }
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }

    // �e�평����
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
            // �_���[�W��^���鏈��
            other.GetComponent<CharacterBase>().CharacterHp -= _damage;
            Destroy(this.gameObject);
        }
    }
}



