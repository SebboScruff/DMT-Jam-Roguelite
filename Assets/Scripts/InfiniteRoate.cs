using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoate : MonoBehaviour
{
    public int rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
