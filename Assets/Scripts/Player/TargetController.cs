using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : InputBase
{
    /// <summary>�^�[�Q�b�g�J�[�\���̈ړ��̔{��</summary>
    [SerializeField] float _magnification = 1f;   

    Vector2 _pos = Vector2.zero;
    bool _canLook = false;
    bool _isLook = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = Vector2.right * _magnification;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _inputController.Player.PointCannonStick.ReadValue<Vector2>();
        //Vector2 input = _inputController.Player.PointCannonMouse.ReadValue<Vector2>();
        //_pos = this.transform.localPosition;

        // ���͂������Ƃ��͈ʒu���ێ�����
        if (input == Vector2.zero) 
        {
            this.transform.localPosition = this.transform.localPosition;
        }
        else 
        {
            this.transform.localPosition = input * _magnification;
            //this.transform.position = input;
        }

        //float dirX = this.transform.localPosition.x - input.x * _magnification;
        //float dirY = this.transform.localPosition.y - input.y * _magnification;

        //if (dirX != 0 && dirY != 0)
        //{
        //    _pos.x += dirX * 0.1f;
        //    _pos.y += dirY * 0.1f;
        //}

        if (_inputController.Player.PointResetStick.triggered && !_canLook)
        {
            this.transform.localPosition = Vector2.right * _magnification;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //_canLook = true;
        //Debug.Log(_canLook);

        //if (_inputController.Player.PointResetStick.triggered && !_isLook)
        //{
        //    this.transform.position = collision.transform.position;
        //    _isLook = true;
        //}
        //else if (_inputController.Player.PointResetStick.triggered && _isLook)
        //{
        //    this.transform.localPosition = Vector2.right * _magnification;
        //    _isLook = false;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //_canLook = false;
        //_isLook = false;
    }
}