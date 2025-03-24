using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{

        //So! This script works as a jumping script well BUT it conflicts with the climbing for some reason. So I cant even
        //begin to climb at all until this script is turned off? I'll look into this further but kinda concerning
        //will potentially leave out jumping altogether.

    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;

    private float gravity = Physics.gravity.y;
    private Vector3 movement;

    private void Update() {
        bool _isGrounded = IsGrounded();

        if (jumpButton.action.WasPressedThisFrame() && _isGrounded) {
            Jump();
        }
        
        movement.y += gravity * Time.deltaTime;

        cc.Move(movement * Time.deltaTime);
    }

    private void Jump() {
        movement.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
    }

    private bool IsGrounded() {
        return Physics.CheckSphere(transform.position, 0.2f, groundLayers);
    }
}
