using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityTimer;

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
    private float bulletSpeed = 30f;
    [SerializeField]
    private float shootCooldown = 0.5f;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject bulletSpawner;

    private bool _canShoot = true;
    private Vector3 _playerVelocity;

    
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

    private void Fire()
    {
        if (!_canShoot) return;
        
        _canShoot = false;
        var position = bulletSpawner.transform.position;
        var t = transform;
        var newBullet = Instantiate(bullet);
        newBullet.gameObject.GetComponent<Bullet>().type = playerType;
        newBullet.transform.position = position;
        newBullet.transform.rotation = t.rotation;
        newBullet.GetComponent<Rigidbody>().velocity = -t.forward * bulletSpeed;

        Timer.Register(shootCooldown, () => _canShoot = true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerType == PlayerType.PlayerRed)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Red")) return;
            //TODO: +1 point for playerRed
            Destroy(other.gameObject);
        }
        if (playerType == PlayerType.PlayerBlue)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Blue")) return;
            //TODO: +1 point for playerBlue
            Destroy(other.gameObject);
        }
    }
}

public enum PlayerType
{
    PlayerBlue,
    PlayerRed
}
