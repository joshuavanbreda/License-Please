using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DeviceButtons deviceButtons;
    public GameManager gameManager;

    public Transform spawnPoint;
    int movementSpeed = 1;
    public bool trafficStop = true;

    public Transform originalRotation;
    public Transform rotationSet;
    public GameObject pickUpTruck;

    public GameObject trafficBarrier;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation.rotation = transform.rotation;
        pickUpTruck.SetActive(false);

        transform.position = spawnPoint.position;

        rotationSet.rotation = Quaternion.Euler(-20, 148, 6);
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

            deviceButtons.pdaOn.SetActive(true);
            deviceButtons.arrestBtn.SetActive(true);
            deviceButtons.releaseBtn.SetActive(true);
        }
    }

    public void PickUpTruck()
    {
        transform.rotation = rotationSet.rotation;
        transform.position = transform.position + new Vector3(0, 0.6f, 0.5f);
        pickUpTruck.SetActive(true);
        trafficBarrier.SetActive(false);
    }

    public void resetRotationTruck()
    {
        transform.rotation = originalRotation.rotation;
        pickUpTruck.SetActive(false);
    }
}
