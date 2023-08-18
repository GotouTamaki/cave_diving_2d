using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : InputBase
{
    [SerializeField] GameObject _menuCanvas = null;
    [SerializeField] GameObject _menuButtonCanvas = null;

    // Start is called before the first frame update
    void Start()
    {
        _menuCanvas.SetActive(false);
        _menuButtonCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputController.Player.Choice.triggered)
        {
            _menuCanvas.SetActive(!_menuCanvas.activeSelf);
            _menuButtonCanvas.SetActive(!_menuButtonCanvas.activeSelf);
        }
    }
}
