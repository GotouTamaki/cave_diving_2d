using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] int _clearTerms = 0;
    [SerializeField] CanvasGroup _canvasGroup = null;
    [SerializeField] DungeonMapGenerator _dungeon = null;

    void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        if(DDOLController.instance.Inventory.ClearCount >= _dungeon.KeyItemLimit)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}
