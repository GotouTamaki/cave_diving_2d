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
            // �d�����Ȃ��悤�ɁA���ɂ��鎞�͎������g��j������
            Destroy(this.gameObject);
        }
        else
        {
            // �����������Ȃ����́A������ DontDestroyOnLoad �ɓo�^����
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
}
