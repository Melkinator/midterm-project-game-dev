
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed = 12f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.5f;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckDistance = 1.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Camera")]
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;

    private Vector2 moveInput;
    private bool isGrounded;
    private bool isDashing;

    private float nextDashTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Debug.Log("[PlayerController] Ready. Collect all orbs to win.");
    }

    void Update()
    {
        // Read player input
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        ).normalized;

        CheckGround();

        HandleJump();
        HandleDashInput();
        HandleRotation();
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            HandleMovement();
        }
    }

    private Vector3 GetCameraDirection()
    {
        // Get camera forward and right directions
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ignore vertical camera angle
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // Calculate movement relative to camera
        return (forward * moveInput.y + right * moveInput.x).normalized;
    }

    private void HandleMovement()
    {
        Vector3 movement = GetCameraDirection();

        rb.linearVelocity = new Vector3(
            movement.x * moveSpeed,
            rb.linearVelocity.y,
            movement.z * moveSpeed
        );
    }

    private void HandleRotation()
    {
        if (isDashing) return;

        Vector3 movement = GetCameraDirection();

        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            groundCheckDistance,
            groundLayer
        );
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );
        }
    }

    private void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) &&
            Time.time >= nextDashTime &&
            !isDashing)
        {
            Vector3 direction = GetCameraDirection();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            StartCoroutine(Dash(direction));

            nextDashTime = Time.time + dashCooldown;
        }
    }

    private IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;

        float dashEndTime = Time.time + dashDuration;

        while (Time.time < dashEndTime)
        {
            rb.linearVelocity = new Vector3(
                direction.x * dashSpeed,
                rb.linearVelocity.y,
                direction.z * dashSpeed
            );

            yield return new WaitForFixedUpdate();
        }

        isDashing = false;
    }
}
