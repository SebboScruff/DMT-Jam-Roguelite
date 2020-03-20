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
            rb.AddForce(Vector3.up * jumpHight);
            Debug.Log("JUMP");
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime * forwardsBackwards);
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
