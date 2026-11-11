
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;

    [Header("Dash")]
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 0.5f;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckDistance = 1.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Lab wiring")]
    [SerializeField] private Transform cameraTransform;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isDashing;

    private float nextDashTime;

    private Vector3 dashDirection;
    private Vector3 cameraOffset = new Vector3(0f, 5f, -7f);

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Debug.Log("[PlayerController] Ready.");
    }

    void Update()
    {
        HandleMovement();
        HandleDashInput();
    }

    private void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(h, 0f, v).normalized;

        // Ground check
        isGrounded = Physics.Raycast(
            transform.position,
            Vector3.down,
            groundCheckDistance,
            groundLayer
        );

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Normal movement (disabled while dashing)
        if (!isDashing)
        {
            transform.Translate(
                movement * moveSpeed * Time.deltaTime,
                Space.World
            );
        }
    }

    private void HandleDashInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&Time.time >= nextDashTime&&!isDashing)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(h, 0f, v).normalized;

            // If no direction is pressed, dash forward
            if (direction == Vector3.zero) {direction = transform.forward;}

            StartCoroutine(Dash(direction));

            nextDashTime = Time.time + dashCooldown;
        }
    }

    private IEnumerator Dash(Vector3 direction)
    {
        isDashing = true;

        dashDirection = direction;

        float dashEndTime = Time.time + dashDuration;

        while (Time.time < dashEndTime)
        {
            rb.linearVelocity = new Vector3(dashDirection.x * dashSpeed, rb.linearVelocity.y, dashDirection.z * dashSpeed);

            yield return null;
        }

        isDashing = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(
            transform.position,
            transform.position + Vector3.down * groundCheckDistance
        );
    }
}
