using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRayVision : MonoBehaviour
{
    public UnityEvent onXRay;
    public UnityEvent offXRay;
    bool xRayOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            xRayOn = !xRayOn;
            if (xRayOn != true)
            {
                offXRay.Invoke();
            }
            else
            {
                onXRay.Invoke();
            }
        }
    }
}
