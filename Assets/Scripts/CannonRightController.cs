using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class CannonRightController : InputBase
{
    [SerializeField] Transform _muzzle = null;
    [SerializeField] List<GameObject> _bullet = new List<GameObject>();
    [SerializeField] int _bulletType = 0;

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
        if (_inputController.Player.BulletChangeR.triggered)//‰Ÿ‚µ‚½‚±‚Æ‚ð”»’è
        {
            Debug.Log(_bulletType);
            if (_bulletType >= 5)
            {
                _bulletType = 0;
            }
            else
            {
                ++_bulletType;
            }

        }

            if (_inputController.Player.FireRight.triggered)//‰Ÿ‚µ‚½‚±‚Æ‚ð”»’è
        {
            Instantiate(_bullet[_bulletType], _muzzle.position, _muzzle.rotation);
            Debug.Log("‰E–C”­ŽË");
        }
    }
}
