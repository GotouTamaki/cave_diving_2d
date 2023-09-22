using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCanvas = null;

    public void Start()
    {
        _gameOverCanvas.SetActive(false);
    }

    public void OnGameOver()
    {
        _gameOverCanvas.SetActive(true);
    }
}
