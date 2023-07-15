using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour
{
    [SerializeField] float _enemyMaxHp = 10;
    [SerializeField] float _enemyHp = 1;
    [SerializeField] float _moveSpeed = 1f;
    /// <summary>燃焼状態の時にどれくらいライフが減るか</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    [SerializeField] float _burningTime = 5f;
    /// <summary>速度低下の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;

    Rigidbody2D _rb;
    SpriteRenderer _sprite;
    EnemyState _state = EnemyState.Normal;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _enemyHp = _enemyMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        // 生死判定
        if (_enemyHp < 0)
        {
            _state = EnemyState.Dead;
        }

        if (_state == EnemyState.Burning)
        {
            _enemyHp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
            _sprite.color = Color.red;
        }
        else if (_state == EnemyState.Slow)
        {
            //_rb.velocity = dir * _moveSpede * _speedReductionRatioOnSlow;
            _sprite.color = Color.cyan;
        }
        else if (_state == EnemyState.Dead)
        {
            Debug.Log("やられた！");
            //if (倒されたとき用のプレハブ)
            //{
            //    Instantiate(倒されたとき用のプレハブ, this.transform.position, 倒されたとき用のプレハブ.transform.rotation);
            //}
            Destroy(this.gameObject);
        }
        else
        {
            _state = EnemyState.Normal;
            _sprite.color = Color.white;
        }
    }

    public float EnemyHp
    {
        get { return _enemyHp; }
        set { _enemyHp = value; } 
    }

    public EnemyState State
    {
        set { _state = value; }
    }

    public enum EnemyState
    {
        Normal,
        Burning,
        Slow,
        Dead,
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(_enemyHp);
    }
}
