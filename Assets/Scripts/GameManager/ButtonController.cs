using System;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void CanvasActiveTrue(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void CanvasActiveFalse(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void GameExit()
    {
        Application.Quit();//ゲームプレイ終了
    }
}
