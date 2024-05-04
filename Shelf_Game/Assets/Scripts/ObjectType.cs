using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectType : MonoBehaviour
{
    public ItemType itemData;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        Color newColor = image.color;
        newColor.a = 1f;
        image.color = newColor;
    }
}