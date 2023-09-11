using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class CharacterBase : MonoBehaviour
{
    [SerializeField] GameObject _exprosionPrefab = null;
    [SerializeField] float _maxHp = 1;
    public float CharacterMaxHp { get =>_maxHp; set =>_maxHp = value; }
    [SerializeField] float _hp = 1;
    public float CharacterHp { get => _hp; set => _hp = value; }
    [SerializeField] float _lifeReduceSpeedOnBurning = 1;
    public float LifeReduceSpeedOnBurning { get => _lifeReduceSpeedOnBurning; set => _lifeReduceSpeedOnBurning = value; }

    Rigidbody2D _rb = default;
    SpriteRenderer _sprite = default;
    CharacterState _state = CharacterState.Normal;
    public CharacterState State { get => _state; set => _state = value; }
    [SerializeField] float _stateTime = 0;
    public float StateTime { get => _stateTime; set => _stateTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 生死判定
        if (_hp < 1)
        {
            _state = CharacterState.Dead;
        }

        // 状態異常になっている時間
        _stateTime -= Time.deltaTime;

        if (_stateTime < 0 && _hp > 0)
        {
            _state = CharacterState.Normal;
            _stateTime = 0;
            //Debug.Log("ノーマル！");
        }

        // 状態異常
        if (_state == CharacterState.Burning)
        {
            _hp -= _lifeReduceSpeedOnBurning * Time.deltaTime;
            _sprite.color = Color.red;
        }
        else if (_state == CharacterState.Slow)
        {
            _sprite.color = Color.cyan;
        }
        else if (_state == CharacterState.Dead)
        {
            Debug.Log("やられた！");
            if (_exprosionPrefab != null)
            {
                Instantiate(_exprosionPrefab, this.transform.position, _exprosionPrefab.transform.rotation);
            }
            Destroy(this.gameObject);
        }
        else
        {
            _state = CharacterState.Normal;
            _sprite.color = Color.white;
        }
    }

    public enum CharacterState
    {
        Normal,
        Burning,
        Slow,
        Dead,
    }
}
