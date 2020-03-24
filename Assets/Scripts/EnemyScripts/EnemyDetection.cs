using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Range(2, 10)]
    public float detectionRadius;
    [SerializeField] bool targetFound;
    [SerializeField] public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
