using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingSpeed =10;
    public Vector3 cameraOffset;



    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothingSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
