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
    PlayerState _state = PlayerState.Normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
