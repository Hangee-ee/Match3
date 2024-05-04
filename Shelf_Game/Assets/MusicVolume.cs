using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Sprite volumeTrueSprite;
    public Sprite volumeFalseSprite;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        UpdateButtonSprite();
    }

    public void ToggleVolume()
    {
        // Toggle the volume state when the button is clicked
        bool isVolumeOn = !PlayerPrefs.HasKey("MusicIsMuted") || PlayerPrefs.GetInt("MusicIsMuted") == 0;
        PlayerPrefs.SetInt("MusicIsMuted", isVolumeOn ? 1 : 0);
        UpdateButtonSprite();
    }

    void UpdateButtonSprite()
    {
        bool isVolumeOn = !PlayerPrefs.HasKey("MusicIsMuted") || PlayerPrefs.GetInt("MusicIsMuted") == 0;
        if (isVolumeOn)
        {
            button.image.sprite = volumeTrueSprite;
        }
        else
        {
            button.image.sprite = volumeFalseSprite;
        }
    }

}
