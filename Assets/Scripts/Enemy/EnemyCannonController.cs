using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletBase;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform _muzzle = default;
    /// <summary>�e�̎��</summary>
    [SerializeField] GameObject _bullet = default;
    /// <summary>��C�̊p�x����</summary>
    [SerializeField] float _rotationLimit = 90f;
    /// <summary>���̕ύX�O�̐F</summary>
    [SerializeField] Color _defaultSrartColor;
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
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _lookingObject = other.gameObject;
            // LineRenderere�̎n�_�ƏI�_
            _line.SetPosition(0, this._muzzle.position);
            _line.SetPosition(1, other.transform.position);
            // �F���w�肷��
            _line.startColor = _defaultSrartColor;
            _line.endColor = _defaultEndColor;
        }

        // �e�̔���
        if (_timer > _interval && other.gameObject.tag == "Player")
        {          
            // �F���w�肷��
            _line.startColor = _changeStartColor;
            _line.endColor = _changeEndColor;
            Invoke(nameof(ShotBullet), 1f);
            _timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lookingObject = null;
    }

    void ShotBullet()
    {
        GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
        Debug.Log($"�G�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval()}");
        _interval = bullet.GetComponent<BulletBase>().Interval();       
    }
}