using UnityEngine;
using System.Collections;
//using UnityEditor.VersionControl;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;
    bool trigger = false;
    [SerializeField]
    GameObject Player;

    public inputUserText controller;

    float x = -0.35f;
    float y = 0.28f;
    float z = 0.0f;

    void Start()
    {
        messageCanvas.enabled = false;
    }

    void Update()
    {
        UpdateLocation();
        if (Input.GetKeyDown(KeyCode.M) && trigger)
        {
            TurnOnMessage();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
    }

    private void UpdateLocation()
    {
        messageCanvas.transform.position = Player.transform.position + new Vector3(x, y, z); 
        // Set world position via script, this position is "relative to" player
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
        controller = GameObject.FindObjectOfType(typeof(inputUserText)) as inputUserText;
        controller.ClearInput();
        //Text t = child.GetComponent<Text>();
        //messageCanvas.GetComponent<Text>().text = "";
        //t.text = "";
    }
}
