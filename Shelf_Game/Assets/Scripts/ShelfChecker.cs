using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfChecker : MonoBehaviour
{
    public static int comboCounter;
    public static int localComboCounter;

    private void Awake()
    {
        comboCounter = PlayerPrefs.GetInt("comboCounterPrefs");
        localComboCounter = 0;
        PlayerPrefs.SetInt("localComboCounterPrefs", 0);
    }
    private void Update()
    {
        CheckShelf();
    }
    public void CheckShelf()
    {
        Dictionary<string, int> itemCounts = new Dictionary<string, int>();

        foreach (Transform slot in transform)
        {
            if (slot.childCount > 0)
            {
                GameObject item = slot.GetChild(0).gameObject;
                string itemType = item.tag;

                if (itemCounts.ContainsKey(itemType))
                {
                    itemCounts[itemType]++;
                }
                else
                {
                    itemCounts[itemType] = 1;
                }
            }
        }

        if (itemCounts.Count == 1 && itemCounts.ContainsValue(3))
        {
            foreach (Transform slot in transform)
            {
                foreach (Transform child in slot)
                {
                    Destroy(child.gameObject);
                }
            }
            comboCounter++;
            PlayerPrefs.SetInt("comboCounterPrefs", comboCounter);
            Debug.LogError("Combo Counter: " + comboCounter);
            localComboCounter++;
            PlayerPrefs.SetInt("localComboCounterPrefs", localComboCounter);
            Debug.LogError("LocalCombo: " + localComboCounter + "prefs: " + PlayerPrefs.GetInt("localComboCounterPrefs"));

            ComboCounterEvents.OnComboCounterIncreased();
        }
    }
}
