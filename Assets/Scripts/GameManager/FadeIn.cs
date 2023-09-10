using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeIn : MonoBehaviour
{
    /// <summary>フェードパネル</summary>
    [SerializeField] Image _fadePanel = null;
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;
    /// <summary>フェードモード 0がフェードイン1がフェードアウト</summary>
    //[Tooltip("フェードモード\n0がフェードイン1がフェードアウト")]
    //[SerializeField] int _fadeMode = 0;

    void Start()
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(0, _interval).OnComplete(() => _fadePanel.gameObject.SetActive(false));
    }
}
