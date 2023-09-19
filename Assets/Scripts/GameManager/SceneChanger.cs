using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    /// <summary>フェードインパネル</summary>
    [SerializeField] Image _fadePanel = null;
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;

    /// <summary>引数に入力された名前のシーンに遷移します</summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    public void SceneChangeFade(string sceneName)
    {
        // フェードモード 0がフェードイン 1がフェードアウト
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
                _fadePanel.DOFade(0, _interval).OnComplete(() => _fadePanel.gameObject.SetActive(false));
            });
    }

    public void SceneResetFade(string sceneName)
    {
        // フェードモード 0がフェードイン 1がフェードアウト
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                _fadePanel.DOFade(0, _interval).OnComplete(() => _fadePanel.gameObject.SetActive(false));
            });
    }
}
