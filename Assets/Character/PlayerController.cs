using System;
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
    [SerializeField]
    private float bulletSpeed = 10f;
    private Vector3 _playerVelocity;

    [SerializeField]
    private GameObject bullet;
    
    private PlayerInput _playerInput;
    private InputAction _shootInput;
    
    
    public PlayerType playerType;

    private Vector2 _movementInput = Vector2.zero;
    private Vector2 _rotateInput = Vector2.zero;

    private void Start()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
        controller = gameObject.GetComponent<CharacterController>();
        
        _shootInput = _playerInput.currentActionMap.FindAction("Shoot");
        _shootInput.started += ctx => Fire();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
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

    void Fire()
    {
        var newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = -transform.forward * bulletSpeed;
    }
}

public enum PlayerType
{
    PlayerBlue,
    PlayerRed
}
