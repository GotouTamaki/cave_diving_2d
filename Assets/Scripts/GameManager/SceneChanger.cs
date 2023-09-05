using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{   
    /// <summary>�t�F�[�h�p�l��</summary>
    [SerializeField] Image _fadePanel = null;
    /// <summary>�t�F�[�h�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 5f;
    ///// <summary>�t�F�[�h���[�h 0���t�F�[�h�C��1���t�F�[�h�A�E�g</summary>
    //[Tooltip("�t�F�[�h���[�h\n0���t�F�[�h�C��1���t�F�[�h�A�E�g")]
    //[SerializeField] int _fadeMode = 0;

    /// <summary>�����ɓ��͂��ꂽ���O�̃V�[���ɑJ�ڂ��܂�</summary>
    /// <param name="sceneName">�J�ڂ���V�[���̖��O</param>
    public void SceneChangeFade(string sceneName)
    {
        _fadePanel.gameObject.SetActive(true);
        _fadePanel.DOFade(1, _interval).OnComplete(() => SceneManager.LoadScene(sceneName));
    }   
}
