using UnityEngine;
using System.Collections;

public class CameraFollow_Y_AXIS_Only : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private float offset;            //Private variable to store the offset distance between the player and camera
    private float ymov;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position[1] - player.transform.position[1];
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.position = player.transform.position + offset;
        //transform.position = transform.position + new Vector3(0, player.transform.position[1]-offset, 0);
        ymov = player.transform.position[1]+offset;

        transform.position = new Vector3(transform.position[0], ymov, transform.position[2]);
    }
}