using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1f;
    [SerializeField] float _lifeTime = 10f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _interval = 1f;
    
    GameObject _player = null;
    Rigidbody2D _rb = null;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody2D>();
        //_rb.velocity = transform.right * _bulletSpeed;
        bool player = _player.GetComponent<PlayerController>().LookingRight;
        //Debug.Log(player);

        if (player)
        {
            _rb.velocity = transform.right * _bulletSpeed;
            //Debug.Log(player);
        }
        else
        {
            _rb.velocity = -transform.right * _bulletSpeed;
            //Debug.Log(player);
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
