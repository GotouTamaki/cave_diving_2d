using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] Text _hpText = null;

    GameObject _player = null;
    float _maxHp = 1;
    float _hp = 1;

    public void PlayerHPDisplaySet()
    {
        _hpText = GetComponent<Text>();
        // �v���C���[���擾����
        _player = GameObject.FindWithTag("Player");
        _maxHp = _player.GetComponent<CharacterBase>().CharacterMaxHp;
        _hp = _player.GetComponent<CharacterBase>().CharacterHp;
        StartCoroutine(PlayerHPDisplay());
    }

    IEnumerator PlayerHPDisplay()
    {
        while (true)
        {
            if (_player == null)
            {
                _hp = 0;
                // HP�̕\��
                _hpText.text = "HP:" + _hp.ToString("F0");
                break;
            }

            // HP�̎擾
            if (_hp >= 0)
            {
                _hp = _player.GetComponent<CharacterBase>().CharacterHp;
            }

            // HP�̐F�ύX�̏���
            if (_hp <= _maxHp / 5 || _hp <= 1)
            {
                _hpText.color = Color.red;
            }
            else if (_hp <= _maxHp / 2)
            {
                _hpText.color = Color.yellow;
            }
            else
            {
                _hpText.color = Color.white;
            }

            // HP�̕\��
            _hpText.text = "HP:" + _hp.ToString("F0");
            yield return new WaitForEndOfFrame();
        }
    }
}