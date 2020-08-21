using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundCheckTransform;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _movementSpeed = 5;
    [SerializeField] private float _runSpeedModifier = 1.5f;
    [SerializeField] private float _gravity = -9.81f;

    private bool _isGrounded;
    private Vector3 _velocity;

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheckTransform.position, _groundDistance, _groundMask);

        if (_isGrounded)
        {
            _velocity.y = -2f;
        }

        // Determine if the player is running.
        float movementSpeedModifier = (Input.GetButton("Run")) ? _movementSpeed * _runSpeedModifier : _movementSpeed;

        float horizontalModifier = Input.GetAxis("Horizontal");
        float verticalModifier = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontalModifier + transform.forward * verticalModifier;
        _characterController.Move(moveDirection * movementSpeedModifier * Time.deltaTime);

        // Apply gravity to our character.
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
