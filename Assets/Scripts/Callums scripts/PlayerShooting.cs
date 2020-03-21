using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject firingPoint;
    public Texture2D crosshairs;
    public float bulletSpeed;
    private Rect target;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        //crosshairs.transform.position = new Vector2(target.x, target.y);

    }
    private void OnGUI()
    {
        target= new Rect((Input.mousePosition.x - (crosshairs.width / 2)), ((Screen.height - Input.mousePosition.y) - (crosshairs.height / 2)), crosshairs.width, crosshairs.height);
        GUI.DrawTexture(target, crosshairs);
    }
}
