using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    /// <summary>フェードインパネル</summary>
    [SerializeField] Image _fadeInPanel = null;
    /// <summary>フェードアウトパネル</summary>
    [SerializeField] Image _fadeOutPanel = null;
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;
    ///// <summary>フェードモード 0がフェードイン1がフェードアウト</summary>
    //[Tooltip("フェードモード\n0がフェードイン1がフェードアウト")]
    //[SerializeField] int _fadeMode = 0;

    /// <summary>引数に入力された名前のシーンに遷移します</summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    public void SceneChangeFade(string sceneName)
    {
        _fadeInPanel.gameObject.SetActive(true);
        _fadeInPanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
                _fadeInPanel.gameObject.SetActive(true);
                _fadeInPanel.DOFade(0, _interval).OnComplete(() => _fadeInPanel.gameObject.SetActive(false));
            });
    }
}
