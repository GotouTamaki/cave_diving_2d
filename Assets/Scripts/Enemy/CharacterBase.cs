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
    // ���E�ړ������
    [SerializeField] float _moveSpeed = 5f;
    // �W�����v�����
    [SerializeField] float _jumpPower = 15f;
    /// <summary>�R�ď�Ԃ̎��ɂǂꂭ�炢���C�t�����邩</summary>
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    /// <summary>���x�ቺ�̎��ɂǂꂭ�炢�ړ����x�������邩</summary>
    [SerializeField] float _speedReductionRatioOnSlow = 0.5f;

    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    CharacterState _state = CharacterState.Normal;
    float _stateTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��������
        if (_hp <= 0)
        {
            _state = CharacterState.Dead;
        }

        // ��Ԉُ�
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
            Debug.Log("���ꂽ�I");
            //if (�|���ꂽ�Ƃ��p�̃v���n�u)
            //{
            //    Instantiate(�|���ꂽ�Ƃ��p�̃v���n�u, this.transform.position, �|���ꂽ�Ƃ��p�̃v���n�u.transform.rotation);
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
        set { _state = value; }
    }

    public float StateTime
    {
        get { return _stateTime; }
        set { _stateTime = value; }
    }
}
