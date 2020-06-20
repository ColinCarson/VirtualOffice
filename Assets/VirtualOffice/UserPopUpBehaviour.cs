using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPopUpBehaviour : MonoBehaviour
{

    [SerializeField]
    Canvas popUpCanvas;
    bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
        popUpCanvas.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && trigger)
        {
            GetComponent<moves>().canMove = false;
            TurnOnMessage();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffMessage();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "PLAYER")
        {
            trigger = true;
        }
    }

    private void TurnOnMessage()
    {
        popUpCanvas.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "PLAYER")
        {
            TurnOffMessage();
            trigger = false;
        }
    }

    public void TurnOffMessage()
    {
        GetComponent<moves>().canMove = true;
        popUpCanvas.enabled = false;
    }
}
