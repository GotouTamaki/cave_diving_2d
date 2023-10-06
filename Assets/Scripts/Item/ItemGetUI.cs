using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemGetUI : MonoBehaviour
{
    //[SerializeField] float _xPosi = 0f;
    //[SerializeField] float _yPosi = 0f;
    [SerializeField] float fadeoutTime = 1f; // ���S�ɓ����ɂȂ�܂łɂ����鎞��(�b)
    [SerializeField] float fadeoutStartTime = 5f; // ���������n�܂�܂łɂ����鎞��(�b)
    //[SerializeField] float _moveTime = 3f;
    //[SerializeField] float _waitTime = 3f;

    Image _panel = null;
    Text _text = null;
    private int textCount; // �q�I�u�W�F�N�g(Text)�̐�
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
        // ��ԏ�̃e�L�X�g�͋����I�ɓ������J�n������
        if (_textProperty[0].AlfaSet == 1)
        {
            _textProperty[0].ElapsedTime = fadeoutStartTime;
        }

        for (int i = textCount - 1; i >= 0; i--)
        {
            if (_textProperty[i].AlfaSet > 0)
            {
                // �o�ߎ��Ԃ�fadeoutStartTime�����Ȃ玞�Ԃ��J�E���g
                // �����łȂ���Γ����x��������
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
    // ���O�o��
    public void OutputLog(string itemName)
    {
        if (_textProperty[textCount - 1].AlfaSet > 0)
        {
            UpLogText();
        }
        logText[textCount - 1].text = itemName + "����ɓ��ꂽ"; // �����̕������ς���΃��O�̕��͂��ς��܂�
        ResetTextPropety();
    }
    // ���O�����ɂ��炷
    private void UpLogText()
    {
        // �Â��ق����炸�炷
        for (int i = 0; i < textCount - 1; i++)
        {
            logText[i].text = logText[i + 1].text;
            _textProperty[i].AlfaSet = _textProperty[i + 1].AlfaSet;
            _textProperty[i].ElapsedTime = _textProperty[i + 1].ElapsedTime;
            logText[i].color = new Color(logText[i].color.r, logText[i].color.g, logText[i].color.b,
                               _textProperty[i].AlfaSet);
        }
    }
    // ���O�̏�����
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
        public float AlfaSet // �����x�A0�����Ȃ�0�ɂ���
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
        public float ElapsedTime { get; set; } // ���O���o�͂���Ă���̌o�ߎ���
    }
}
