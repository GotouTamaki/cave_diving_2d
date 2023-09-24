using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    /// <summary>フェードのインターバル</summary>
    [SerializeField] float _interval = 5f;

    /// <summary>引数に入力された名前のシーンに遷移します</summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    public void SceneChangeFade(string sceneName)
    {
        // フェードパネルの取得(非アクティブ状態なため、親オブジェクトから探す)
        GameObject fadePanelParent = GameObject.FindWithTag("FadePanel");
        // フェードパネルの取得
        Image fadePanel = fadePanelParent.transform.Find("FadePanel").gameObject.GetComponent<Image>();
        // メニュー画面の取得
        Menu menu = GameObject.FindWithTag("Menu").GetComponent<Menu>();
        // メニュー画面を非表示にする
        menu.CanvasActiveSet(menu.GetComponent<CanvasGroup>(), false);
        // フェードモード 0がフェードイン 1がフェードアウト
        fadePanel.gameObject.SetActive(true);
        fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                // シーンを再読み込みする
                SceneManager.LoadScene(sceneName);
                // メニュー画面を非表示にする
                menu.CanvasActiveSet(menu.GetComponent<CanvasGroup>(), false);
                // フェードインさせる
                fadePanel.DOFade(0, _interval).OnComplete(() => fadePanel.gameObject.SetActive(false));
            });
    }

    public void SceneResetFade()
    {
        // フェードパネルの取得(非アクティブ状態なため、親オブジェクトから探す)
        GameObject parentGameObject = GameObject.FindWithTag("FadePanel");
        // フェードパネルの取得
        Image fadePanel = parentGameObject.transform.Find("FadePanel").gameObject.GetComponent<Image>();
        // フェードモード 0がフェードイン 1がフェードアウト
        fadePanel.gameObject.SetActive(true);
        // メニュー画面の取得
        Menu menu = GameObject.FindWithTag("Menu").GetComponent<Menu>();
        // メニュー画面を非表示にする
        menu.CanvasActiveSet(menu.GetComponent<CanvasGroup>(), false);
        // フェードアウト
        fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                // シーンを再読み込みする
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // メニュー画面を非表示にする
                menu.CanvasActiveSet(menu.GetComponent<CanvasGroup>(), false);
                // フェードインさせる
                fadePanel.DOFade(0, _interval).OnComplete(() => fadePanel.gameObject.SetActive(false));
            });
    }
}
