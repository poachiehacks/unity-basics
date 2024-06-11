using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    static float baseMoveSpeed = 5;
    
    float deadzone = 0.125f;
    float moveSpeed = baseMoveSpeed;
    float turnSpeed = 100;
    float rotateToVertSpeed = 0.0005f;
    PlayerControls controls;
    float move;
    float rotate;

    Quaternion from;
    Quaternion to;

    internal struct Accel {
        internal float moveUp;
        internal float moveDown;
        internal float moveLeft;
        internal float moveRight;
        internal float rotateLeft;
        internal float rotateRight;
        internal float rotateUp;
        internal float rotateDown;
    }
    internal Accel accel;

    void Awake() 
    {
        // set up controller action callbacks
        controls = new PlayerControls();
        controls.Gameplay.Grow.performed += ctx => Grow();
        controls.Gameplay.Shrink.performed += ctx => Shrink();
        
        controls.Gameplay.MoveUp.performed += ctx => accel.moveUp = ctx.ReadValue<float>();
        controls.Gameplay.MoveUp.canceled  += ctx => accel.moveUp = 0.0f;
        controls.Gameplay.MoveDown.performed += ctx => accel.moveDown = ctx.ReadValue<float>();
        controls.Gameplay.MoveDown.canceled  += ctx => accel.moveDown = 0.0f;
        
        controls.Gameplay.MoveLeft.performed += ctx => accel.moveLeft = ctx.ReadValue<float>();
        controls.Gameplay.MoveLeft.canceled  += ctx => accel.moveLeft = 0.0f;
        controls.Gameplay.MoveRight.performed += ctx => accel.moveRight = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled  += ctx => accel.moveRight = 0.0f;

        controls.Gameplay.RotateLeft.performed += ctx => accel.rotateLeft = ctx.ReadValue<float>();
        controls.Gameplay.RotateLeft.canceled  += ctx => accel.rotateLeft = 0.0f;
        controls.Gameplay.RotateRight.performed += ctx => accel.rotateRight = ctx.ReadValue<float>();
        controls.Gameplay.RotateRight.canceled  += ctx => accel.rotateRight = 0.0f;

        controls.Gameplay.RotateUp.performed += ctx => accel.rotateUp = ctx.ReadValue<float>();
        controls.Gameplay.RotateUp.canceled  += ctx => accel.rotateUp = 0.0f;
        controls.Gameplay.RotateDown.performed += ctx => accel.rotateDown = ctx.ReadValue<float>();
        controls.Gameplay.RotateDown.canceled  += ctx => accel.rotateDown = 0.0f;

        // implies hold to sprint
        controls.Gameplay.Sprint.performed += ctx => SetSprintState();
        controls.Gameplay.Sprint.canceled += ctx => SetMoveState();

        from = transform.rotation;
        to = transform.rotation;
    }

    void SetSprintState()
    {
        moveSpeed = 2*baseMoveSpeed;
    }
    void SetMoveState()
    {
        moveSpeed = baseMoveSpeed;
    }

    void Grow()
    {
        transform.localScale *= 1.1f;
    }
    void Shrink()
    {
        transform.localScale *= (1.0f/1.1f);
    }
    void Update()
    {
        // strafing
        transform.Translate(moveSpeed * new Vector3(0, 0, (accel.moveUp - accel.moveDown)) * Time.deltaTime);
        transform.Translate(moveSpeed * new Vector3((accel.moveRight - accel.moveLeft), 0, 0) * Time.deltaTime);
        
        //rotating
        transform.Rotate(Vector3.up * (accel.rotateRight - accel.rotateLeft) * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * (accel.rotateDown - accel.rotateUp) * turnSpeed * Time.deltaTime);

        RotateToVertical();
    }
    void RotateToVertical()
    {
        // return vertical axis to point along upright plane
        // consists of making sure Z-axis rotation goes back to 0
        if ((
                // neutral right-stick
                accel.rotateUp < deadzone && 
                accel.rotateDown < deadzone && 
                accel.rotateLeft < deadzone && 
                accel.rotateRight < deadzone &&

                // neutral left-stick
                accel.moveUp < deadzone &&
                accel.moveDown < deadzone &&
                accel.moveLeft < deadzone &&
                accel.moveRight < deadzone
                )
            ) 
        {
            Quaternion rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.rotation  = Quaternion.Lerp(transform.rotation, rotation, Time.time * rotateToVertSpeed);
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
