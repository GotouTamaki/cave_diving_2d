using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsMenu : InputBase
{
    [SerializeField] List<BulletBase> _bullets = new();
    [SerializeField] float _moveTime = 1f;
    [SerializeField] float _fadeTime = 1f;
    [SerializeField] RectTransform[] _rectPositions = null;
    [SerializeField] Image[] _icons = null;

    CanvasGroup _canvasGroup;

    void Start()
    {
        _rectPositions = new RectTransform[_bullets.Count];
        _icons = new Image[_bullets.Count];
        //_images = GetComponentsInChildren<Image> ();
        _canvasGroup = GetComponent<CanvasGroup>();
        for (int i = 0; i < _bullets.Count; i++)
        {
            _rectPositions[i] = transform.GetChild(i).GetComponent<RectTransform>();
            _icons[i] = transform.GetChild(i).GetChild(1).GetComponent<Image>();
        }
    }

    void Update()
    {
        if (_inputController.Player.BulletChangeL.triggered)// 押したことを判定
        {
            UpdatePosition();
        }
        else if (_inputController.Player.BulletChangeL.WasReleasedThisFrame())
        {
            ResetPosition();
        }
    }

    void UpdatePosition()
    {
        // 画像の間隔
        float angle = 360f / _bullets.Count;

        // 真上の位置
        Vector2 pos = Vector2.up * 150f;
        //RectTransform[] _rectTransform = this.gameObject.GetComponentInChildren<RectTransform>();

        for (int i = 0; i < _bullets.Count; i++)
        {
            // アイコンをセット
            BulletBase bullet = _bullets[i];
            _icons[i].sprite = bullet.BulletIcon;
            // 位置をセット
            RectTransform rt = _rectPositions[i];
            Vector2 rectPos = rt.anchoredPosition;
            rectPos.x = pos.x;
            rectPos.y = pos.y;
            rt.DOAnchorPos(new Vector2(pos.x, pos.y), _moveTime);
            _canvasGroup.DOFade(1, _fadeTime);
            //rt.anchoredPosition = pos;

            // 次の位置を時計回りに回転
            pos = Quaternion.Euler(0, 0, -angle) * rectPos;
        }
    }

    void ResetPosition()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            // 位置をセット
            RectTransform rt = _rectPositions[i];
            rt.DOAnchorPos(Vector2.zero, _moveTime);
            _canvasGroup.DOFade(0, _fadeTime);
        }
    }

    public void ButtonTest()
    {
        Debug.Log("押せた");
    }
}
