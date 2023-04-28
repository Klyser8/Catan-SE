using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// This class is responsible for managing the sound options in a Unity game.
/// It provides functionality to adjust master volume, music volume, and sound volume.
/// </summary>
public class SoundOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    /// <summary>
    /// Sets the master volume using the given volume value.
    /// </summary>
    /// <param name="volume">The desired master volume level.</param>
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    /// <summary>
    /// Sets the music volume using the given volume value.
    /// </summary>
    /// <param name="volume">The desired music volume level.</param>
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    /// <summary>
    /// Sets the sound volume using the given volume value.
    /// </summary>
    /// <param name="volume">The desired sound volume level.</param>
    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }
}

