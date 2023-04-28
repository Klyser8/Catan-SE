using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class is used for managing graphics and resolution settings in a Unity game.
/// It provides functionality to change the game's resolution, quality level, and fullscreen mode.
/// </summary>
public class GraphicsAndResolution : MonoBehaviour
{
    /// <summary>
    /// Reference to the resolution dropdown UI element.
    /// </summary>
    public TMP_Dropdown resolutionDropdown;

    /// <summary>
    /// Stores the available screen resolutions.
    /// </summary>
    private Resolution[] resolutions;

    /// <summary>
    /// Retrieves available screen resolutions, clears the dropdown options, and populates it with the available resolutions.
    /// </summary>
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }

    /// <summary>
    /// Sets the game resolution based on the selected dropdown index.
    /// </summary>
    /// <param name="resolutionIndex">The index of the selected resolution.</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// Sets the quality level of the game.
    /// </summary>
    /// <param name="qualityIndex">The index of the selected quality level.</param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Toggles fullscreen mode based on the input boolean value.
    /// </summary>
    /// <param name="isFullscreen">A boolean value indicating whether fullscreen mode should be enabled.</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

