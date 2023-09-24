using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{
    GameObject _player = null;

    void Start()
    {
        MiniMapPositionSet();
    }

    void Update()
    {
        if (_player != null)
        {
            this.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, this.transform.position.z);
        }
    }

    void MiniMapPositionSet()
    {
        while (_player == null)
        {
            _player = GameObject.FindWithTag("Player");
            Debug.Log("ë{çıíÜ");
        }
    }
}
