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
        // プレイヤーを取得
        _player = GameObject.FindWithTag("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
        // LineRendererの設定
        _line = GetComponent<LineRenderer>();
        _line.material = new Material(Shader.Find("Sprites/Default"));
        _line.startWidth = 0.1f;
        _line.endWidth = 0.1f;
        _line.positionCount = 2;
        _line.material.color = _lineColor;
        _line.startColor = _lineColor;
        _line.endColor = _lineColor;
        // 基底クラス(BulletBase)のStart()を行う
        base.Start();
    }

    private void Update()
    {
        // 基底クラス(BulletBase)のUpdate()を行う
        base.Update();
        // LineRendererの始点、終点の設定
        _line.SetPosition(0, this.transform.position);
        _line.SetPosition(1, _player.transform.position);
    }

    public override void BulletEnemyHit(CharacterBase characterBase)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // フックを固定する
        BulletRb2D.Sleep();
        // プレイヤーとフックの距離を測定
        Vector2 _diff = this.transform.position - _player.transform.position;
        // プレイヤーに力を加える
        _playerRb.AddForce(_diff * _springPower, ForceMode2D.Force);
    }
}
