using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firingPoint;
    public GameObject cross;
    public Vector3 pos;
    public float bulletSpeed;
    private Rect target;
    public Pause pauseManager;
    public float distance = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //z pos needs fine tuneing so bullets hit the middle of crosshair
        pos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance)) ;
        cross.transform.position = new Vector2(pos.x, pos.y);

        Vector3 difference = pos - firingPoint.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        firingPoint.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        if (Input.GetMouseButtonDown(0) && pauseManager.isPaused == false)
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            fireBullet(direction, rotationZ);

        }
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = firingPoint.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
    }


}
