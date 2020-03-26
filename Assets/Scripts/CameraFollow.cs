using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;

    private void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer)
            transform.LookAt(PlayerTransform);
    }













    //public Transform target;
    //public float smoothingSpeed =10;
    //public Vector3 cameraOffset;



    //private void LateUpdate()
    //{
    //    Vector3 desiredPosition = target.position + cameraOffset;
    //    Vector3 smoothedPosition = Vector3.Slerp(transform.position, desiredPosition, smoothingSpeed * Time.deltaTime);
    //    transform.position = smoothedPosition;
    //}
}
