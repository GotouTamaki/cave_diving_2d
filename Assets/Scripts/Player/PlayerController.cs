using UnityEngine;
using Cinemachine;

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
    /// <summary>初期のジャンプ回数のリミット</summary>
    [SerializeField] int _initialJumpCount = 1;

    // 各種初期化
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    BulletBase _bulletBase = default;
    CharacterBase _characterBase = default;
    /// <summary>Cinemachineの仮想カメラ</summary>
    CinemachineVirtualCamera _vcam = default;
    PlayerState _state = PlayerState.Normal;
    float _stateTime = 0;
    // 水平方向の入力値
    float _h = 0;
    float _scaleX = 0;
    bool _lookingRight = true;
    // ジャンプの入力値
    int _jumpCount = 0;
    int _jumpCountLimit = 1;
    bool _isGrounded = false;
    bool _canCheck = false;

    public PlayerState State { set => _state = value; }
    public bool CharacterHp { get => _lookingRight; set => _lookingRight = value; }
    public bool IsGrounded { get => _isGrounded; set => _isGrounded = value; }
    public int JumpCount { get => _jumpCount; set => _jumpCount = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _characterBase = GetComponent<CharacterBase>();
        //Cinemachineのインスタンスの取得と追跡対象と捕捉対象の登録
        _vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        _vcam.m_LookAt = this.gameObject.transform;
        _vcam.m_Follow = this.gameObject.transform;
        PlayerParameterChange();
    }

    // Update is called once per frame
    void Update()
    {
        _h = _inputController.Player.Move.ReadValue<float>(); //入力方向をfloat型で取得
        //Debug.Log(_inputController.Player.Move.ReadValue<float>());

        if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Slow && (_isGrounded || _jumpCount < _jumpCountLimit))//押したことを判定
        {
            // ジャンプの力を加える
            _rb.AddForce(Vector2.up * _jumpPower * _speedReductionRatioOnSlow, ForceMode2D.Impulse);
            _jumpCount++;
            //Debug.Log("ジャンプ処理");
        }
        else if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Normal && (_isGrounded || _jumpCount < _jumpCountLimit))//押したことを判定
        {
            // ジャンプの力を加える
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
            //Debug.Log("ジャンプ処理");
        }

        // 入力に応じて左右を反転させる
        FlipX(_h);
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

        //if (horizontal > 0)
        //{
        //    _sprite.flipX = false;
        //    _lookingRight = true;
        //}
        //else if (horizontal < 0)
        //{
        //    _sprite.flipX = true;
        //    _lookingRight = false;
        //}
        //画像フリップ処理
        _sprite.flipX = horizontal < 0;
        //右を向いてるかのフラグ
        _lookingRight = horizontal > 0;
    }

    void PlayerParameterChange()
    {
        int jumpCountChange = 0;

        foreach (Item item in DDOLController.instance.Inventory.ItemList)
        {
            jumpCountChange += item.PlayerJumpCountChange;
        }

        _jumpCountLimit = _initialJumpCount + jumpCountChange;
        Debug.Log($"JumpCountLimit:{_jumpCountLimit}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            PlayerParameterChange();
        }
    }

    public enum PlayerState
    {
        Normal,
        Burning,
        Slow,
    }
}
