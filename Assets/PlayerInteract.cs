using UnityEngine;
using System.Collections;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    bool trigger = false;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
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
