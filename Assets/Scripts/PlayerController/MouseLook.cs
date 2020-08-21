using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _mouseSensitivity = 100f;
    private float _horizontalRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _horizontalRotation -= mouseY;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -80f, 80f);

        // We only rotate the camera horizontally and not the player's body.
        transform.localRotation = Quaternion.Euler(_horizontalRotation, 0, 0);
        // We rotate the player's whole body around it's Y axis, thus turning the camera as well.
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
