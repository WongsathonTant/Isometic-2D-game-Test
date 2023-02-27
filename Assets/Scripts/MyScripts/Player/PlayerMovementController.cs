using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private IsometricPlayerMovementController KeyboardInput;
    [SerializeField] private FixedJoystick Joystick;
    [SerializeField] public bool usingJoystick;
    private Vector2 move;
    [SerializeField] private float MovementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isoRenderer= GetComponentInChildren<IsometricCharacterRenderer>();
    }

    void FixedUpdate()
    {
        if (KeyboardInput.usingKeyboard == false)
        {
            if (Joystick.Horizontal != 0 || Joystick.Vertical != 0) // Check if using joystickInput
            {
                usingJoystick = true;
                getJoystickInput();
                Vector2 currentPos = rb.position;
                Vector2 inputVector = new Vector2(move.x, move.y);
                inputVector = Vector2.ClampMagnitude(inputVector, 1);
                Vector2 movement = inputVector * MovementSpeed;
                Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
                isoRenderer.SetDirection(movement);
                rb.MovePosition(newPos);
            }
            else if (Joystick.Horizontal == 0 && Joystick.Vertical == 0) // Check if not using joystickInput
            {
                usingJoystick = false;
                KeyboardInput.enabled = true;
            }
        }
        else
        {
            this.enabled = false;
        }
    }

    public void getJoystickInput()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
    }
}
