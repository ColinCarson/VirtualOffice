using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow_Y_AXIS_Only : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    GameObject gameCamera;

    void Start()
    {
        player = GameObject.Find("PLAYER").transform;
    }

    void Update()
    {
        Vector3 playerpos = player.position;
        playerpos.y = transform.position.y;
        transform.position = playerpos;
    }
}
