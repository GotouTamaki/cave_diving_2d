using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] Text _hpText = null;
    [SerializeField] float _hp = 1;
    [SerializeField] GameObject _player = null;

    // Start is called before the first frame update
    void Start()
    {
        _hpText = GetComponent<Text>();
        _hp = _player.GetComponent<CharacterBase>().CharacterHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp > 0) 
        {
            _hp = _player.GetComponent<CharacterBase>().CharacterHp;
        }

        _hpText.text = "HP:" + _hp.ToString("F0");
    }
}
