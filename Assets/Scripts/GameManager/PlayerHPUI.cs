using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] Slider _hpSlider = null;
    [SerializeField] Image _hpBar = null;

    GameObject _player = null;
    float _maxHp = 1;
    float _hp = 1;

    public void PlayerHPDisplaySet()
    {
        //_hpSlider = GetComponent<Slider>();
        // �v���C���[���擾����
        _player = GameObject.FindWithTag("Player");
        _hpSlider.maxValue = _player.GetComponent<CharacterBase>().CharacterMaxHp;
        _hpSlider.value = _player.GetComponent<CharacterBase>().CharacterHp;
        StartCoroutine(PlayerHPDisplay());
    }

    IEnumerator PlayerHPDisplay()
    {
        while (true)
        {
            if (_player == null)
            {
                // HP�̕\��
                _hpSlider.value = 0;
                GameObject.FindObjectOfType<GameOver>().OnGameOver();
                break;
            }

            // HP�̎擾
            if (_hpSlider.value >= 0)
            {
                // HP�̕\��
                _hpSlider.value = _player.GetComponent<CharacterBase>().CharacterHp;
            }

            // HP�̐F�ύX�̏���
            if (_hpSlider.value <= _hpSlider.maxValue / 5)
            {
                _hpBar.color = Color.red;
            }
            else if (_hpSlider.value <= _hpSlider.maxValue / 2)
            {
                _hpBar.color = Color.yellow;
            }
            else
            {
                _hpBar.color = Color.green;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
