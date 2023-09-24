using UnityEngine;

public class DDOLController : MonoBehaviour
{
    [SerializeField] InventoryManager _inventoryManager = null;

    public static DDOLController instance = null;

    public InventoryManager Inventory => _inventoryManager;

    void Awake()
    {
        if (FindObjectsOfType<DDOLController>().Length > 1)
        {
            // 重複しないように、既にある時は自分自身を破棄する
            Destroy(this.gameObject);
        }
        else
        {
            // 自分しかいない時は、自分を DontDestroyOnLoad に登録する
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
}
