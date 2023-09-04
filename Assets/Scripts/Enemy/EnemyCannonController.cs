using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�e�̎��</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>��C�̊p�x����</summary>
    [SerializeField] float _rotationLimit = 90f;
    /// <summary>���̕ύX�O�̐F</summary>
    [SerializeField] Color _defaultStartColor;
    [SerializeField] Color _defaultEndColor;
    /// <summary>���̕ύX��̐F</summary>
    [SerializeField] Color _changeStartColor;
    [SerializeField] Color _changeEndColor;
    // �e�평����
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
        // ���̕������߂�
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        // ���_�̐������߂�
        this._line.positionCount = 2;
        // �}�e���A���̐ݒ�
        _line.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {

        _timer += Time.deltaTime;

        if (_lookingObject != null)
        {
            this.transform.up = _lookingObject.transform.position - this._muzzle.position;
            // LineRenderer�̎n�_�ƏI�_
            _line.SetPosition(0, this._muzzle.position);
            _line.SetPosition(1, _lookingObject.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _lookingObject = other.gameObject;          
            // �F���w�肷��
            _line.startColor = _defaultStartColor;
            _line.endColor = _defaultEndColor;
            StartCoroutine(ShotBullet());
        }

        // �e�̔���
        if (_timer > _interval && other.gameObject.tag == "Player")
        {
            // �F���w�肷��
            _line.startColor = _changeStartColor;
            _line.endColor = _changeEndColor;
            _timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _lookingObject = null;
            StopCoroutine(ShotBullet());
        }
    }

    void ShootColor()
    {
        var beforeMat = _changeEndColor;
        _line.material.DOFade(1, _interval).OnComplete(() => _line.material.color = beforeMat);
    }

    IEnumerator ShotBullet()
    {
        while (true)
        {
            _line.material.DOFade(1, _interval).OnComplete(() => _line.material.color = _changeEndColor);
            yield return new WaitForSeconds(_interval);
            GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
            Debug.Log($"�G�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval()}");
            if (_lookingObject == null) break;
            //_interval = bullet.GetComponent<BulletBase>().Interval();
            //yield return new WaitForSeconds(_interval);
        }
    }
}
