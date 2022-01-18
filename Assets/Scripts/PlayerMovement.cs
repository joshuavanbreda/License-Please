using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;

    public Transform spawnPoint;
    int movementSpeed = 1;
    public bool trafficStop = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (trafficStop == false && gameManager.gameStart == true)
        {
            Move();
        }
        else if (trafficStop == true && gameManager.gameStart == true)
        {
            StopMove();
        }
    }

    public void Move()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - (Time.deltaTime * movementSpeed));

        transform.position = newPos;
    }

    public void StopMove()
    {
        Vector3 newPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        transform.position = newPos1;
    }

    //public void Respawn()
    //{
    //    transform.position = spawnPoint.position;
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrafficStop")
        {
            trafficStop = true;
            Debug.Log("yes?");
        }
    }
}
