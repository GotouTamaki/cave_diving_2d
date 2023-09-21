using UnityEngine;

public class BulletHookController : BulletBase
{
    [SerializeField] float _springPower = 5f;
    [SerializeField] Color _lineColor = Color.white;

    GameObject _player = null;
    Rigidbody2D _playerRb = null;
    LineRenderer _line = null;
    Vector2 _initialPosition = Vector2.zero;

    private void Start()
    {
        // �v���C���[���擾
        _player = GameObject.FindWithTag("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
        // LineRenderer�̐ݒ�
        _line = GetComponent<LineRenderer>();
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.positionCount = 2;
        _line.material.color = _lineColor;
        _line.startColor = _lineColor;
        _line.endColor = _lineColor;
        // ���N���X(BulletBase)��Start()���s��
        base.Start();
    }

    private void Update()
    {
        // ���N���X(BulletBase)��Update()���s��
        base.Update();
        // LineRenderer�̎n�_�A�I�_�̐ݒ�
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, _player.transform.position);
    }

    public override void BulletEnemyHit(CharacterBase characterBase)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �t�b�N���Œ肷��
        BulletRb2D.Sleep();
        // �v���C���[�ƃt�b�N�̋����𑪒�
        Vector2 _diff = (this.transform.position - _player.transform.position).normalized;
        // �v���C���[�ɗ͂�������
        _playerRb.AddForce(_diff * _springPower, ForceMode2D.Impulse);
    }
}
