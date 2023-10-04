using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemGetUI : MonoBehaviour
{
    [SerializeField] float _xPosi = 0f;
    [SerializeField] float _yPosi = 0f;
    [SerializeField] float _moveTime = 3f;
    [SerializeField] float _waitTime = 3f;

    Image _panel = null;
    Text _text = null;

    private void OnEnable()
    {
        _panel = GetComponent<Image>();
        _text = GetComponent<Text>();
        DOTween.Sequence()
            .Append(transform.DOMoveX(_xPosi, _moveTime))
            .AppendInterval(_waitTime)
            .Append(transform.DOMoveY(_yPosi, _moveTime));

    }
}
