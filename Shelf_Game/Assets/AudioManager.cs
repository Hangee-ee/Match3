using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string MUTE_PREFS_KEY = "IsMuted";

    // This method is called when a new scene is loaded
    void OnEnable()
    {
        ApplyMuteState();
    }

    private void ApplyMuteState()
    {
        // Get the mute state from PlayerPrefs
        bool isMuted = PlayerPrefs.GetInt(MUTE_PREFS_KEY, 0) == 1;

        // Find and mute/unmute all audio sources in the scene
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            // Check if the audio source is tagged as SFX or Music, for example
            // You might want to customize this based on your audio setup
            if (audioSource.CompareTag("SFX"))
            {
                audioSource.volume = isMuted ? 0f : 1f;
            }
        }
    }
}
