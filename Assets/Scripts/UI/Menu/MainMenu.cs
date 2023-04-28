using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used for managing the main menu of the game.
/// It provides functionality to load different scenes and exit the game.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the next scene in the build index.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Loads the previous scene in the build index.
    /// </summary>
    public void QuitGameToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    /// <summary>
    /// Exits the game application.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
