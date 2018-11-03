using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuButtonsScript : MonoBehaviour {

public void changeSceneToQuickMatch()
    {
        SceneManager.LoadScene("QuickMatch", LoadSceneMode.Single);
    }

    public void changeSceneToSettigs()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void changeSceneToCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void changeSceneToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void exitTheGame()
    {
        Application.Quit();
    }
 

	}

