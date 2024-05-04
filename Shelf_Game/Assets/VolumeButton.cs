using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
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
        bool isVolumeOn = !PlayerPrefs.HasKey("IsMuted") || PlayerPrefs.GetInt("IsMuted") == 0;
        PlayerPrefs.SetInt("IsMuted", isVolumeOn ? 1 : 0);
        UpdateButtonSprite();
    }

    void UpdateButtonSprite()
    {
        bool isVolumeOn = !PlayerPrefs.HasKey("IsMuted") || PlayerPrefs.GetInt("IsMuted") == 0;
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
