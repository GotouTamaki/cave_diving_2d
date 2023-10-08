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
        if (_inputController.Player.BulletChangeL.triggered)// 押したことを判定
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // 画像の間隔
        float angle = 360f / _bullets.Count;

        // 真上の位置
        Vector2 pos = Vector2.up * 150f;

        for (int i = 0; i < _bullets.Count; i++)
        {
            // 位置をセット
            RectTransform rt = _images[i].rectTransform;
            Vector2 rectPos = rt.anchoredPosition;
            rectPos.x = pos.x;
            rectPos.y = pos.y;
            rt.anchoredPosition = pos;

            // 次の位置を時計回りに回転
            pos = Quaternion.Euler(0, 0, -angle) * pos;
        }
    }
}
