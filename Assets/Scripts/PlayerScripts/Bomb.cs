using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timeToBoom;
    public float currentTime;
    public float force;
    public float blastRadius;
    public GameObject boom;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Movement.faceingRight)
        {
            rb.AddForce(Vector3.right * force);
        }
        else
        {
            rb.AddForce(-Vector3.right * force);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime >= timeToBoom)
        {
            Boom();
        }

        {
            currentTime += Time.deltaTime;
        }
    }
    void Boom()
    {
   
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, blastRadius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].tag == "explodable")
            {
                Destroy(hitColliders[i].gameObject);
            }
            i++;
        }
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
