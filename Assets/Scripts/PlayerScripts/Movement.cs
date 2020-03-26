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
    static public bool faceingRight = true;
    public GameObject crosshair;
    public bool touchingTop;
    public GameObject player;
    public GameObject bomb;
    public GameObject bombFP;
    public float bombAmmo = 3;

    //animation variables
    public Animator animator;
    
    void MovementMethod()
    {
        if (!wallCol)
        {
            moveDirection.x = speed * Input.GetAxis("Horizontal");
        if (moveDirection.x > 0 || moveDirection.x < 0)
            {
                animator.SetBool("is_running", true);
            }
            else
            {
                animator.SetBool("is_running", false);
            }



        if (Input.GetKey(KeyCode.Space)&& controller.isGrounded && !touchingTop)

            {
                moveDirection.y = jumpSpeed;
                //animation key
            }
        }
        if (Input.GetKey(KeyCode.Space)) // Animation Get Key Check
        {
            animator.SetBool("is_in_air", true);
        }
        else
        {
            animator.SetBool("is_in_air", false);
        }
        if (!controller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        controller.Move(moveDirection * Time.deltaTime);


    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Animation Start
       // animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            print("Touching Ceiling!");
            touchingTop = true;
        }
        else
        {
            touchingTop = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            player.transform.localScale = (new Vector3(.5f, .5f, .5f));
        }
        else if (Input.GetKeyUp(KeyCode.S)&& !touchingTop)
        {
            player.transform.localScale = (new Vector3(1f, 1f, 1f));
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)&& bombAmmo > 0)
        {
            Instantiate(bomb, bombFP.transform.position, Quaternion.identity);
            bombAmmo -= 1;
        }
        MovementMethod();
        Flip();

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

         if(hit.normal.y< 0.1&& !controller.isGrounded && !touchingTop)

        {
            wallCol = true;

            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection = hit.normal * speed;
                moveDirection.y = jumpSpeed;
                Flip();
            }
        }
        else
        {
            wallCol = false;
        }
    }
    public void Flip()
    {
        if(crosshair.transform.position.x>= transform.position.x)
        {
            faceingRight = true;
            transform.rotation = Quaternion.Euler(0, -90, 0);
            animator.SetBool("faceingRight", true);
        }
        else
        {
            faceingRight = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("faceingRight", false);
        }

        //faceingRight =!faceingRight;
        //transform.Rotate(0f, 180f, 0f);
    }
}
