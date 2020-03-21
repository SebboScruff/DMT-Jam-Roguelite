using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject firingPoint;
    public GameObject crosshair;
    public float bulletSpeed;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,-10));
        crosshair.transform.position = new Vector2(target.x, target.y);
    }
}
