using UnityEngine;

public class ItemCollisionDetection : InputBase
{
    [SerializeField] ItemBase _itemBase = null;
    [SerializeField] AudioClip _clip = null;

    AudioSource _audioSource = null;

    void Start()
    {
        //_itemBase = GetComponent<ItemBase>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //_audioSource.PlayClipAtPoint(_clip, transform.position);
            _itemBase.ItemGet();
        }
    }
}
