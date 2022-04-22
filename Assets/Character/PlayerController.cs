using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float gravityValue = -9.81f;
    
    private Vector3 _playerVelocity;
    public PlayerType playerType;

    private Vector2 _movementInput = Vector2.zero;
    private Vector2 _rotateInput = Vector2.zero;
    private bool _shootInput = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        _shootInput = context.action.triggered;
    }
    
    public void onRotate(InputAction.CallbackContext context)
    {
        _rotateInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 move = new Vector3(_movementInput.x, 0, _movementInput.y);
        Vector3 rotate = new Vector3(-_rotateInput.x, 0, -_rotateInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (rotate != Vector3.zero)
        {
            gameObject.transform.forward = rotate;
        }
        
        controller.Move(_playerVelocity * Time.deltaTime);
        _playerVelocity.y += gravityValue * Time.deltaTime;
    }
}

public enum PlayerType
{
    PlayerBlue,
    PlayerRed
}
