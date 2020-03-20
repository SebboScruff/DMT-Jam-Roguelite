using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float jumpHight;
    public float speed;
    Rigidbody rb;
    private float forwardsBackwards;
    public bool isgrounded;

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpHight);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardsBackwards = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
    }

}
