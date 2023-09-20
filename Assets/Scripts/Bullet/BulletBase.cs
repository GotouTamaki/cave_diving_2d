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
    [SerializeField] int _damage = 1;
    /// <summary>�e�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 1f;
    /// <summary>�e�̃C���^�[�o���̍ŏ��l</summary>
    [SerializeField] float _minInterval = 0.05f;
    /// <summary>��Ԉُ�̈ێ�����</summary>
    [SerializeField] float _changeStateTime = 1f;

    // �e�평����
    Rigidbody2D _rb = null;

    /// <summary>�e�̃_���[�W���擾�ł��܂�</summary>
    public int Damage { get => _damage; set => _damage = value; }
    /// <summary>�e�̃C���^�[�o�����擾�ł��܂�</summary>
    public float Interval { get => _interval; set => _interval = value; }
    /// <summary>�e�̃C���^�[�o���̍ŏ��l���擾�ł��܂�</summary>
    public float MinInterval { get => _minInterval; set => _minInterval = value; }
    /// <summary>��Ԉُ�̈ێ����Ԃ��擾�ł��܂�</summary>
    public float ChangeStateTime { get => _changeStateTime; set => _changeStateTime = value; }
    /// <summary>Rigidbody2D���擾�ł��܂�</summary>t;
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
            // �_���[�W��^���鏈��
            other.GetComponent<CharacterBase>().CharacterHp -= _damage;
            //Destroy(this.gameObject);
        }

        Destroy(this.gameObject);

    }
}



