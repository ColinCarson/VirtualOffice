using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputUserText : MonoBehaviour
{
    public string userInput;
    public GameObject inputField;
    public GameObject textSend;

    public void StoreInput()
    {
        userInput = inputField.GetComponent<Text>().text;
        textSend.GetComponent<Text>().text = userInput;
    }
}
