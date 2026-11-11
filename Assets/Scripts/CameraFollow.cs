using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [Header("Target")]
    [SerializeField] private Transform target;     // drag the Player here

    [Header("Framing")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 12f, -8f);
    [SerializeField] private float followSharpness = 5f;

    [Header("Zoom (stretch)")]
    [SerializeField] private float minZoom = 6f;
    [SerializeField] private float maxZoom = 18f;

    void LateUpdate() {
        if (target == null) return;

        // Follow AFTER the player moved — this is why we use LateUpdate.
        Vector3 desired = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desired, followSharpness * Time.deltaTime);
    }
}
