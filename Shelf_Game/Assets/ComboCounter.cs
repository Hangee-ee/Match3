using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    public TMP_Text comboText;

    void Start()
    {
        if (comboText == null)
        {
            Debug.LogError("Combo TextMeshPro component is not assigned!");
            return;
        }
    }

    private void Update()
    {
        UpdateComboText();
    }

    void UpdateComboText()
    {
        int totalCombo = PlayerPrefs.GetInt("comboCounterPrefs", 0);

        comboText.text = totalCombo.ToString();
    }
}
