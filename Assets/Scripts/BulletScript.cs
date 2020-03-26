using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Range(0,15)]
    public float speed;
    [SerializeField] float duration = 2f;
    public float spawnDelay = 0.2f;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnoutTimer", 0f, 1f);
        rb = GetComponent<Rigidbody>();
        rb.detectCollisions = false;
        SpawnCollDelay();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCollDelay();

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
                playerStats.TakeDamage(1);
                break;
            case "Turret":
                Destroy(other.gameObject);
                break;
            default:
                break;
        }
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

    void SpawnCollDelay()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay <= 0)
        {
            rb.detectCollisions = true;
        }
    }
}
