using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Target")]
    [SerializeField] private Transform target;

    [Header("Camera Settings")]
    [SerializeField] private float distance = 7f;
    [SerializeField] private float height = 3f;
    [SerializeField] private float mouseSensitivity = 3f;
    [SerializeField] private float followSmoothness = 10f;

    [Header("Camera Rotation")]
    [SerializeField] private float minYAngle = -20f;
    [SerializeField] private float maxYAngle = 60f;

    private float yaw;
    private float pitch = 15f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Only rotate camera when cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            pitch = Mathf.Clamp(pitch, minYAngle, maxYAngle);
        }

        // Calculate camera position
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        Vector3 offset = rotation * new Vector3(0f, height, -distance);

        Vector3 desiredPosition = target.position + offset;

        // Smoothly follow player
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSmoothness * Time.deltaTime
        );

        // Look at player
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }

    public float GetYaw()
    {
        return yaw;
    }
}
