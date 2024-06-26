using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed = 50;
    public float moveSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // // read values from keyboard
        // horizontalInput = Input.GetAxis("Horizontal");
        // verticalInput   = Input.GetAxis("Vertical");

        // // move the object
        // transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime * verticalInput);
        // // transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);
        // transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);    // using Vector3.up means we rotate around that axis??
        
        
        // read values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput   = Input.GetAxis("Vertical");

        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput  = Input.GetAxis("Vertical");
        float rhorizInput = Input.GetAxis("RHorizontal");
        float rvertInput  = Input.GetAxis("RVertical");


        // strafing
        transform.Translate(moveSpeed * Vector3.forward * Time.deltaTime * verticalInput);
        transform.Translate(moveSpeed * Vector3.right   * Time.deltaTime * horizontalInput);

        // turning
        transform.Rotate(Vector3.up * rhorizInput * turnSpeed * Time.deltaTime);    // using Vector3.up means we rotate around that axis??
        transform.Rotate(Vector3.right * rvertInput * turnSpeed * Time.deltaTime);    // using Vector3.up means we rotate around that axis??
    }
}
