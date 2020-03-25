using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickUp : MonoBehaviour
{
    [Range(5, 75)]
    public float turnSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0f, turnSpeed, 0f) * Time.deltaTime;


    }
}
