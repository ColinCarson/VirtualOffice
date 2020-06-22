using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public moves menuController;

    void Start()
    {
        //SceneManager.LoadScene("MenuScene");
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void playGame()
    {
        mainMenu.SetActive(false);
        //SceneManager.LoadScene("GameScene");
    }

    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void Update()
    {

        if (mainMenu.activeSelf || optionsMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        menuController = GameObject.FindObjectOfType(typeof(moves)) as moves;
        bool canMove = menuController.canMove;

        //this is disabled for now because it pops up when you try to exit a conversation
        if (Input.GetKeyDown(KeyCode.Escape)&&canMove)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }
    }
}
