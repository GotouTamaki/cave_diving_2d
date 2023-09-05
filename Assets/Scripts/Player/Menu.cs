using UnityEngine;

public class Menu : InputBase
{
    /// <summary>メニュー用のオブジェクト</summary>
    [SerializeField] GameObject _menuCanvas = null;

    void Start()
    {
        // 非表示にする
        _menuCanvas.SetActive(false);
    }

    void Update()
    {
        // 特定ののキーををしたときに表示を切り替える
        if(_inputController.Player.Choice.triggered)
        {
            _menuCanvas.SetActive(!_menuCanvas.activeSelf);
        }
    }
}
