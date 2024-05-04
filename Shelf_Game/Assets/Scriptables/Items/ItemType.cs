using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Food Item")]
public class ItemType : ScriptableObject
{
    public string objectName;
    public FoodItem foodType;
    public float spriteAlpha = 1; 
}

public enum FoodItem
{
    Fries, 
    Pizza,
    Burger,
    Sandwich, 
    Dumplings, 
    Sushi, 
    Hotdogs,
    Dragonfruit,
    Raspberry,
    Kiwi,
    AppleGreen,
    AppleRed,
    Orange,
    Pear,
    Avocado

}