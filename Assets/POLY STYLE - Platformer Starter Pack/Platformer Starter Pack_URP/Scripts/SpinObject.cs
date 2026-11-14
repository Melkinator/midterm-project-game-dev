using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [Header("Spin Speed (Degrees per Second)")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0f, 180f, 0f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}