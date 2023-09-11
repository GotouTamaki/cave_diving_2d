using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>マズルの位置</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>弾の種類</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>大砲の角度制限</summary>
    [SerializeField] float _rotationLimit = 90f;
    /// <summary>線の変更前の色</summary>
    [SerializeField] Color _defaultStartColor;
    [SerializeField] Color _defaultEndColor;
    /// <summary>線の変更後の色</summary>
    [SerializeField] Color _changeStartColor;
    [SerializeField] Color _changeEndColor;
    // 各種初期化
    float _interval = 1f;
    //float _timer = 0;
    GameObject _lookingObject = null;
    LineRenderer _line = null;
    //bool _look = false;
    //Vector2 _r = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //_timer = 0;
        _line = GetComponent<LineRenderer>();
        // 線の幅を決める
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        // 頂点の数を決める
        this._line.positionCount = 2;
        // マテリアルの設定
        _line.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {

        //_timer += Time.deltaTime;

        if (_lookingObject != null)
        {
            // プレイヤーの方向を向く
            this.transform.up = _lookingObject.transform.position - this._muzzle.position;
            // LineRendererの始点と終点
            _line.SetPosition(0, this._muzzle.position);
            _line.SetPosition(1, _lookingObject.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // プレイヤーの索敵をする
            _lookingObject = other.gameObject;
            // 色を指定する
            _line.startColor = _defaultStartColor;
            _line.endColor = _defaultEndColor;
            // 弾を発射する
            StartCoroutine(ShotBullet());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 当たり判定からプレイヤーが外れたら索敵をやめる
            _lookingObject = null;
        }
    }

    /// <summary>弾の発射時の処理</summary>
    IEnumerator ShotBullet()
    {
        while (true)
        {
            // レイの描写
            _line.material.DOFade(1, _interval).OnComplete(() => _line.material.color = _changeEndColor);
            yield return new WaitForSeconds(_interval);
            // 弾のプレハブを取得、生成する
            GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
            //Debug.Log($"敵砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval()}");
            // インターバルの再設定
            _interval = bullet.GetComponent<BulletBase>().Interval;
            // 索敵が終わったら処理を終える
            if (_lookingObject == null) break;
        }
    }
}
