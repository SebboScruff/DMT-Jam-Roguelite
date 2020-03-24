using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Range(0,15)]
    public float speed;
    [SerializeField] float duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnoutTimer", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision shit
        Destroy(gameObject);
    }

    void SpawnoutTimer()
    {
        duration--;
        if(duration <= 0)
        {
            Destroy(gameObject);
        }
    }
}
