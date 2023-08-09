using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    [SerializeField] Text _hpText = null;
    [SerializeField] float _hp = 1;
    [SerializeField] CharacterBase _player = null;

    // Start is called before the first frame update
    void Start()
    {
        _hpText = GetComponent<Text>();
        _player = GetComponent<CharacterBase>();
        _hp = _player.CharacterHp;
    }

    // Update is called once per frame
    void Update()
    {
        _hp = _player.CharacterHp;
        _hpText.text = _hp.ToString($"HP : {_hp}");
    }
}
