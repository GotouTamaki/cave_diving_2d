using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] Text _hpText = null;
    //[SerializeField] Text _maxHpText = null;
    [SerializeField] float _maxHp = 1;
    [SerializeField] float _hp = 1;
    [SerializeField] GameObject _player = null;

    // Start is called before the first frame update
    void Start()
    {
        _hpText = GetComponent<Text>();
        _maxHp = _player.GetComponent<CharacterBase>().CharacterMaxHp;
        _hp = _player.GetComponent<CharacterBase>().CharacterHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hp > 0) 
        {
            _hp = _player.GetComponent<CharacterBase>().CharacterHp;
        }

        if (_hp <= _maxHp / 10) 
        {
            _hpText.color = Color.red;
        }
        else if ( _hp <= _maxHp / 2) 
        {
            _hpText.color = Color.yellow;
        }
        else
        {
            _hpText.color = Color.white;
        }

        _hpText.text = "HP:" + _hp.ToString("F0");
    }
}
