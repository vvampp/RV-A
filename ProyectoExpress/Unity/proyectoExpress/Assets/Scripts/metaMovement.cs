using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;  
    public float movementSpeed = 1.0f; 

    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        if (moveDirection.magnitude > 0.1f)
        {
            playerTransform.Translate(moveDirection * movementSpeed * Time.deltaTime, Space.Self);
        }
    }
}

