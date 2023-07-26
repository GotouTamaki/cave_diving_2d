using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(CircleCollider2D))]
public class GroundCheckerController : MonoBehaviour
{
    PlayerController _playerController = null;

    // Start is called before the first frame update
    void Start()
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
