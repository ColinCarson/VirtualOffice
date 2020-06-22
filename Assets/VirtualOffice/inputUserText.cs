using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputUserText : MonoBehaviour
{
    private string userInput;
    public InputField inputField;
    public GameObject textSend;

    public void StoreInput()
    {
        userInput = inputField.text;
        textSend.GetComponent<Text>().text = userInput;
        inputField.text = "";
    }

    public void ClearInput()
    {
        textSend.GetComponent<Text>().text = "";
    }
}
