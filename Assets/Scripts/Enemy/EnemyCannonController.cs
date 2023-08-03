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

    // �e�평����
    float _interval = 1f;
    float _timer = 0;
    GameObject _lookingObject = null;
    bool _look = false;
    //Vector2 _r = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _interval;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_lookingObject != null)
        {
            this.transform.up = _lookingObject.transform.position - this.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _lookingObject = other.gameObject;

        // �e�̔���
        if (_timer > _interval && other.gameObject.tag == "Player")
        {
            GameObject bullet = Instantiate(_bullet, _muzzle.position, this.transform.rotation);
            Debug.Log($"�G�C���ˁA�C���^�[�o��{bullet.GetComponent<BulletBase>().Interval()}");
            _interval = bullet.GetComponent<BulletBase>().Interval();
            _timer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _lookingObject = null;
    }
}
