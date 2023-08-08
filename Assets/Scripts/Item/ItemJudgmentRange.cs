using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemJudgmentRange : InputBase
{
    [SerializeField] GameObject _item = null;

    ItemBase _itemBase = null;
    bool _canCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        _itemBase = _item.GetComponent<ItemBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _canCheck = true;

        if (_canCheck && _inputController.Player.Choice.triggered)
        {
            _itemBase.Item();
            _canCheck = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canCheck = false;
    }
}
