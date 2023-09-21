using System.Collections;
using UnityEngine;
using DG.Tweening;

public class EnemyCannonController : MonoBehaviour
{
    /// <summary>�}�Y���̈ʒu</summary>
    [SerializeField] Transform[] _muzzle = default;
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
    [SerializeField] bool _canLook = true;

    // �e�평����
    float _interval = 1f;
    //float _timer = 0;
    GameObject _lookingObject = null;
    LineRenderer _line = null;
    bool _canShoot = true;

    void OnEnable()
    {
        //_timer = 0;
        _line = GetComponent<LineRenderer>();
        // ���̕������߂�
        this._line.startWidth = 0.1f;
        this._line.endWidth = 0.1f;
        // ���_�̐������߂�
        this._line.positionCount = 2;
        // �}�e���A���̐ݒ�
        _line.material = new Material(Shader.Find("Sprites/Default"));
    }

    void Update()
    {

        //_timer += Time.deltaTime;

        if (_lookingObject != null && _canLook)
        {
            // �v���C���[�̕���������
            this.transform.up = _lookingObject.transform.position - this._muzzle[0].position;
            // LineRenderer�̎n�_�ƏI�_
            _line.SetPosition(0, this._muzzle[0].position);
            _line.SetPosition(1, _lookingObject.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // �v���C���[�̍��G������
            _lookingObject = other.gameObject;

            if (_canLook)
            {
                // �F���w�肷��
                _line.startColor = _defaultStartColor;
                _line.endColor = _defaultEndColor;
            }

            if (_canShoot)
            {
                // �e�𔭎˂���
                StartCoroutine(ShotBullet());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // �����蔻�肩��v���C���[���O�ꂽ����G����߂�
            _lookingObject = null;
        }

        _canShoot = false;
    }

    /// <summary>�e�̔��ˎ��̏���</summary>
    IEnumerator ShotBullet()
    {
        while (true)
        {
            _canShoot = false;
            // ���C�̕`��
            _line.material.DOFade(1, _interval).OnComplete(() => _line.material.color = _changeEndColor).SetLink(this.gameObject);
            yield return new WaitForSeconds(_interval);
            //this.transform.up = this.transform.up + new Vector3(Random.Range(-10, 10), 0, 0);
            // ���˂���}�Y�������߂�
            int muzzleNum = Random.Range(0, _muzzle.Length);
            // �e�̃v���n�u���擾�A��������
            GameObject bullet = Instantiate(_bullet, _muzzle[muzzleNum].position, _muzzle[muzzleNum].rotation);
            //Debug.Log($"�G�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval()}");
            // �C���^�[�o���̍Đݒ�
            _interval = bullet.GetComponent<BulletBase>().Interval;
            _canShoot = true;
            // ���G���I������珈�����I����
            if (_lookingObject == null) break;
        }
    }
}
