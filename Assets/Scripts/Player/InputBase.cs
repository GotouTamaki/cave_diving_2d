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

    // —LŒø‰»
    private void OnEnable()
    {
        // InputAction‚ð—LŒø‰»
        // ‚±‚ê‚ð‚µ‚È‚¢‚Æ“ü—Í‚ðŽó‚¯Žæ‚ê‚È‚¢
        _action?.Enable();
    }
}
