using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

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

    // �L����
    private void OnEnable()
    {
        // InputAction��L����
        // ��������Ȃ��Ɠ��͂��󂯎��Ȃ�
        _action?.Enable();
    }
}