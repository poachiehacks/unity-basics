using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float verticalOffset;
    public float horizontalOffset;
    public float forwardOffset;
    public bool addSinusoidalLevitation;
    public GameObject cube;

    private Vector3 undulation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
            this keeps an object at a set offset from the player's head
         */
        // get rotation of player
        Quaternion target_rotation = cube.transform.rotation;

        // compute sinusoidal undulation (in up-axis) of companion object
        Vector3 levitation = Vector3.zero;
        if (addSinusoidalLevitation) {
            float freq      = 0.2f;
            float magnitude = 0.2f;
            levitation = new Vector3(0, magnitude * Mathf.Sin(2 * Mathf.PI * freq * Time.time), 0);
        }

        // update camera position to be behind player
        transform.position = cube.transform.position + target_rotation * new Vector3(horizontalOffset, verticalOffset, forwardOffset) + levitation;

        // update camera rotation to face player
        transform.rotation = target_rotation;


        /*
            camera position update broken down into individual steps
         */ 
        
        // // 1. get rotation of player
        // Quaternion target_rotation = cube.transform.rotation;

        // // 2. create a Vector3 that's the desired distance away from the player
        // Vector3 localvector = new Vector3(0, verticalOffset, -cameraForwardOffset);

        // // 3. rotate the vector by the player's rotation
        // localCameraVector = target_rotation * localCameraVector;

        // // update camera position
        // transform.position = cube.transform.position + localCameraVector;


    }
}
