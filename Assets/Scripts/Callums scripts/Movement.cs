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
    public bool faceingRight = true;

    void MovementMethod()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.x = speed * Input.GetAxis("Horizontal");
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        MovementMethod();
        if ((Input.GetAxis("Horizontal") > 0 && !faceingRight) || (Input.GetAxis("Horizontal") < 0 && faceingRight))
        {
            Flip();
        }
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

        }
    }
    private void Flip()
    {

        faceingRight =!faceingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
