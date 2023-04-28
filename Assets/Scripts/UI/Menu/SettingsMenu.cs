using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

/// <summary>
/// This class is responsible for managing the settings menu in a Unity game.
/// It provides functionality to adjust volume, resolution, quality, and fullscreen settings.
/// </summary>
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    /// <summary>
    /// Initializes the settings menu by populating the resolution dropdown with available options.
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
    /// Sets the game resolution based on the given index.
    /// </summary>
    /// <param name="resolutionIndex">The index of the desired resolution in the resolutions array.</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /// <summary>
    /// Sets the game volume using the given volume value.
    /// </summary>
    /// <param name="volume">The desired volume level.</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    /// <summary>
    /// Sets the game quality based on the given quality index.
    /// </summary>
    /// <param name="qualityIndex">The index of the desired quality level.</param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    /// <summary>
    /// Sets the game fullscreen mode based on the given boolean value.
    /// </summary>
    /// <param name="isFullscreen">True to enable fullscreen mode, false to disable it.</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
