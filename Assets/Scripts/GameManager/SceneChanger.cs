using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{   
    /// <summary>フェードパネル</summary>
    [SerializeField] Image _fadePanel = null;
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;
    ///// <summary>フェードモード 0がフェードイン1がフェードアウト</summary>
    //[Tooltip("フェードモード\n0がフェードイン1がフェードアウト")]
    //[SerializeField] int _fadeMode = 0;

    /// <summary>引数に入力された名前のシーンに遷移します</summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    public void SceneChangeFade(string sceneName)
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(sceneName));
    }   
}
