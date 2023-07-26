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
    [SerializeField] float _maxHp = 1;
    [SerializeField] float _hp = 1;
    // ���E�ړ������
    [SerializeField] float _moveSpeed = 5f;
    // �W�����v�����
    [SerializeField] float _jumpPower = 15f;
    /// <summary>�R�ď�Ԃ̎��ɂǂꂭ�炢���C�t�����邩</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>���x�ቺ�̎��ɂǂꂭ�炢�ړ����x�������邩</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;

    // �e�평����
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    BulletBase _bulletBase = default;
    PlayerState _state = PlayerState.Normal;
    float _stateTime = 0;
    // ���������̓��͒l
    float _h = 0;
    float _scaleX = 0;
    bool _lookingRight = true;
    // �W�����v�̓��͒l
    float _jumpCount = 0;
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
        //Debug.Log(_inputController.Player.Move.ReadValue<float>());

        _stateTime -= Time.deltaTime;

        if (_stateTime < 0) 
        {
            _state = PlayerState.Normal;
            _stateTime = 0;
            //Debug.Log("�m�[�}���I");
        }

        if (_inputController.Player.Jump.triggered && _state == PlayerState.Slow && _isGrounded)//���������Ƃ𔻒�
        {
            // �W�����v�̗͂�������
            _rb.AddForce(Vector2.up * _jumpPower * _speedReductionRatioOnSlow, ForceMode2D.Impulse);
            //Debug.Log("�W�����v����");
        }
        else if (_inputController.Player.Jump.triggered && _state == PlayerState.Normal && _isGrounded)//���������Ƃ𔻒�
        {
            // �W�����v�̗͂�������
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            //Debug.Log("�W�����v����");
        }

        _axis = _inputController.Player.Move.ReadValue<float>();//���͕�����float�^�Ŏ擾

        // ���͂ɉ����č��E�𔽓]������   
        FlipX(_h);
        
        // ��Ԉُ�
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
        if (collision.gameObject.tag == "Item" && _inputController.Player.Choice.triggered)
        {
            collision.GetComponent<ItemBase>().Item();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item" && _inputController.Player.Choice.triggered)
        {
            other.GetComponent<ItemBase>().Item();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
    }

    public float PlayerHp
    {
        get { return _hp; }
        set { _hp = value; }
    }

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

    public float StateTime
    {
        get { return _stateTime; }
        set { _stateTime = value; }
    }
}
