using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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

    // �e�평����
    GameObject _player = default;
    Rigidbody2D _rb = default;

    // Start is called before the first frame update
    void Start()
    {
        //_player = GameObject.FindWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        //_rb.velocity = transform.right * _bulletSpeed;
        //bool player = _player.GetComponent<PlayerController>().LookingRight;
        //Debug.Log(player);

        // �v���C���[�̕������擾
        //if (player)
        //{
            _rb.velocity = transform.up * _bulletSpeed;
            //Debug.Log(player);
        //}
        //else
        //{
        //    _rb.velocity = -transform.up * _bulletSpeed;
        //    //Debug.Log(player);
        //}
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

    protected void FixedUpdate()
    {
        //_rb.velocity = Vector2.right * _bulletSpeed;
        //_rb.AddForce(Vector2.right * _bulletSpeed, ForceMode2D.Impulse);
    }

    public abstract void BulletEnemyHit(CharacterBase characterBase);
    //public abstract void BulletMove();

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

    public float Interval()
    {
        return _interval;
    }

    public float ChangeStateTime
    {
        get { return _changeStateTime; }
        set { _changeStateTime = value; }
    }
}
