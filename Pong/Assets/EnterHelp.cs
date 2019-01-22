using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHelp : MonoBehaviour
{
    public GameObject HelpMenu, HelpButton;

    // Initializes the game to hide the help menu and display the button to access it
    void Start()
    {
        HelpMenu.SetActive(false);
        HelpButton.SetActive(true);
        Time.timeScale = 1;
    }

    // When help button is selected, help menu is displayed and time is paused
    public void Pause()
    {
        HelpMenu.SetActive(true);
        HelpButton.SetActive(false);
        Time.timeScale = 0;
    }

    // When game is resumed, help menu is hidden and time is resumed
    public void Resume()
    {
        HelpMenu.SetActive(false);
        HelpButton.SetActive(true);
        Time.timeScale = 1;
    }
}
