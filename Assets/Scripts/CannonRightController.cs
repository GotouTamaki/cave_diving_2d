using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonRightController : InputBase
{
    [SerializeField] Transform _muzzle = null;
    [SerializeField] GameObject[] _bullet = null;

    public float _interval = 1f;
    float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputController.Player.FireRight.triggered)//‰Ÿ‚µ‚½‚±‚Æ‚ð”»’è
        {
            Debug.Log("‰E–C”­ŽË");
        }
    }
}
