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
    string destinationID;

    void OnTriggerEnter2D(Collider2D other)
    {
        trigger = true;
        destinationChar = other.name;
        destinationID = IDLookUp(destinationChar);
    }

    private string IDLookUp(string inputName)
    {
        string outString= "";

        const string j = "Justin";
        const string d = "Dean";
        const string c = "Conrad";
        const string n = "Neil";
        const string ch = "Clubhouse";

        switch (inputName)
        {
            case j:
                outString = "U015W8DN5KN";
                break;
            case d:
                outString = "U016DTQ3JP2";
                break;
            case c:
                outString = "U015HAZ632S";
                break;
            case n:
                outString = "U0162MFLDLZ";
                break;
            case ch:
                outString = "#clubhouse";
                    break;
        }

        return outString;
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
        //slackLink.SendMessage("U015W8DN5KN", inputText.GetComponent<Text>().text);
        slackLink.SendMessage(destinationID, inputText.GetComponent<Text>().text);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && trigger)
        {
            var slackLink = new SlackLink.SlackLink();
            //slackLink.StartZoomCall("U015W8DN5KN", "@U015W8DN5KN", "Fancy a video call?", "https://us04web.zoom.us/j/3481207951?pwd=S2VINDFNTUlVbHVFYmNsVXBlZ3pvUT09");
            slackLink.StartZoomCall(destinationID, "@"+destinationID, "Fancy a video call?", "https://us04web.zoom.us/j/3481207951?pwd=S2VINDFNTUlVbHVFYmNsVXBlZ3pvUT09");
        }
    }
}
