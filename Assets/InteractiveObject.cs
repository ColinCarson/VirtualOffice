using UnityEngine;
using System.Collections;
using ZoomClient;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    Canvas messageCanvas;

    void Start()
    {
        messageCanvas.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PLAYER")
        {
            TurnOnMessage();
        }
    }

    private void TurnOnMessage()
    {
        messageCanvas.enabled = true;

        // stub to init zoom call
        var zoomClient = new ZoomClient.ZoomClient();
        zoomClient.DoNothing();

        zoomClient.JoinMeeting("test", "test", "test");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PLAYER")
        {
            TurnOffMessage();
        }
    }

    private void TurnOffMessage()
    {
        messageCanvas.enabled = false;
    }
}
