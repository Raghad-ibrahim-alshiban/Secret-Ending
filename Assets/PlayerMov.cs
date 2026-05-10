using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMov: MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;

    [Header("Footstep Sound")]
    public AudioSource footstepSound;

    float xRotation = 0f;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // قفل الماوس في الشاشة
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
        Move();
        HandleFootsteps();
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void HandleFootsteps()
    {
        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity.y = 0;

        bool isMoving = horizontalVelocity.magnitude > 0.1f && controller.isGrounded;

        if (isMoving)
        {
            if (!footstepSound.isPlaying)
            {
                footstepSound.Play();
            }
        }
        else
        {
            footstepSound.Stop();
        }
    }
}