using UnityEngine;

public class SwingPendulum : MonoBehaviour
{
    [Header("Swing Settings")]
    [SerializeField] private Vector3 swingAxis = new Vector3(0f, 0f, 1f);
    [SerializeField] private float maxAngle = 45f;
    [SerializeField] private float swingSpeed = 2f;
    [SerializeField] private float timeOffset = 0f;

    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        float angle = Mathf.Sin((Time.time + timeOffset) * swingSpeed) * maxAngle;
        transform.localRotation = startRotation * Quaternion.AngleAxis(angle, swingAxis);
    }
}