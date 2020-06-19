using UnityEngine;
using System.Collections;
using SlackLink;

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
        var slackLink = new SlackLink.SlackLink();
        slackLink.SendMessageToUser("#random", "Hello from the bot!", "USLACKBOT", "");
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
