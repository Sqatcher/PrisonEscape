using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    public Transform playerBody;

    private float rotX = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotX += mouseY;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        transform.localRotation = Quaternion.Euler(rotX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}