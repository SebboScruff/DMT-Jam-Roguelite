using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [Range(2, 20)]
    public float detectionDist = 2.5f;
    [SerializeField] Transform rayOrigin;
    RaycastHit hit;
    public float moveSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward) * detectionDist, Color.magenta);
        if(Physics.Raycast(rayOrigin.position, rayOrigin.TransformDirection(Vector3.forward), detectionDist))
        {
            transform.eulerAngles += new Vector3(0f, 180f, 0f);
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
