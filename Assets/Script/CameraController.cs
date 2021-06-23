using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 originalPosition;

    public CarController followTarget;

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, originalPosition + followTarget.transform.position, followTarget.CarSpeed); 
    }
    void Start()
    {
        originalPosition = new Vector3(0,0,transform.position.z);
    }

}

