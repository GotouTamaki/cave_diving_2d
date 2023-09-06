using UnityEngine;

public class DDOLController : MonoBehaviour
{
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
        }
    }
}
