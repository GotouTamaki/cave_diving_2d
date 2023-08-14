using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletBase;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>マズルの位置</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>弾の種類</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>大砲の角度制限</summary>
    [SerializeField] float _rotationLimit = 90f;
    /// <summary>線の変更前の色</summary>
    [SerializeField] Color _defaultSrartColor;
    [SerializeField] Color _defaultEndColor;
    /// <summary>線の変更後の色</summary>
    [SerializeField] Color _changeStartColor;
    [SerializeField] Color _changeEndColor;
    // 各種初期化
    float _interval = 1f;
    float _timer = 0;
    GameObject _lookingObject = null;
    LineRenderer _line = null;
    bool _look = false;
    //Vector2 _r = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _timer = 0;
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
        
        _timer += Time.deltaTime;

        if (_lookingObject != null)
        {
            this.transform.up = _lookingObject.transform.position - this._muzzle.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _lookingObject = other.gameObject;
            // LineRenderereの始点と終点
            _line.SetPosition(0, this._muzzle.position);
            _line.SetPosition(1, other.transform.position);
            // 色を指定する
            _line.startColor = _defaultSrartColor;
            _line.endColor = _defaultEndColor;
        }

        // 弾の発射
        if (_timer > _interval && other.gameObject.tag == "Player")
        {          
            // 色を指定する
            _line.startColor = _changeStartColor;
            _line.endColor = _changeEndColor;
            StartCoroutine(ShotBullet());
            //Invoke(nameof(ShotBullet), 1f);
            _timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lookingObject = null;
    }

    IEnumerator ShotBullet()
    {
        yield return new WaitForSeconds(_interval);
        GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
        Debug.Log($"敵砲発射、インターバル{bullet.GetComponent<BulletBase>().Interval()}");
        _interval = bullet.GetComponent<BulletBase>().Interval();
        //yield return new WaitForSeconds(_interval);
    }
}
