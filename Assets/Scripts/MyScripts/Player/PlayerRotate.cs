using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public FixedJoystick joystick;
    private Vector2 move;
    private float horizontalInput;
    private float verticalInput;

    private void Update()
    {
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)  // Rotate with joystick
        {
            move.x = joystick.Horizontal;
            move.y = joystick.Vertical;
            float hAxis = move.x;
            float vAxis = move.y;
            float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        }
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // Rotate with keyboard
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            float zAxis = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
        }
    }
}
