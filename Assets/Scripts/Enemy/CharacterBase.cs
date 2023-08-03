using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyBase;
using static PlayerController;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterBase : MonoBehaviour
{
    [SerializeField] float _maxHp = 1;
    [SerializeField] float _hp = 1;
    // 左右移動する力
    [SerializeField] float _moveSpeed = 5f;
    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;
    /// <summary>燃焼状態の時にどれくらいライフが減るか</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>速度低下の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;

    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    CharacterState _state = CharacterState.Normal;
    [SerializeField] float _stateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 生死判定
        if (_hp <= 0)
        {
            _state = CharacterState.Dead;
        }

        // 状態異常になっている時間
        _stateTime -= Time.deltaTime;

        if (_stateTime < 0 && _hp > 0)
        {
            _state = CharacterState.Normal;
            _stateTime = 0;
            //Debug.Log("ノーマル！");
        }

        // 状態異常
        if (_state == CharacterState.Burning)
        {
            _hp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
            _sprite.color = Color.red;
        }
        else if (_state == CharacterState.Slow)
        {
            _sprite.color = Color.cyan;
        }
        else if (_state == CharacterState.Dead)
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
            _state = CharacterState.Normal;
            _sprite.color = Color.white;
        }
    }

    public float CharacterHp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public enum CharacterState
    {
        Normal,
        Burning,
        Slow,
        Dead,
    }

    public CharacterState State
    {
        get { return _state; }
        set { _state = value; }
    }

    public float StateTime
    {
        get { return _stateTime; }
        set { _stateTime = value; }
    }
}
