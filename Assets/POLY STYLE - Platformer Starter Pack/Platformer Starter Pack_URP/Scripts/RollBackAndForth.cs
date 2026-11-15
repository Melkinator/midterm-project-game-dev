using UnityEngine;

public class RollBackAndForth : MonoBehaviour
{
    [Header("Movement (Distance from Start)")]
    [SerializeField] private Vector3 moveOffset = new Vector3(5f, 0f, 0f);
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Roll Spin (Degrees per Second)")]
    [SerializeField] private Vector3 spinSpeed = new Vector3(360f, 0f, 0f);
    [SerializeField] private bool reverseSpinOnReturn = true;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Starts smoothly at t = 0 (at startPos) and goes 0 -> 1 -> 0
        float t = 0.5f * (1f - Mathf.Cos(Time.time * moveSpeed));
        transform.localPosition = startPos + moveOffset * t;

        float dir = reverseSpinOnReturn ? Mathf.Sign(Mathf.Sin(Time.time * moveSpeed)) : 1f;
        transform.Rotate(spinSpeed * dir * Time.deltaTime, Space.Self);
    }
}