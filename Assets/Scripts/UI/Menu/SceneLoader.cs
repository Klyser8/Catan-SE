using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for loading a specific scene in the game.
/// In this case, it is designed to load the "CatanGame" scene.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// Loads the "CatanGame" scene.
    /// </summary>
    public void LoadCatanGame()
    {
        SceneManager.LoadScene("CatanGame");
    }
}
