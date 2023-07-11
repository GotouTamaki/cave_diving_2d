using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _maxHp = 1;
    [SerializeField] float _hp = 1;
    // 左右移動する力
    [SerializeField] float _moveSpeed = 5f;
    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;
    // 入力に応じて左右を反転させるかどうかのフラグ
    [SerializeField] bool _flipX = false;
    /// <summary>燃焼状態の時にどれくらいライフが減るか</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>速度低下の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;


    // 各種初期化
    InputAction _action;
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    PlayerState _state = PlayerState.Normal;
    // 水平方向の入力値
    float _h;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // 有効化
    private void OnEnable()
    {
        // InputActionを有効化
        // これをしないと入力を受け取れないことに注意
        _action?.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // 入力検出と移動
        //float h = InputAction.CallbackContext;
        //float v = Input.GetAxisRaw("Vertical");
        //Vector2 dir = new Vector2(h, v).normalized;

        if (_state == PlayerState.Burning)
        {
            _hp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
        }
        else if (_state == PlayerState.Slow)
        {
            //_rb.velocity = dir * _moveSpeed * _speedReductionRatioOnSlow;
            _sprite.color = Color.yellow;
        }
        else
        {
            _state = PlayerState.Normal;
            _sprite.color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        // 横移動の力を加えるのは FixedUpdate で行う
        //_rb.AddForce(Vector2.right * _h * _moveSpeed, ForceMode2D.Force);
    }

    public float PlayerHp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public enum PlayerState
    {
        Normal,
        Burning,
        Slow,
    }
}
