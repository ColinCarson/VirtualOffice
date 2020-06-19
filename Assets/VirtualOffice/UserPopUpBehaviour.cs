using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPopUpBehaviour : MonoBehaviour
{

    [SerializeField]
    Canvas popUpCanvas;
    bool trigger;
    //string NPCName;

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
            TurnOnMessage();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "PLAYER")
        {
           // NPCName = other.name;
            trigger = true;
        }
    }

    private void TurnOnMessage()
    {
        popUpCanvas.enabled = true;
        //  popUpCanvas.GetComponent<InputField>().ActivateInputField();
        //NPCName
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name != "PLAYER")
        {
            TurnOffMessage();
            trigger = false;
        }
    }

    private void TurnOffMessage()
    {
        popUpCanvas.enabled = false;
    }
}
