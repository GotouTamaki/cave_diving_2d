using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

/// <summary>InputSystemの入力を受け取れるようにするスクリプト</summary>
public abstract class InputBase : MonoBehaviour
{    
    public InputController _inputController;
    InputAction _action;    

    private void Awake()
    {
        _inputController = new InputController();
        _inputController.Enable();
    }

    private void OnDestroy()
    {
        _inputController?.Dispose();
    }

    // 有効化
    private void OnEnable()
    {
        // InputActionを有効化
        // これをしないと入力を受け取れない
        _action?.Enable();
    }
}
