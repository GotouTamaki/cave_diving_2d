using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public abstract class InputBase : MonoBehaviour
{
    //’Ç‰Á«
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
        // InputAction‚ğ—LŒø‰»
        // ‚±‚ê‚ğ‚µ‚È‚¢‚Æ“ü—Í‚ğó‚¯æ‚ê‚È‚¢‚±‚Æ‚É’ˆÓ
        _action?.Enable();
    }
    //‚±‚±‚Ü‚Å
}
