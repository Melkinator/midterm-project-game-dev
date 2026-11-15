using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [Header("Spin Speed (Degrees per Second)")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 180f, 0f);

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed * Time.fixedDeltaTime, Space.Self);
    }
}