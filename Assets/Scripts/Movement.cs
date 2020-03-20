using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection;
    CharacterController controller;
    public bool wallCol;

    void movement()
    {
        if (controller.isGrounded)
        {
            moveDirection.x = speed * Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void Walljump()
    {
 
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
         if(hit.normal.y< 0.1&& !controller.isGrounded)
        {
            wallCol = true;
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection = hit.normal * speed;
                moveDirection.y = jumpSpeed;
            }
            else
            {
                wallCol = false;
            }
        }
    }
}
