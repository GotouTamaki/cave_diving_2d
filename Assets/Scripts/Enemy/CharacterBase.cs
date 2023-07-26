using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    PlayerState _state = PlayerState.Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 状態異常
        if (_state == PlayerState.Burning)
        {
            _hp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
            _sprite.color = Color.red;
        }
        else if (_state == PlayerState.Slow)
        {
            _sprite.color = Color.cyan;
        }
        else
        {
            _state = PlayerState.Normal;
            _sprite.color = Color.white;
        }
    }
}
