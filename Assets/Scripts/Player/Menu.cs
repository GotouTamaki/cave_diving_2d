using UnityEngine;

public class Menu : InputBase
{
    /// <summary>���j���[�p�̃I�u�W�F�N�g</summary>
    [SerializeField] GameObject _menuCanvas = null;

    void Start()
    {
        // ��\���ɂ���
        _menuCanvas.SetActive(false);
    }

    void Update()
    {
        // ����̂̃L�[���������Ƃ��ɕ\����؂�ւ���
        if(_inputController.Player.Choice.triggered)
        {
            _menuCanvas.SetActive(!_menuCanvas.activeSelf);
        }
    }
}
