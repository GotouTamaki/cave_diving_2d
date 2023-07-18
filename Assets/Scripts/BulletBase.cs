using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1f;
    [SerializeField] float _lifeTime = 10f;
    [SerializeField] float _damage = 1f;
    public float _interval = 1f;

    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (GetComponent<PlayerController>().LookingRight())
        {
            _rb.velocity = Vector2.right * _bulletSpeed;
        }
        else
        {
            _rb.velocity = -Vector2.right * _bulletSpeed;
        }
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

    public abstract void BulletEnemyHit(EnemyBase enemyBase);
    //public abstract void BulletMove();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            BulletEnemyHit(other.GetComponent<EnemyBase>());
            // É_ÉÅÅ[ÉWÇó^Ç¶ÇÈèàóù
            other.GetComponent<EnemyBase>().EnemyHp -= _damage;
            Destroy(this.gameObject);
        }
    }

    public float Interval()
    {
        return _interval;
    }
}
