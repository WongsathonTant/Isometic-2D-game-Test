using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerMovementController joystickInput;
    [SerializeField] public bool usingKeyboard;

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        if (joystickInput.usingJoystick == false)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) // Check if using KeyboardInput
            {
                usingKeyboard = true;
                Vector2 currentPos = rbody.position;
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
                Vector2 movement = inputVector * movementSpeed;
                Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                isoRenderer.SetDirection(movement);
                rbody.MovePosition(newPos);
            }
            else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) // Check if not using KeyboardInput
            {
                usingKeyboard = false;
                joystickInput.enabled = true;
            }
        }
        else
        {
            this.enabled = false;
        }
    }
}
