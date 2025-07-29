using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Player
    public float smoothSpeed = 0.125f;
    public Vector3 offset;         // Khoảng cách giữa camera và player

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z); // Giữ nguyên Z
    }
}
