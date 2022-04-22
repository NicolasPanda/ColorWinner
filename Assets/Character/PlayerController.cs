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
    private Vector3 playerVelocity;

    private Vector2 movementInput = Vector2.zero;
    private bool shootInput = false;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        shootInput = context.action.triggered;
    }

    void Update()
    {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
