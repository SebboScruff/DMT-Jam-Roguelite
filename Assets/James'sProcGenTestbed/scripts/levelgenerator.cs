using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelgenerator : MonoBehaviour
{
    public Transform[] startPositions;
    public GameObject[] rooms; //0 --> LR, 1 --> LRD, 2 --> LRU, 3 --> LRUD
    public GameObject startPortal, endPortal;

    float timeBetweenRoom;
    public float startTimeBetweenRoom = 0.25f;

    private int direction;
    public float moveAmount;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGen = false;

    public LayerMask room;

    private int downConter;

    // Start is called before the first frame update
    void Start()
    {
        int randomStartingPos = Random.Range(0, startPositions.Length);
        transform.position = startPositions[randomStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        Instantiate(startPortal, transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Move()
    {
        if (direction == 1 || direction == 2)//Move right
        {
            if (transform.position.x < maxX)
            {
                downConter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }
                if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
            
        }
        else if (direction == 3 || direction == 4)//Move left
        {
            if (transform.position.x > minX)
            {
                downConter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
            
        }
        else if (direction == 5)//Move down
        {
            downConter++;

            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<roomType>().type != 1 && roomDetection.GetComponent<roomType>().type != 3)
                {
                    if (downConter >= 2)
                    {
                        roomDetection.GetComponent<roomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<roomType>().RoomDestruction();

                        int randomBottomRoom = Random.Range(1, 4);
                        if (randomBottomRoom == 2)
                        {
                            randomBottomRoom = 1;
                        }
                        Instantiate(rooms[randomBottomRoom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGen = true;
                Instantiate(endPortal, transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenRoom <= 0 && stopGen == false)
        {
            Move();
            timeBetweenRoom = startTimeBetweenRoom;
        }
        else
        {
            timeBetweenRoom -= Time.deltaTime;
        }
    }
}
