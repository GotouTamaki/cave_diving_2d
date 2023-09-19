using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : InputBase
{
    //[SerializeField] float _maxHp = 1;
    //[SerializeField] float _hp = 1;
    // ���E�ړ������
    [SerializeField] float _moveSpeed = 5f;
    // �W�����v�����
    [SerializeField] float _jumpPower = 15f;
    /// <summary>�R�ď�Ԃ̎��ɂǂꂭ�炢���C�t�����邩</summary>
    //[SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>���x�ቺ�̎��ɂǂꂭ�炢�ړ����x�������邩</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;
    /// <summary>�����̃W�����v�񐔂̃��~�b�g</summary>
    [SerializeField] int _initialJumpCount = 1;

    // �e�평����
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    BulletBase _bulletBase = default;
    CharacterBase _characterBase = default;
    /// <summary>Cinemachine�̉��z�J����</summary>
    CinemachineVirtualCamera _vcam = default;
    PlayerState _state = PlayerState.Normal;
    float _stateTime = 0;
    // ���������̓��͒l
    float _h = 0;
    float _scaleX = 0;
    bool _lookingRight = true;
    // �W�����v�̓��͒l
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
        //Cinemachine�̃C���X�^���X�̎擾�ƒǐՑΏۂƕߑ��Ώۂ̓o�^
        _vcam = FindAnyObjectByType<CinemachineVirtualCamera>();
        _vcam.m_LookAt = this.gameObject.transform;
        _vcam.m_Follow = this.gameObject.transform;
        PlayerParameterChange();
    }

    // Update is called once per frame
    void Update()
    {
        _h = _inputController.Player.Move.ReadValue<float>(); //���͕�����float�^�Ŏ擾
        //Debug.Log(_inputController.Player.Move.ReadValue<float>());

        if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Slow && (_isGrounded || _jumpCount < _jumpCountLimit))//���������Ƃ𔻒�
        {
            // �W�����v�̗͂�������
            _rb.AddForce(Vector2.up * _jumpPower * _speedReductionRatioOnSlow, ForceMode2D.Impulse);
            _jumpCount++;
            //Debug.Log("�W�����v����");
        }
        else if (_inputController.Player.Jump.triggered && _characterBase.State == CharacterBase.CharacterState.Normal && (_isGrounded || _jumpCount < _jumpCountLimit))//���������Ƃ𔻒�
        {
            // �W�����v�̗͂�������
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _jumpCount++;
            //Debug.Log("�W�����v����");
        }

        // ���͂ɉ����č��E�𔽓]������
        FlipX(_h);
    }

    private void FixedUpdate()
    {
        // ���ړ��̗͂�������̂� FixedUpdate �ōs��
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
         * ������͂��ꂽ��L�����N�^�[�����Ɍ�����B
         * ���E�𔽓]������ɂ́ATransform:Scale:X �� -1 ���|����B
         * Sprite Renderer �� Flip:X �𑀍삵�Ă����]����B
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
        //�摜�t���b�v����
        _sprite.flipX = horizontal < 0;
        //�E�������Ă邩�̃t���O
        _lookingRight = horizontal > 0;
    }

    void PlayerParameterChange()
    {
        int jumpCountChange = 0;

        foreach (Item item in InventoryManager.instance.ItemList)
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
