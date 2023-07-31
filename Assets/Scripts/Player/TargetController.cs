using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : InputBase
{
    /// <summary>�^�[�Q�b�g�J�[�\���̈ړ��̔{��</summary>
    [SerializeField] float _magnification = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = Vector2.right * _magnification;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = _inputController.Player.PointCannonStick.ReadValue<Vector2>();

        // ���͂������Ƃ��͈ʒu���ێ�����
        if (input == Vector2.zero) 
        {
            this.transform.localPosition = this.transform.localPosition;
        }
        else 
        {
            this.transform.localPosition = input * _magnification;
        }       
    }
}
