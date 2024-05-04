using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboCounterListener : MonoBehaviour
{
    public AudioSource comboSound;
    private void OnEnable()
    {
        ComboCounterEvents.ComboCounterIncreased += HandleComboCounterIncreased;
    }

    private void OnDisable()
    {
        ComboCounterEvents.ComboCounterIncreased -= HandleComboCounterIncreased;
    }

    private void HandleComboCounterIncreased()
    {
        if (comboSound != null)
        {
            comboSound.Play();
        }
    }
}