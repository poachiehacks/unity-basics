using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cube : MonoBehaviour
{
    float moveSpeed = 5;
    float turnSpeed = 50;
    PlayerControls controls;
    float move;
    float rotate;

    internal struct Accel {
        internal float moveUp;
        internal float moveDown;
        internal float rotateLeft;
        internal float rotateRight;
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

        controls.Gameplay.RotateLeft.performed += ctx => accel.rotateLeft = ctx.ReadValue<float>();
        controls.Gameplay.RotateLeft.canceled  += ctx => accel.rotateLeft = 0.0f;
        controls.Gameplay.RotateRight.performed += ctx => accel.rotateRight = ctx.ReadValue<float>();
        controls.Gameplay.RotateRight.canceled  += ctx => accel.rotateRight = 0.0f;
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
        transform.Translate(moveSpeed * new Vector3(0, 0, accel.moveUp) * Time.deltaTime);
        transform.Translate(moveSpeed * new Vector3(0, 0, -1 * accel.moveDown) * Time.deltaTime);
        
        //rotating
        transform.Rotate(Vector3.up * accel.rotateRight * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * -1 * accel.rotateLeft * turnSpeed * Time.deltaTime);
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
