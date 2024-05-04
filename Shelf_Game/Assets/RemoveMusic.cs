using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMusic : MonoBehaviour
{
    public List<AudioSource> sfxSounds = new List<AudioSource>();

    private bool isMuted = false;
    private const string MUTE_PREFS_KEY = "MusicIsMuted";

    void Start()
    {
        // Load mute state from PlayerPrefs
        isMuted = PlayerPrefs.GetInt(MUTE_PREFS_KEY, 0) == 1;

        // Apply mute state
        ApplyMuteState();
    }

    public void ToggleMute()
    {
        // Toggle mute state
        isMuted = !isMuted;

        // Apply mute state
        ApplyMuteState();

        // Save mute state to PlayerPrefs
        PlayerPrefs.SetInt(MUTE_PREFS_KEY, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void ApplyMuteState()
    {
        // Set volume for all SFX sounds
        float volume = isMuted ? 0f : 1f;
        foreach (var sfxSound in sfxSounds)
        {
            if (sfxSound != null)
            {
                sfxSound.volume = volume;
            }
        }
    }
}
