using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class GroundCheckerController : MonoBehaviour
{
    PlayerController _playerController = null;

    // Start is called before the first frame update
    void OnEnable()
    {
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerController.IsGrounded = true;
        _playerController.JumpCount = 0;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        _playerController.IsGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerController.IsGrounded = false;
    }
}
