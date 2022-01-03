using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int movementSpeed = 1;
    bool trafficStop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trafficStop == false)
        {
            Move();
        }
        else if (trafficStop == true)
        {
            StopMove();
        }
    }

    public void Move()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Time.deltaTime * movementSpeed));

        transform.position = newPos;
    }

    public void StopMove()
    {
        Vector3 newPos1 = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        transform.position = newPos1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrafficStop")
        {
            trafficStop = true;
        }
    }
}
