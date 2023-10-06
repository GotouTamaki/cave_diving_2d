using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemGetUI : MonoBehaviour
{
    //[SerializeField] float _xPosi = 0f;
    //[SerializeField] float _yPosi = 0f;
    [SerializeField] float fadeoutTime = 1f; // 完全に透明になるまでにかかる時間(秒)
    [SerializeField] float fadeoutStartTime = 5f; // 透明化が始まるまでにかかる時間(秒)
    //[SerializeField] float _moveTime = 3f;
    //[SerializeField] float _waitTime = 3f;

    Image _panel = null;
    Text _text = null;
    private int textCount; // 子オブジェクト(Text)の数
    private Text[] logText;
    private TextProperty[] _textProperty;

    //private void OnEnable()
    //{
    //    _panel = GetComponent<Image>();
    //    _text = GetComponent<Text>();
    //    DOTween.Sequence()
    //        .Append(transform.DOMoveX(_xPosi, _moveTime))
    //        .AppendInterval(_waitTime)
    //        .Append(transform.DOMoveY(_yPosi, _moveTime));

    //}

    private void Start()
    {
        textCount = transform.childCount;
        logText = new Text[textCount];
        _textProperty = new TextProperty[textCount];
        for (int i = 0; i < textCount; i++)
        {
            logText[i] = transform.GetChild(i).GetComponent<Text>();
            logText[i].color = new Color(logText[i].color.r, logText[i].color.g, logText[i].color.b, 0f);
            _textProperty[i].AlfaSet = 0f;
            _textProperty[i].ElapsedTime = 0f;
        }
    }

    void Update()
    {
        // 一番上のテキストは強制的に透明化開始させる
        if (_textProperty[0].AlfaSet == 1)
        {
            _textProperty[0].ElapsedTime = fadeoutStartTime;
        }

        for (int i = textCount - 1; i >= 0; i--)
        {
            if (_textProperty[i].AlfaSet > 0)
            {
                // 経過時間がfadeoutStartTime未満なら時間をカウント
                // そうでなければ透明度を下げる
                if (_textProperty[i].ElapsedTime < fadeoutStartTime)
                {
                    _textProperty[i].ElapsedTime += Time.deltaTime;
                }
                else
                {
                    _textProperty[i].AlfaSet -= Time.deltaTime / fadeoutTime;
                    logText[i].color = new Color(logText[i].color.r, logText[i].color.g, logText[i].color.b,
                                       _textProperty[i].AlfaSet);
                }
            }
            else
            {
                break;
            }
        }
    }
    // ログ出力
    public void OutputLog(string itemName)
    {
        if (_textProperty[textCount - 1].AlfaSet > 0)
        {
            UpLogText();
        }
        logText[textCount - 1].text = itemName + "を手に入れた"; // ここの文字列を変えればログの文章が変わります
        ResetTextPropety();
    }
    // ログを一つ上にずらす
    private void UpLogText()
    {
        // 古いほうからずらす
        for (int i = 0; i < textCount - 1; i++)
        {
            logText[i].text = logText[i + 1].text;
            _textProperty[i].AlfaSet = _textProperty[i + 1].AlfaSet;
            _textProperty[i].ElapsedTime = _textProperty[i + 1].ElapsedTime;
            logText[i].color = new Color(logText[i].color.r, logText[i].color.g, logText[i].color.b,
                               _textProperty[i].AlfaSet);
        }
    }
    // ログの初期化
    private void ResetTextPropety()
    {
        _textProperty[textCount - 1].AlfaSet = 1f;
        _textProperty[textCount - 1].ElapsedTime = 0f;
        logText[textCount - 1].color = new Color(logText[textCount - 1].color.r, logText[textCount - 1].color.g, logText[textCount - 1].color.b,
                                       _textProperty[textCount - 1].AlfaSet);
    }
    struct TextProperty
    {
        private float _alfa;
        public float AlfaSet // 透明度、0未満なら0にする
        {
            get
            {
                return _alfa;
            }
            set
            {
                _alfa = value < 0 ? 0 : value;
            }
        }
        public float ElapsedTime { get; set; } // ログが出力されてからの経過時間
    }
}
