using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraScript : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 1000f;
    public float bobbingAmount = 0.1f;
    public float bobbingSpeed = 10f;

    private float xRotation = 0f;
    private float bobbingOffset = 0f;
    private bool isMoving = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse input for camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Check if the player is moving
        isMoving = Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0;

        // Apply bobbing effect if the player is moving
        if (isMoving)
        {
            float verticalBobbing = Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
            bobbingOffset = verticalBobbing;
        }
        else
        {
            bobbingOffset = 0f;
        }

        transform.localPosition = new Vector3(0f, bobbingOffset, 0f);

        // Raycast to detect interactable objects automatically
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            // Check if the hit object has the specified tag
            if (hit.transform.CompareTag("InteractiveObj"))
            {
                // Output the name of the interactable object
                Debug.Log("Looking at interactable object: " + hit.transform.name);
            }
        }
    }
}
