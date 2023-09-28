using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    /// <summary>�t�F�[�h�p�l��</summary>
    [SerializeField] CanvasGroup _fadeCanvas = null;
    /// <summary>�t�F�[�h�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 5f;
    /// <summary>�t�F�[�h���[�h 0���t�F�[�h�C��1���t�F�[�h�A�E�g</summary>
    [Tooltip("�t�F�[�h���[�h\n0���t�F�[�h�C��1���t�F�[�h�A�E�g")]
    [SerializeField] int _fadeMode = 0;

    void Start()
    {
        //_fadeCanvas.gameObject.SetActive(true);
        _fadeCanvas.DOFade(_fadeMode, _interval);
    }
}
