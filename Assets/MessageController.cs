using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SlackLink;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{

    [SerializeField]
    GameObject inputText;
    [SerializeField]
    GameObject Player;
    bool trigger;
    string destinationChar;

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
        destinationChar = other.name;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        trigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    public void onClick()
    {
        var slackLink = new SlackLink.SlackLink();
        slackLink.SendMessage("U015W8DN5KN", inputText.GetComponent<Text>().text);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && trigger)
        {
            var slackLink = new SlackLink.SlackLink();
            slackLink.StartZoomCall("U015W8DN5KN", "@U015W8DN5KN", "Fancy a video call?", "https://us04web.zoom.us/j/3481207951?pwd=S2VINDFNTUlVbHVFYmNsVXBlZ3pvUT09");
        }
    }
}
