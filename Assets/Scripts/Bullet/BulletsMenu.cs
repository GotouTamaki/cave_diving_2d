using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

public class BulletsMenu : InputBase
{
    [SerializeField] List<BulletBase> _bullets = new List<BulletBase>();
    [SerializeField] List<Image> _images = new List<Image>();

    void Start()
    {

    }

    void Update()
    {
        if (_inputController.Player.BulletChangeL.triggered)// ���������Ƃ𔻒�
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // �摜�̊Ԋu
        float angle = 360f / _bullets.Count;

        // �^��̈ʒu
        Vector2 pos = Vector2.up * 150f;

        for (int i = 0; i < _bullets.Count; i++)
        {
            // �ʒu���Z�b�g
            RectTransform rt = _images[i].rectTransform;
            Vector2 rectPos = rt.anchoredPosition;
            rectPos.x = pos.x;
            rectPos.y = pos.y;
            rt.anchoredPosition = pos;

            // ���̈ʒu�����v���ɉ�]
            pos = Quaternion.Euler(0, 0, -angle) * pos;
        }
    }
}
