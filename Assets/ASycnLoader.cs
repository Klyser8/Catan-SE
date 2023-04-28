using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ASycnLoader class handles the logic for asynchronously loading levels with a loading screen and progress slider.
/// </summary>
public class ASycnLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Slider loadingSlider;

    /// <summary>
    /// Activates the loading screen and starts asynchronously loading the specified level.
    /// </summary>
    /// <param name="levelToLoad">The name of the level to load.</param>
    public void LoadLevelButton(string levelToLoad)
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    /// <summary>
    /// Coroutine that asynchronously loads the specified level while updating the progress slider.
    /// </summary>
    /// <param name="levelToLoad">The name of the level to load.</param>
    /// <returns>Yield instruction for the coroutine.</returns>
    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }
}

