using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : InputBase
{
    [SerializeField] float _maxHp = 1;
    [SerializeField] float _hp = 1;
    // ���E�ړ������
    [SerializeField] float _moveSpeed = 5f;
    // �W�����v�����
    [SerializeField] float _jumpPower = 15f;
    // ���͂ɉ����č��E�𔽓]�����邩�ǂ����̃t���O
    [SerializeField] bool _flipX = false;
    /// <summary>�R�ď�Ԃ̎��ɂǂꂭ�炢���C�t�����邩</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>���x�ቺ�̎��ɂǂꂭ�炢�ړ����x�������邩</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;


    // �e�평����
   
    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    PlayerState _state = PlayerState.Normal;
    // ���������̓��͒l
    float _h;
    // �W�����v�̓��͒l
    float _j;
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
            //Debug.Log("�ړ�����");

        if (_inputController.Player.Jump.triggered && _isGrounded)//���������Ƃ𔻒�
        {
            // �W�����v�̗͂�������
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            //Debug.Log("�W�����v����");
        }

        _axis = _inputController.Player.Move.ReadValue<float>();//���͕�����float�^�Ŏ擾

        // ��Ԉُ�
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
        // ���ړ��̗͂�������̂� FixedUpdate �ōs��
        _rb.AddForce(Vector2.right * _h * _moveSpeed, ForceMode2D.Force);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            _isGrounded = false;
        }
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
