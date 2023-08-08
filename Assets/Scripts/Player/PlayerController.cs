using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static EnemyBase;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : InputBase
{
    //[SerializeField] float _maxHp = 1;
    //[SerializeField] float _hp = 1;
    // 左右移動する力
    [SerializeField] float _moveSpeed = 5f;
    // ジャンプする力
    [SerializeField] float _jumpPower = 15f;
    /// <summary>燃焼状態の時にどれくらいライフが減るか</summary>
    //[SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>速度低下の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;

    // 各種初期化
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    BulletBase _bulletBase = default;
    CharacterBase _characterBase = default;
    PlayerState _state = PlayerState.Normal;
    float _stateTime = 0;
    // 水平方向の入力値
    float _h = 0;
    float _scaleX = 0;
    bool _lookingRight = true;
    // ジャンプの入力値
    float _jumpCount = 0;
    bool _isGrounded = false;
    float _axis = 0;
    bool _canCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _characterBase = GetComponent<CharacterBase>();
    }

    // Update is called once per frame
    void Update()
    {
        _h = _inputController.Player.Move.ReadValue<float>();
        //Debug.Log(_inputController.Player.Move.ReadValue<float>());

        //_stateTime -= Time.deltaTime;

        //if (_stateTime < 0) 
        //{
        //    _state = PlayerState.Normal;
        //    _stateTime = 0;
        //    //Debug.Log("ノーマル！");
        //}

        if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Slow && _isGrounded)//押したことを判定
        {
            // ジャンプの力を加える
            _rb.AddForce(Vector2.up * _jumpPower * _speedReductionRatioOnSlow, ForceMode2D.Impulse);
            //Debug.Log("ジャンプ処理");
        }
        else if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Normal && _isGrounded)//押したことを判定
        {
            // ジャンプの力を加える
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            //Debug.Log("ジャンプ処理");
        }

        _axis = _inputController.Player.Move.ReadValue<float>();//入力方向をfloat型で取得

        // 入力に応じて左右を反転させる   
        FlipX(_h);
        
        // 状態異常
        //if (_state == PlayerState.Burning)
        //{
        //    //_hp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
        //    _sprite.color = Color.red;
        //}
        //else if (_state == PlayerState.Slow)
        //{
        //    _sprite.color = Color.cyan;
        //}
        //else
        //{
        //    _state = PlayerState.Normal;
        //    _sprite.color = Color.white;
        //} 
    }

    private void FixedUpdate()
    {
        // 横移動の力を加えるのは FixedUpdate で行う
        if (_state == PlayerState.Slow) 
        {
            _rb.AddForce(Vector2.right * _h * _moveSpeed * _speedReductionRatioOnSlow, ForceMode2D.Force);
        }
        else if (_state == PlayerState.Normal)
        {
            _rb.AddForce(Vector2.right * _h * _moveSpeed, ForceMode2D.Force);
        }
        
    }

    void FlipX(float horizontal)
    {
        /*
         * 左を入力されたらキャラクターを左に向ける。
         * 左右を反転させるには、Transform:Scale:X に -1 を掛ける。
         * Sprite Renderer の Flip:X を操作しても反転する。
         * */
        _scaleX = this.transform.localScale.x;

        if (horizontal > 0)
        {
            _sprite.flipX = false;
            _lookingRight = true;
        }
        else if (horizontal < 0)
        {
            _sprite.flipX = true;
            _lookingRight = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "JudgmentRange" && _inputController.Player.Choice.triggered)
        //{
        //    _canCheck = true;
        //    Debug.Log(_canCheck);
        //    collision.GetComponent<ItemBase>().Item();
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item" && _inputController.Player.Choice.triggered)
        {
            _canCheck = true;
            //Debug.Log(_canCheck);
            //other.GetComponent<ItemBase>().Item();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JudgmentRange" && _inputController.Player.Choice.triggered)
        {
            _canCheck = true;
            Debug.Log(_canCheck);
        }
    }

    //public float PlayerHp
    //{
    //    get { return _hp; }
    //    set { _hp = value; }
    //}

    public bool LookingRight
    {
        get { return _lookingRight; } 
        set { _lookingRight = value; }
    }

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value; }
    }

    public enum PlayerState
    {
        Normal,
        Burning,
        Slow,
    }

    public PlayerState State
    {
        set { _state = value; }
    }

    //public float StateTime
    //{
    //    get { return _stateTime; }
    //    set { _stateTime = value; }
    //}
}
