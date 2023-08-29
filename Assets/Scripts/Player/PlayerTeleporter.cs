using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] Vector2 _teleportPoint = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.position = _teleportPoint;
        }
    }
}
