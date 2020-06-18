﻿using UnityEngine;
using System.Collections;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    bool trigger = false;
    [SerializeField]
    GameObject Player;

    float x = -0.35f;
    float y = 0.28f;
    float z = 0.0f;

    void Start()
    {
        messageCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)&&trigger)
        {
            TurnOnMessage();
        }
        UpdateLocation();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
    }

    private void UpdateLocation()
    {
        messageCanvas.transform.position = Player.transform.position + new Vector3(x, y, z); 
        // Set world position via script, this position is "relative to" building
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    { 
        TurnOffMessage();
        trigger = false;
  
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}
