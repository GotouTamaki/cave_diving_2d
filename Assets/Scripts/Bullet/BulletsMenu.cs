using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsMenu : InputBase
{
    [SerializeField] List<BulletBase> _bullets = new ();
    [SerializeField] float _moveTime = 1f;
    [SerializeField] float _fadeTime = 1f;
    [SerializeField] Image[] _images = null;

    CanvasGroup _canvasGroup;

    void Start()
    {
        _images = GetComponentsInChildren<Image> ();
        _canvasGroup = GetComponent<CanvasGroup> ();
    }

    void Update()
    {
        if (_inputController.Player.BulletChangeL.triggered)// ���������Ƃ𔻒�
        {
            UpdatePosition();
        }
        else if(_inputController.Player.BulletChangeL.WasReleasedThisFrame())
        {
            ResetPosition();
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
            BulletBase bullet = _bullets[i];
            _images[i].sprite = bullet.BulletIcon;
            // �ʒu���Z�b�g
            RectTransform rt = _images[i].rectTransform;
            Vector2 rectPos = rt.anchoredPosition;
            rectPos.x = pos.x;
            rectPos.y = pos.y;
            rt.DOAnchorPos(new Vector2(pos.x, pos.y), _moveTime);
            _canvasGroup.DOFade(1, _fadeTime);
            //rt.anchoredPosition = pos;

            // ���̈ʒu�����v���ɉ�]
            pos = Quaternion.Euler(0, 0, -angle) * rectPos;
        }
    }

    void ResetPosition()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            // �ʒu���Z�b�g
            RectTransform rt = _images[i].rectTransform;
            rt.DOAnchorPos(Vector2.zero, _moveTime);
            _canvasGroup.DOFade(0, _fadeTime);
        }
    }
}
