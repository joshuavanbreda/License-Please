using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PdaMove : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;

    public Transform originalCamPos;

    private void Start()
    {
        originalCamPos.position = Camera.main.transform.position;
        speedModifier = 0.001f;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y - touch.deltaPosition.y * speedModifier,
                    transform.position.z - touch.deltaPosition.x * speedModifier);
            }
        }
    }
}





//{
//    private Vector3 origin;
//    private Vector3 difference;
//    private Vector3 resetCamera;
//    public Camera moveCam;

//    private bool drag = false;

//    private void Start()
//    {
//        resetCamera = moveCam.transform.position;
//    }

//    private void LateUpdate()
//    {
//        if (Input.GetMouseButton(0))
//        {
//            difference = (moveCam.ScreenToWorldPoint(Input.mousePosition)) - moveCam.transform.position;
//            if (drag == false)
//            {
//                drag = true;
//                origin = moveCam.ScreenToWorldPoint(Input.mousePosition);
//                Debug.Log("working caMERA MOVE?");
//            }
//        }
//        else
//        {
//            drag = false;
//        }

//        if (drag)
//        {
//            moveCam.transform.position = origin - difference;
//        }

//        if (Input.GetMouseButton(1))
//        {
//            moveCam.transform.position = resetCamera;
//        }
//    }
//}
