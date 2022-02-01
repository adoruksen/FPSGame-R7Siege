using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mouseX, mouseY;
    float mouseSensitivity = 1500f;
    Transform playerBody;

    float xRotation = 0f;
    void Start()
    {
        if (LevelManager.gameState==GameState.Normal)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        playerBody = transform.parent;
    }

    void Update()
    {
        if (LevelManager.gameState==GameState.Normal)
        {
            CameraRotator();
        }
    }
    
    void CameraRotator()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -30, 45);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
