using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0,1,2,3

    private int direction;
    public float moveAmount;

    public float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    //public float minX;
    //public float maxX;
    //public float minY;
    public bool stopGeneration;

    public LayerMask whatIsRoom;

    private int downCounter;

    private void Start()
    {

        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[1], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {

        if (direction == 1 || direction == 2)
        { // Move right !

            if (transform.position.x < 25)
            {
                downCounter = 0;
                Vector2 pos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = pos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)
        { // move left
            if (transform.position.x > 5)
            {
                downCounter = 0;
                Vector2 pos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = pos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 5)
        {
            downCounter++;

            if (transform.position.y > 5)
            {
                Collider2D previousRoom = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
                if (previousRoom.GetComponent<Room>().roomType != 1 && previousRoom.GetComponent<Room>().roomType != 3)
                {
                    if (downCounter >= 2)
                    {
                        previousRoom.GetComponent<Room>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    } else
                    {
                        previousRoom.GetComponent<Room>().RoomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 pos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = pos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGeneration = true;
            }
        }
    }
}
