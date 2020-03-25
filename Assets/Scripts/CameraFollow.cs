using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingSpeed = 0.125f;
    public Vector3 cameraOffset;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingSpeed);
        transform.position = smoothedPosition;
    }
}
