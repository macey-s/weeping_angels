using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 300f;

    public Transform playerCamera;
    public CharacterController controller;

    float xRotation = 0f;
    Vector3 velocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Automatically assign if missed
        if (controller == null)
            controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);

        // CharacterController handles collisions AUTOMATICALLY
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        if (!controller.isGrounded)
            velocity.y += Physics.gravity.y * Time.deltaTime;
        else
            velocity.y = -2f;

        controller.Move(velocity * Time.deltaTime);
    }

    void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate body left/right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate camera up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
