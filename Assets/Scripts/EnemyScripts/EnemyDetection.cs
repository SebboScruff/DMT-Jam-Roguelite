using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Range(2, 10)]
    public float detectionRadius;
    [SerializeField] bool targetFound;
    [SerializeField] private GameObject player;
    [SerializeField] Pause pauseManager;

    [Header("Shooting Variables")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firingPoint;
    [SerializeField] float shootCD = 3f;
    [Range(5, 15)]
    public float bulletSpeed = 7f;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootCD = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(player.transform.position, transform.position) <= detectionRadius)
        {
            targetFound = true;
        }
        else { targetFound = false; }

        if(targetFound == true)
        {
            transform.LookAt(player.transform.position, Vector3.up);

            if(shootCD <= 0 && pauseManager.isPaused == false)
            {
                EnemyShoot();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void EnemyShoot()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = firingPoint.transform.position;
        b.transform.rotation = firingPoint.transform.rotation;
        Vector3 bulletLocalForward = b.transform.worldToLocalMatrix.MultiplyVector(transform.forward).normalized;
        b.GetComponent<Rigidbody>().velocity = bulletLocalForward * bulletSpeed;
        
        shootCD = 3f;
        InvokeRepeating("ShootCooldown", 0f, 1f);
    }

    void ShootCooldown()
    {
        if(shootCD > 0)
        {
            shootCD--;
        }
        else { CancelInvoke(); }
    }
}
