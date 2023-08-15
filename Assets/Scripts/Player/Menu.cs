using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Menu : InputBase
{
    [SerializeField] GameObject _menuCanvas = null;
    [SerializeField] GameObject _itemPanel = null;
    [SerializeField] GameObject _documentPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        _menuCanvas.SetActive(false);
        //_itemPanel.SetActive(false);
        _documentPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputController.Player.Choice.triggered)
        {
            _menuCanvas.SetActive(!_menuCanvas.activeSelf);
        }
    }
}
