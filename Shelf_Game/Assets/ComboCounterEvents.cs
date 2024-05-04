using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComboCounterEvents
{
    public delegate void ComboCounterIncreasedEventHandler();
    public static event ComboCounterIncreasedEventHandler ComboCounterIncreased;

    public static void OnComboCounterIncreased()
    {
        ComboCounterIncreased?.Invoke();
    }
}
