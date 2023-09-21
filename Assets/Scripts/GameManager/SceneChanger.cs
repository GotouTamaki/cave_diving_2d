using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    /// <summary>�t�F�[�h�̃C���^�[�o��</summary>
    [SerializeField] float _interval = 5f;

    /// <summary>�����ɓ��͂��ꂽ���O�̃V�[���ɑJ�ڂ��܂�</summary>
    /// <param name="sceneName">�J�ڂ���V�[���̖��O</param>
    public void SceneChangeFade(string sceneName)
    {
        // �t�F�[�h�p�l���̎擾(��A�N�e�B�u��ԂȂ��߁A�e�I�u�W�F�N�g����T��)
        GameObject fadePanelParent = GameObject.FindWithTag("FadePanel");
        // �t�F�[�h�p�l���̎擾
        Image fadePanel = fadePanelParent.transform.Find("FadePanel").gameObject.GetComponent<Image>();
        // �t�F�[�h���[�h 0���t�F�[�h�C�� 1���t�F�[�h�A�E�g
        fadePanel.gameObject.SetActive(true);
        fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
                fadePanel.DOFade(0, _interval).OnComplete(() => fadePanel.gameObject.SetActive(false));
            });
    }

    public void SceneResetFade()
    {
        // �t�F�[�h�p�l���̎擾(��A�N�e�B�u��ԂȂ��߁A�e�I�u�W�F�N�g����T��)
        GameObject parentGameObject = GameObject.FindWithTag("FadePanel");
        // �t�F�[�h�p�l���̎擾
        Image fadePanel = parentGameObject.transform.Find("FadePanel").gameObject.GetComponent<Image>();
        // �t�F�[�h���[�h 0���t�F�[�h�C�� 1���t�F�[�h�A�E�g
        fadePanel.gameObject.SetActive(true);
        fadePanel.DOFade(1, _interval)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                fadePanel.DOFade(0, _interval).OnComplete(() => fadePanel.gameObject.SetActive(false));
            });
    }
}
