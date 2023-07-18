using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : InputBase
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
   
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    PlayerState _state = PlayerState.Normal;
    // 水平方向の入力値
    float _h;
    float _scaleX;
    bool _lookingRight = true;
    // ジャンプの入力値
    float _jumpCount;
    bool _isGrounded = false;
    float _axis = 0;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

            _h = _inputController.Player.Move.ReadValue<float>();
            //Debug.Log("移動処理");

        if (_inputController.Player.Jump.triggered && _isGrounded)//押したことを判定
        {
            // ジャンプの力を加える
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            //Debug.Log("ジャンプ処理");
        }

        _axis = _inputController.Player.Move.ReadValue<float>();//入力方向をfloat型で取得

        // 設定に応じて左右を反転させる
        if (_flipX)
        {
            FlipX(_h);
        }

        // 状態異常
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
        _rb.AddForce(Vector2.right * _h * _moveSpeed, ForceMode2D.Force);   
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
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _lookingRight = true;
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _lookingRight = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;

        //if (collision.gameObject.tag != "Bullet")
        //{
        //    _isGrounded = true;
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;

        //if (collision.gameObject.tag != "Bullet")
        //{
        //    _isGrounded = false;
        //}
    }

    public float PlayerHp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    public bool LookingRight()
    {
        return _lookingRight;
    }

    public enum PlayerState
    {
        Normal,
        Burning,
        Slow,
    }
}
