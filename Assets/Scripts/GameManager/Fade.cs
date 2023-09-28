using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    /// <summary>フェードパネル</summary>
    [SerializeField] CanvasGroup _fadeCanvas = null;
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;
    /// <summary>フェードモード 0がフェードイン1がフェードアウト</summary>
    [Tooltip("フェードモード\n0がフェードイン1がフェードアウト")]
    [SerializeField] int _fadeMode = 0;

    void Start()
    {
        //_fadeCanvas.gameObject.SetActive(true);
        _fadeCanvas.DOFade(_fadeMode, _interval);
    }
}
