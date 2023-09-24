using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : InputBase
{
    CanvasGroup _canvasGroup = null;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        // ��\���ɂ���
        CanvasActiveSet(_canvasGroup, false);
    }

    void Update()
    {
        // ����̂̃L�[���������Ƃ��ɕ\����؂�ւ���
        if (_inputController.Player.Choice.triggered && SceneManager.GetActiveScene().name != ("TitleScene"))
        {
            CanvasActiveSet(_canvasGroup, !_canvasGroup.interactable);
        }
    }

    public void CanvasActiveSet(CanvasGroup canvasGroup, bool active)
    {
        if (active)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
