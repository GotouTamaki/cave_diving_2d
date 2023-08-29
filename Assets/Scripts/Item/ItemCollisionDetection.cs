using UnityEngine;

public class ItemCollisionDetection : InputBase
{
    [SerializeField] ItemBase _itemBase = null;

    void Start()
    {
        //_itemBase = GetComponent<ItemBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _itemBase.ItemGet();
        }
    }
}
